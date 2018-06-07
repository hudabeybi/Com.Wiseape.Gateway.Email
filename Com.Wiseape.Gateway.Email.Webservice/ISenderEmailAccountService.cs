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
    public interface ISenderEmailAccountService
    {

        [OperationContract]
        string FindSenderEmailAccountList(string keyword, string page, string size);

        [OperationContract]
        string GetSenderEmailAccount(string idSender);

        [OperationContract]
        string AddSenderEmailAccount(SenderEmailAccountForm senderEmailAccountForm);

        [OperationContract]
        string UpdateSenderEmailAccount(SenderEmailAccountForm senderEmailAccountForm);

        [OperationContract]
        string DeleteSenderEmailAccount(string idSender);

		[OperationContract]
        string GetLookups();

    }
}
