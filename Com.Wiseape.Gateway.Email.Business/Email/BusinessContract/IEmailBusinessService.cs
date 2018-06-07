using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Utility;
using Com.Wiseape.Gateway.Email.View.Form;

namespace Com.Wiseape.Gateway.Email.Business.Contracts
{
    public interface IEmailBusinessService
    {
        OperationResult SendEmailByTag(SendEmailForm sendEmailForm);
        OperationResult SendUnsentEmailInDatabase();
    }
}
