using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.View.Form;

namespace Com.Wiseape.Gateway.Email.View.Validator
{
    public class UserAccountFormValidator : IFormValidator
    {

        public ValidationResult Validate(DataForm form) 
        {
            ValidationResult result = new ValidationResult(true);
            UserAccountForm userAccountForm = (UserAccountForm)form;
	
            if(userAccountForm.FirstName.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "First Name can not be empty";
            }
	
            if(userAccountForm.LastName.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Last Name can not be empty";
            }
	
            if(userAccountForm.Username.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Username can not be empty";
            }
	
            if(userAccountForm.Password.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "Password can not be empty";
            }
	
            if(userAccountForm.AppName.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "App Name can not be empty";
            }
	
            if(userAccountForm.AppToken.Length == 0)
            {
                result.Result = false;
                result.ErrorMessage = "App Token can not be empty";
            }
	
            return result;
        }
    }
}
