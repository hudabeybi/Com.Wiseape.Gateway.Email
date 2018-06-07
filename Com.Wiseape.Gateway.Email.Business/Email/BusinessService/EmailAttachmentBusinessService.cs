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
    public class EmailAttachmentBusinessService : BaseBusinessService, IEmailAttachmentBusinessService
    {
        public EmailAttachmentBusinessService() : base("EmailAttachment")
        {
        }

        public OperationResult FindAllByFilename(string filename)
        {
            SelectParam param = new SelectParam("Filename.Contains(\"" + filename + "\")");
            return FindAll(param, null, null);
        }

        protected override string GetPredicateByKeyword(string keyword)
        {
            string where = "";
	
			where += "Filename.Contains(\"" + keyword + "\") || ";

	
			if(where.Length > 3)
				where = where.Substring(0, where.Length - 3);
            return where;
        }

    }
}
