using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.Data.Model;

namespace Com.Wiseape.Gateway.Email.Data.Repository
{
    public class EmailReceiverRepository : BaseRepository<EmailReceiver>
    {
        public EmailReceiverRepository() : base("EmailReceiver")
        {
        }
    }
}
