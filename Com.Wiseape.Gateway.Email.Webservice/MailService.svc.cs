using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Wiseape.Gateway.Email.View.Form;
using Com.Wiseape.Utility;
using System.ServiceModel.Web;
using Com.Wiseape.Gateway.Email.Business.Contracts;
using Com.Wiseape.Gateway.Email.Business.Service;
using Com.Wiseape.Gateway.Email.Data.Model;
using System.ServiceModel.Activation;

namespace Com.Wiseape.Gateway.Email.Webservice
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MailService : IMailService
    {
        HttpContext httpContext;

        public MailService()
        {
            httpContext = HttpContext.Current;
        }

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "mail/send")]
        public string SendMailByTag(SendEmailForm sendEmailForm)
        {
            IEmailBusinessService emailBusinessService = new EmailBusinessService();
            OperationResult result = emailBusinessService.SendEmailByTag(sendEmailForm);
            emailBusinessService.SendUnsentEmailInDatabase();
            
            return Utility.Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "mail/sendunsent")]
        public string SendUnsent()
        {
            IEmailBusinessService emailBusinessService = new EmailBusinessService();
            OperationResult result = emailBusinessService.SendUnsentEmailInDatabase();
            return Utility.Serializer.Json.Serialize(result);
        }
    }
}
