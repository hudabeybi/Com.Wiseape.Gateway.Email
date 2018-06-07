using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Utility;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.Business.Contracts;
using Com.Wiseape.Gateway.Email.View.Form;
using Com.Wiseape.Gateway.Email.View.FormDataConverter;
using Com.Wiseape.Gateway.Email.Data.Model;

namespace Com.Wiseape.Gateway.Email.Business.Service
{
    public class EmailBusinessService : IEmailBusinessService
    {
        public OperationResult SendUnsentEmailInDatabase()
        {
            IBusinessService emailSentBusinessService = new EmailSentBusinessService();
            SelectParam selectParam = new SelectParam();
            selectParam.Where = null;
            selectParam.Where = "IsSent = 0";
            OperationResult result = emailSentBusinessService.FindAll(selectParam, null, null);

            List<object> emailSentList = (List<object>)result.Data;
            foreach (object emailSent in emailSentList)
            {

                OperationResult resultSendEmail = SendUnsentEmailItem(emailSent);
                emailSent.GetType().GetProperty("SentDate").SetValue(emailSent, DateTime.Now, null);
                if (resultSendEmail.Result)
                {
                    emailSent.GetType().GetProperty("IsSent").SetValue(emailSent, 1, null);
                    
                }
                else
                {
                    string errorMessage = "";

                    Exception e = (Exception)resultSendEmail.Data;
                    errorMessage = e.Message + "\n\n";
                    if (e.InnerException != null)
                        errorMessage += e.InnerException.Message;
                    emailSent.GetType().GetProperty("IsSent").SetValue(emailSent, 0, null);
                    
                    emailSent.GetType().GetProperty("FailReason").SetValue(emailSent, errorMessage, null);

                }

                try
                {
                    emailSentBusinessService.Update(emailSent);
                }
                catch (Exception err)
                {
                    result.Data = err;
                }

            }
       

            return result;
        }

        protected object GetSenderEmailAccount(Int64 idSenderEmailAccount)
        {
            SenderEmailAccountBusinessService businessService = new SenderEmailAccountBusinessService();
            OperationResult result = businessService.Get(idSenderEmailAccount);
            return result.Data;
        }

        protected virtual OperationResult SendUnsentEmailItem(object emailSent)
        {
            Int64 idSenderEmailAccount = Convert.ToInt64(emailSent.GetType().GetProperty("EmailAccountId").GetValue(emailSent, null));
            Int64 idEmailSent = Convert.ToInt64(emailSent.GetType().GetProperty("IdEmailSent").GetValue(emailSent, null));

            object senderEmailAccount = GetSenderEmailAccount(idSenderEmailAccount);

            try
            {
                string to = (string)emailSent.GetType().GetProperty("EmailTos").GetValue(emailSent, null);
                string[] tos = new string [] { to };
                if(to.Contains(";"))
                {
                    tos = to.Split(new char[] { ';' });
                }

                string cc = (string)emailSent.GetType().GetProperty("EmailTos").GetValue(emailSent, null);
                string[] ccs = new string[] { cc };
                if (cc.Contains(";"))
                {
                    ccs = cc.Split(new char[] { ';' });
                }

                string subject = (string)emailSent.GetType().GetProperty("EmailSubject").GetValue(emailSent, null);
                string content = (string)emailSent.GetType().GetProperty("EmailContent").GetValue(emailSent, null);
                InitializeEmaill(senderEmailAccount);
                string senderName = senderEmailAccount.GetType().GetProperty("SenderName").GetValue(senderEmailAccount, null).ToString();
                string senderEmail = senderEmailAccount.GetType().GetProperty("SenderEmail").GetValue(senderEmailAccount, null).ToString();

                System.Collections.Generic.HashSet<EmailAttachment> emailAttachments = (System.Collections.Generic.HashSet<EmailAttachment>)emailSent.GetType().GetProperty("EmailAttachments").GetValue(emailSent, null);
                EmailUtility.SendEmail(senderName, senderEmail, tos, ccs, null, subject, content, EmailAttachmentsToDictionary(emailAttachments) );
                return new OperationResult(true);
            }
            catch (Exception err)
            {
                return new OperationResult(false, err);
            }
            
        }

        Dictionary<string, string> EmailAttachmentsToDictionary(System.Collections.Generic.HashSet<EmailAttachment> emailAttachments)
        {
            Dictionary<string, string> dicts = new Dictionary<string, string>();
            if(emailAttachments != null)
            {
                foreach (EmailAttachment emailAttachment in emailAttachments)
                {
                    dicts.Add(emailAttachment.Filename, emailAttachment.FileContent);
                }
            }

            return dicts;
        }

        public OperationResult SendEmailByTag(SendEmailForm sendEmailForm)
        {

            SenderEmailAccountForm senderEmailAccount = GetSenderEmailAccountByTag(sendEmailForm.Tag);
            EmailTemplateForm emailTemplate = GetEmailTemplateByTag(sendEmailForm.Tag);

            if (senderEmailAccount != null && emailTemplate != null)
            {
                emailTemplate.EmailContent = ReplaceContent(emailTemplate.EmailContent, sendEmailForm.KeyValues);
                emailTemplate.EmailSubject = ReplaceContent(emailTemplate.EmailSubject, sendEmailForm.KeyValues);

                return SaveToDatabase(senderEmailAccount, emailTemplate, sendEmailForm);
            }

            return new OperationResult(false, "No sender and email template defined for tag = '" + sendEmailForm.Tag + "'");
        }

