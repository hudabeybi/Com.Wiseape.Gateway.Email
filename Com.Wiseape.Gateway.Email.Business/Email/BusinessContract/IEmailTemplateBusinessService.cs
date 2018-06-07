using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Utility;
using Com.Wiseape.Gateway.Email.Data.Model;

namespace Com.Wiseape.Gateway.Email.Business.Contracts
{
    public interface IEmailTemplateBusinessService
    {
	
		OperationResult FindAllByEmailSubject(string emailSubject);
	
		OperationResult FindAllByTag(string tag);
	
    }
}
