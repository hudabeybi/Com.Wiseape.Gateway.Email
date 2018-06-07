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
    public class EmailTemplateBusinessService : BaseBusinessService, IEmailTemplateBusinessService
    {
        public EmailTemplateBusinessService() : base("EmailTemplate")
        {
        }

	
		public OperationResult FindAllByEmailSubject(string emailSubject)
		{
			SelectParam selectParam = new SelectParam("EmailSubject.Contains(\"" + emailSubject + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByTag(string tag)
		{
			SelectParam selectParam = new SelectParam("Tag.Contains(\"" + tag + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	

        protected override string GetPredicateByKeyword(string keyword)
        {
            string where = "";
	
			where += "EmailSubject.Contains(\"" + keyword + "\") || ";
	
			where += "Tag.Contains(\"" + keyword + "\") || ";
	
			if(where.Length > 3)
				where = where.Substring(0, where.Length - 3);
            return where;
        }

    }
}
