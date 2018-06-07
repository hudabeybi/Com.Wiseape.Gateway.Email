using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Utility;
using Com.Wiseape.Gateway.Email.View.Form;
using System.ServiceModel;

namespace Com.Wiseape.Gateway.Email.Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMailService" in both code and config file together.
    [ServiceContract]
    public interface IMailService
    {
        [OperationContract]
        string SendMailByTag(SendEmailForm sendEmailForm);

        [OperationContract]
        string SendUnsent();
    }
}
