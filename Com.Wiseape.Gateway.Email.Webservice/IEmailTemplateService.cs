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
    public interface IEmailTemplateService
    {

        [OperationContract]
        string FindEmailTemplateList(string keyword, string page, string size);

        [OperationContract]
        string GetEmailTemplate(string idEmailTemplate);

        [OperationContract]
        string AddEmailTemplate(EmailTemplateForm emailTemplateForm);

        [OperationContract]
        string UpdateEmailTemplate(EmailTemplateForm emailTemplateForm);

        [OperationContract]
        string DeleteEmailTemplate(string idEmailTemplate);

		[OperationContract]
        string GetLookups();

    }
}
