using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Com.Wiseape.Utility;
using Com.Wiseape.Framework;
using System.Web.Script.Serialization;
using Com.Wiseape.Gateway.Email.Data.Model;
using Com.Wiseape.Gateway.Email.View.Form;
using Com.Wiseape.Gateway.Email.View.Validator;
using Com.Wiseape.Gateway.Email.View.FormDataConverter;
using System.ServiceModel.Activation;

namespace Com.Wiseape.Gateway.Email.Webservice
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SenderEmailAccountService : ISenderEmailAccountService
    {
        class Keywords
        {
            public static string SENDEREMAILACCOUNT = "SenderEmailAccount";
        }

        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "senderemailaccount/add")]
        public string AddSenderEmailAccount(SenderEmailAccountForm senderEmailAccountForm)
        {
            DefaultController defaultController = new DefaultController(SenderEmailAccountService.Keywords.SENDEREMAILACCOUNT);
            defaultController.FormValidator = new SenderEmailAccountFormValidator();

            OperationResult result = defaultController.Add(senderEmailAccountForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "senderemailaccount/find/{keyword}/{page}/{size}")]
        public string FindSenderEmailAccountList(string keyword, string page, string size)
        {

            SelectParam selectParam = new SelectParam();
            selectParam.Keyword = keyword;
            if (keyword == "all")
                selectParam.Keyword = null;

            IBusinessService businessService = Factory.Create<IBusinessService>("SenderEmailAccount", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.FindAllByKeyword(selectParam, Convert.ToInt16( page), Convert.ToInt16( size));

            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "senderemailaccount/get/{idSender}")]
        public string GetSenderEmailAccount(string idSender)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("SenderEmailAccount", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Get(idSender);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "senderemailaccount/update")]
        public string UpdateSenderEmailAccount(SenderEmailAccountForm senderEmailAccountForm)
        {
            DefaultController defaultController = new DefaultController(SenderEmailAccountService.Keywords.SENDEREMAILACCOUNT);
            defaultController.FormValidator = new SenderEmailAccountFormValidator();

            OperationResult result = defaultController.Update(senderEmailAccountForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "senderemailaccount/delete/{idSender}")]
        public string DeleteSenderEmailAccount(string idSender)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("SenderEmailAccount", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Delete(idSender);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "senderemailaccount/lookups")]
        public string GetLookups()
        {
			Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
		
            OperationResult result = new OperationResult(true, data);
            return Serializer.Json.Serialize(result);
        }
    }
}
