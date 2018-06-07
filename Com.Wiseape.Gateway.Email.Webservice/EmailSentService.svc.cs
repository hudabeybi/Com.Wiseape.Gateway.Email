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
using System.Web;
using System.ServiceModel.Activation;

namespace Com.Wiseape.Gateway.Email.Webservice
{
    public class EmailSentService : IEmailSentService
    {
        class Keywords
        {
            public static string EMAILSENT = "EmailSent";
        }

        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "emailsent/add")]
        public string AddEmailSent(EmailSentForm emailSentForm)
        {
            DefaultController defaultController = new DefaultController(EmailSentService.Keywords.EMAILSENT);
            defaultController.FormValidator = new EmailSentFormValidator();

            OperationResult result = defaultController.Add(emailSentForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "emailsent/find/{keyword}/{page}/{size}")]
        public string FindEmailSentList(string keyword, string page, string size)
        {

            SelectParam selectParam = new SelectParam();
            selectParam.Keyword = keyword;
            if (keyword == "all")
                selectParam.Keyword = null;

            selectParam.AddOrderBy("SentDate DESC");

            IBusinessService businessService = Factory.Create<IBusinessService>("EmailSent", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.FindAllByKeyword(selectParam, Convert.ToInt16( page), Convert.ToInt16( size));
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailsent/get/{idEmailSent}")]
        public string GetEmailSent(string idEmailSent)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("EmailSent", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Get(idEmailSent);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailsent/update")]
        public string UpdateEmailSent(EmailSentForm emailSentForm)
        {
            DefaultController defaultController = new DefaultController(EmailSentService.Keywords.EMAILSENT);
            defaultController.FormValidator = new EmailSentFormValidator();

            OperationResult result = defaultController.Update(emailSentForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailsent/delete/{idEmailSent}")]
        public string DeleteEmailSent(string idEmailSent)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("EmailSent", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Delete(idEmailSent);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailsent/lookups")]
        public string GetLookups()
        {
			Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
		
            OperationResult result = new OperationResult(true, data);
            return Serializer.Json.Serialize(result);
        }
    }
}
