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
    public interface IEmailReceiverService
    {

        [OperationContract]
        string FindEmailReceiverList(string keyword, string page, string size);

        [OperationContract]
        string GetEmailReceiver(string idReceiver);

        [OperationContract]
        string AddEmailReceiver(EmailReceiverForm emailReceiverForm);

        [OperationContract]
        string UpdateEmailReceiver(EmailReceiverForm emailReceiverForm);

        [OperationContract]
        string DeleteEmailReceiver(string idReceiver);

		[OperationContract]
        string GetLookups();

    }
}
