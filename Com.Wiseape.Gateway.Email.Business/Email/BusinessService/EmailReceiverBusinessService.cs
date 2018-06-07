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
    public class EmailReceiverBusinessService : BaseBusinessService, IEmailReceiverBusinessService
    {
        public EmailReceiverBusinessService() : base("EmailReceiver")
        {
        }

	
		public OperationResult FindAllByReceiverName(string receiverName)
		{
			SelectParam selectParam = new SelectParam("ReceiverName.Contains(\"" + receiverName + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByReceiverEmail(string receiverEmail)
		{
			SelectParam selectParam = new SelectParam("ReceiverEmail.Contains(\"" + receiverEmail + "\")");
            return this.FindAll(selectParam, null, null);			
		}
	
		public OperationResult FindAllByReceiverInfo(string receiverInfo)
		{
			SelectParam selectParam = new SelectParam("ReceiverInfo.Contains(\"" + receiverInfo + "\")");
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
	
			where += "ReceiverName.Contains(\"" + keyword + "\") || ";
	
			where += "ReceiverEmail.Contains(\"" + keyword + "\") || ";
	
			where += "ReceiverInfo.Contains(\"" + keyword + "\") || ";
	
			where += "Tag.Contains(\"" + keyword + "\") || ";
	
			if(where.Length > 3)
				where = where.Substring(0, where.Length - 3);
            return where;
        }

    }
}
