using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Com.Wiseape.Utility;
using Com.Wiseape.Gateway.Email.Data.Model;
using Com.Wiseape.Gateway.Email.View.Form;


namespace Com.Wiseape.Gateway.Email.Webservice
{
    [ServiceContract]
    public interface IEmailSentService
    {

        [OperationContract]
        string FindEmailSentList(string keyword, string page, string size);

        [OperationContract]
        string GetEmailSent(string idEmailSent);

        [OperationContract]
        string AddEmailSent(EmailSentForm emailSentForm);

        [OperationContract]
        string UpdateEmailSent(EmailSentForm emailSentForm);

        [OperationContract]
        string DeleteEmailSent(string idEmailSent);

		[OperationContract]
        string GetLookups();

    }
}