        protected virtual SenderEmailAccountForm GetSenderEmailAccountByTag(string tag)
        {
            ISenderEmailAccountBusinessService senderEmailAccountService = new SenderEmailAccountBusinessService();
            OperationResult result = senderEmailAccountService.FindAllByTag(tag);
            List<object> senderEmailAccountList = (List<object>)result.Data;
            if (senderEmailAccountList.Count > 0)
            {
                object obj = senderEmailAccountList[0];
                SenderEmailAccountForm senderEmailAccountForm = new SenderEmailAccountForm();
                SenderEmailAccountFormDataConverter converter = new SenderEmailAccountFormDataConverter();
                converter.PopulateForm(obj, senderEmailAccountForm);
                return senderEmailAccountForm;
            }
            return null;
        }

        protected virtual EmailTemplateForm GetEmailTemplateByTag(string tag)
        {
            IEmailTemplateBusinessService emailTemplateBusinessService = new EmailTemplateBusinessService();
            OperationResult result = emailTemplateBusinessService.FindAllByTag(tag);
            List<object> emailTemplateList = (List<object>)result.Data;
            if (emailTemplateList.Count > 0)
            {
                object obj = emailTemplateList[0];
                EmailTemplateForm emailTemplateForm = new EmailTemplateForm();
                EmailTemplateFormDataConverter converter = new EmailTemplateFormDataConverter();
                converter.PopulateForm(obj, emailTemplateForm);
                return emailTemplateForm;
            }
            return null;
        }

        protected virtual string ReplaceContent(string content, List<KeyValue> variableValues)
        {
            foreach(KeyValue item in variableValues)
            {
                content = content.Replace("{" + item.Key + "}", item.Value);
            }
            return content;
        }

        protected virtual void InitializeEmaill(object senderEmailAccount)
        {
            
            EmailUtility.EnableSsl = (senderEmailAccount.GetType().GetProperty("EnableSsl").GetValue(senderEmailAccount, null).ToString() == "1") ? true : false;
            EmailUtility.SMTPHost = senderEmailAccount.GetType().GetProperty("SmtpServer").GetValue(senderEmailAccount, null).ToString();
            EmailUtility.SMTPPort = Convert.ToInt16( senderEmailAccount.GetType().GetProperty("SmtpPort").GetValue(senderEmailAccount, null));
            EmailUtility.EmailAccountPassword = senderEmailAccount.GetType().GetProperty("EmailAccountPassword").GetValue(senderEmailAccount, null).ToString();
            EmailUtility.EmailAccountUsername = senderEmailAccount.GetType().GetProperty("EmailAccount").GetValue(senderEmailAccount, null).ToString(); 
        }  

        protected virtual OperationResult SaveToDatabase(SenderEmailAccountForm senderEmailAccount, EmailTemplateForm emailTemplate, SendEmailForm sendMailForm )
        {

            object obj = Factory.Create<object>("EmailSent", ClassType.clsTypeDataModel);
            obj.GetType().GetProperty("SenderName").SetValue(obj, senderEmailAccount.SenderName, null);
            obj.GetType().GetProperty("EmailFrom").SetValue(obj, senderEmailAccount.EmailAccount, null);
            obj.GetType().GetProperty("EmailFromAlias").SetValue(obj, senderEmailAccount.SenderEmail, null);
            obj.GetType().GetProperty("EmailSubject").SetValue(obj, emailTemplate.EmailSubject, null);
            obj.GetType().GetProperty("EmailContent").SetValue(obj, emailTemplate.EmailContent, null);
            obj.GetType().GetProperty("SentDate").SetValue(obj, DateTime.Now, null);
            obj.GetType().GetProperty("EmailTos").SetValue(obj, sendMailForm.To, null);
            obj.GetType().GetProperty("EmailCcs").SetValue(obj, sendMailForm.Cc, null);
            obj.GetType().GetProperty("UserId").SetValue(obj, senderEmailAccount.UserId, null);
            obj.GetType().GetProperty("IsSent").SetValue(obj, 0, null);
            obj.GetType().GetProperty("EmailAccountId").SetValue(obj, senderEmailAccount.IdSender, null);


            EmailSentBusinessService businessService = new EmailSentBusinessService();
            OperationResult result = businessService.Add(obj);
            object emailSent = result.Data;

            EmailAttachmentBusinessService bs = new EmailAttachmentBusinessService();

            if(sendMailForm.Attachments != null)
            {
                foreach (EmailAttachment attachment in sendMailForm.Attachments)
                {
                    attachment.EmailSentId = Convert.ToInt64( emailSent.GetType().GetProperty("IdEmailSent").GetValue(emailSent, null));
                    bs.Add(attachment);
                }
            }

           // emailSent.EmailContent = Convert.ToBase64String(Encoding.UTF8.GetBytes(emailSent.EmailContent));
            result.Data = emailSent;
            return result;
        }
    }
}
