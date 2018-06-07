using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Utility;
using Com.Wiseape.Gateway.Email.Data.Model;

namespace Com.Wiseape.Gateway.Email.Business.Contracts
{
    public interface IEmailSentBusinessService
    {
	
		OperationResult FindAllByEmailFrom(string emailFrom);
	
		OperationResult FindAllByEmailTos(string emailTos);
	
		OperationResult FindAllByEmailSubject(string emailSubject);
	
		OperationResult FindAllByEmailContent(string emailContent);
	
		OperationResult FindAllBySentDate(DateTime sentDateStart, DateTime sentDateEnd);
	
    }
}
