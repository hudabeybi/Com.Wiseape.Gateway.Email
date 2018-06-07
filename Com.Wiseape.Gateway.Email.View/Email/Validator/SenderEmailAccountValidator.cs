using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.View.Form;

namespace Com.Wiseape.Gateway.Email.View.Validator
{
    public class SenderEmailAccountFormValidator : IFormValidator
    {

        public ValidationResult Validate(DataForm form) 
        {
            ValidationResult result = new ValidationResult(true);
            SenderEmailAccountForm senderEmailAccountForm = (SenderEmailAccountForm)form;
	
            if(senderEmailAccountForm.SenderName.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Sender Name can not be empty";
            }
	
            if(senderEmailAccountForm.SenderEmail.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Sender Email can not be empty";
            }
	
            if(senderEmailAccountForm.SmtpServer.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Smtp Server can not be empty";
            }
	
            if(senderEmailAccountForm.EmailAccount.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Email Account can not be empty";
            }
	
            if(senderEmailAccountForm.EmailAccountPassword.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Email Account Password can not be empty";
            }
	
            return result;
        }
    }
}
