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
using System.Web;

namespace Com.Wiseape.Gateway.Email.Webservice
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class EmailTemplateService : IEmailTemplateService
    {
        class Keywords
        {
            public static string EMAILTEMPLATE = "EmailTemplate";
        }

        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "emailtemplate/add")]
        public string AddEmailTemplate(EmailTemplateForm emailTemplateForm)
        {
            DefaultController defaultController = new DefaultController(EmailTemplateService.Keywords.EMAILTEMPLATE);
            defaultController.FormValidator = new EmailTemplateFormValidator();

            OperationResult result = defaultController.Add(emailTemplateForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "emailtemplate/find/{keyword}/{page}/{size}")]
        public string FindEmailTemplateList(string keyword, string page, string size)
        {

            SelectParam selectParam = new SelectParam();
            selectParam.Keyword = keyword;
            if (keyword == "all")
                selectParam.Keyword = null;

            IBusinessService businessService = Factory.Create<IBusinessService>("EmailTemplate", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.FindAllByKeyword(selectParam, Convert.ToInt16( page), Convert.ToInt16( size));

            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailtemplate/get/{idEmailTemplate}")]
        public string GetEmailTemplate(string idEmailTemplate)
        {

            IBusinessService businessService = Factory.Create<IBusinessService>("EmailTemplate", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Get(idEmailTemplate);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailtemplate/update")]
        public string UpdateEmailTemplate(EmailTemplateForm emailTemplateForm)
        {
            DefaultController defaultController = new DefaultController(EmailTemplateService.Keywords.EMAILTEMPLATE);
            defaultController.FormValidator = new EmailTemplateFormValidator();

            OperationResult result = defaultController.Update(emailTemplateForm);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailtemplate/delete/{idEmailTemplate}")]
        public string DeleteEmailTemplate(string idEmailTemplate)
        {
            IBusinessService businessService = Factory.Create<IBusinessService>("EmailTemplate", ClassType.clsTypeBusinessService);
            OperationResult result = businessService.Delete(idEmailTemplate);
            return Serializer.Json.Serialize(result);
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "emailtemplate/lookups")]
        public string GetLookups()
        {
			Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
		
            OperationResult result = new OperationResult(true, data);
            return Serializer.Json.Serialize(result);
        }
    }
}
