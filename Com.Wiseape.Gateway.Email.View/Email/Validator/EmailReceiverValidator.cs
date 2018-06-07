using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.View.Form;

namespace Com.Wiseape.Gateway.Email.View.Validator
{
    public class EmailReceiverFormValidator : IFormValidator
    {

        public ValidationResult Validate(DataForm form) 
        {
            ValidationResult result = new ValidationResult(true);
            EmailReceiverForm emailReceiverForm = (EmailReceiverForm)form;
	
            if(emailReceiverForm.Tag.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Tag can not be empty";
            }
	
            return result;
        }
    }
}
