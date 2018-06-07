using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.View.Form;

namespace Com.Wiseape.Gateway.Email.View.Validator
{
    public class EmailSentFormValidator : IFormValidator
    {

        public ValidationResult Validate(DataForm form) 
        {
            ValidationResult result = new ValidationResult(true);
            EmailSentForm emailSentForm = (EmailSentForm)form;
	
            if(emailSentForm.EmailFrom.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Email From can not be empty";
            }
	
            if(emailSentForm.EmailTos.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Email Tos can not be empty";
            }
	
            if(emailSentForm.EmailSubject.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Email Subject can not be empty";
            }
	
            if(emailSentForm.EmailContent.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Email Content can not be empty";
            }
	
            return result;
        }
    }
}
