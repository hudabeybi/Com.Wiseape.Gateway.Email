using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.Data.Model;
using Com.Wiseape.Gateway.Email.Data.Repository;
using Com.Wiseape.Gateway.Email.Business.Contracts;
using Com.Wiseape.Utility;
using System.Linq.Expressions;

namespace Com.Wiseape.Gateway.Email.Business.Service
{
    public class EmailSentBusinessService : BaseBusinessService, IEmailSentBusinessService
    {
        public EmailSentBusinessService() : base("EmailSent")
        {
        }

	
		public OperationResult FindAllByEmailFrom(string emailFrom)
		{
			SelectParam selectParam = new SelectParam("EmailFrom.Contains(\"" + emailFrom + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByEmailTos(string emailTos)
		{
			SelectParam selectParam = new SelectParam("EmailTos.Contains(\"" + emailTos + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByEmailSubject(string emailSubject)
		{
			SelectParam selectParam = new SelectParam("EmailSubject.Contains(\"" + emailSubject + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByEmailContent(string emailContent)
		{
			SelectParam selectParam = new SelectParam("EmailContent.Contains(\"" + emailContent + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllBySentDate(DateTime sentDateStart, DateTime sentDateEnd)
		{
			string date1 = sentDateStart.ToString("yyyy-MM-dd hh:mm:ss");
			string date2 = sentDateEnd.ToString("yyyy-MM-dd hh:mm:ss");
			string where = "(SentDate >= Convert.ToDateTime(\"" + date1 + "\") && ";
			where += "SentDate <= Convert.ToDateTime(\"" + date2 + "\") )";

			SelectParam selectParam = new SelectParam(where);
            return this.FindAll(selectParam, null, null);
		}
	

        protected override string GetPredicateByKeyword(string keyword)
        {
            string where = "";
	
			where += "EmailFrom.Contains(\"" + keyword + "\") || ";
	
			where += "EmailTos.Contains(\"" + keyword + "\") || ";
	
			where += "EmailSubject.Contains(\"" + keyword + "\") || ";
	
			where += "EmailContent.Contains(\"" + keyword + "\") || ";
	
			if(where.Length > 3)
				where = where.Substring(0, where.Length - 3);
            return where;
        }

        protected override SelectParam SetAdditionalParameter(SelectParam selectParam)
        {
            selectParam.AddOrderBy("SentDate DESC");
            return selectParam;
        }

    }
}
