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

    public class EmailReceiverService : IEmailReceiverService
    {
        class Keywords
        {
            public static string EMAILRECEIVER = "EmailReceiver";
        }

        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "emailreceiver/add")]
        public string AddEmailReceiver(EmailReceiverForm emailReceiverForm)
        {
            DefaultController defaultController = new DefaultController(EmailReceiverService.Keywords.EMAILRECEIVER);
            defaultController.FormValidator = new EmailReceiverFormValidator();

            OperationResult result = defaultController.Add(emailReceiverForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "emailreceiver/find/{keyword}/{page}/{size}")]
        public string FindEmailReceiverList(string keyword, string page, string size)
        {

            SelectParam selectParam = new SelectParam();
            selectParam.Keyword = keyword;
            if (keyword == "all")
                selectParam.Keyword = null;

            IBusinessService businessService = Factory.Create<IBusinessService>("EmailReceiver", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.FindAllByKeyword(selectParam, Convert.ToInt16( page), Convert.ToInt16( size));

            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailreceiver/get/{idReceiver}")]
        public string GetEmailReceiver(string idReceiver)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("EmailReceiver", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Get(idReceiver);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailreceiver/update")]
        public string UpdateEmailReceiver(EmailReceiverForm emailReceiverForm)
        {
            DefaultController defaultController = new DefaultController(EmailReceiverService.Keywords.EMAILRECEIVER);
            defaultController.FormValidator = new EmailReceiverFormValidator();

            OperationResult result = defaultController.Update(emailReceiverForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailreceiver/delete/{idReceiver}")]
        public string DeleteEmailReceiver(string idReceiver)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("EmailReceiver", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Delete(idReceiver);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailreceiver/lookups")]
        public string GetLookups()
        {
			Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
		
            OperationResult result = new OperationResult(true, data);
            return Serializer.Json.Serialize(result);
        }
    }
}
