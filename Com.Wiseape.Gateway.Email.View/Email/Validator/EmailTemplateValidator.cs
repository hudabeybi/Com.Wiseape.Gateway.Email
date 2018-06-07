using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.View.Form;

namespace Com.Wiseape.Gateway.Email.View.Validator
{
    public class EmailTemplateFormValidator : IFormValidator
    {

        public ValidationResult Validate(DataForm form) 
        {
            ValidationResult result = new ValidationResult(true);
            EmailTemplateForm emailTemplateForm = (EmailTemplateForm)form;
	
            if(emailTemplateForm.EmailSubject.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Email Subject can not be empty";
            }
	
            if(emailTemplateForm.Tag.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Tag can not be empty";
            }
	
            return result;
        }
    }
}
