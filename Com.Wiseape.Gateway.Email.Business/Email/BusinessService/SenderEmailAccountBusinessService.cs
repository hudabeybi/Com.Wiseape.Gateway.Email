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
    public class SenderEmailAccountBusinessService : BaseBusinessService, ISenderEmailAccountBusinessService
    {
        public SenderEmailAccountBusinessService() : base("SenderEmailAccount")
        {
        }

	
		public OperationResult FindAllBySenderName(string senderName)
		{
			SelectParam selectParam = new SelectParam("SenderName.Contains(\"" + senderName + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllBySenderEmail(string senderEmail)
		{
			SelectParam selectParam = new SelectParam("SenderEmail.Contains(\"" + senderEmail + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllBySmtpServer(string smtpServer)
		{
			SelectParam selectParam = new SelectParam("SmtpServer.Contains(\"" + smtpServer + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByEmailAccount(string emailAccount)
		{
			SelectParam selectParam = new SelectParam("EmailAccount.Contains(\"" + emailAccount + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByEmailAccountPassword(string emailAccountPassword)
		{
			SelectParam selectParam = new SelectParam("EmailAccountPassword.Contains(\"" + emailAccountPassword + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	

        protected override string GetPredicateByKeyword(string keyword)
        {
            string where = "";
	
			where += "SenderName.Contains(\"" + keyword + "\") || ";
	
			where += "SenderEmail.Contains(\"" + keyword + "\") || ";
	
			where += "SmtpServer.Contains(\"" + keyword + "\") || ";
	
			where += "EmailAccount.Contains(\"" + keyword + "\") || ";
	
			where += "EmailAccountPassword.Contains(\"" + keyword + "\") || ";
	
			if(where.Length > 3)
				where = where.Substring(0, where.Length - 3);
            return where;
        }

        public OperationResult FindAllByTag(string tag)
        {
            SelectParam selectParam = new SelectParam("Tag.Contains(\"" + tag + "\")");
            return this.FindAll(selectParam, null, null);
        }
    }
}
