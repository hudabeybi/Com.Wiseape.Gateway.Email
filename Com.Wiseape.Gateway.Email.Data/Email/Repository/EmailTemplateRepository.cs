using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Com.Wiseape.Framework;
using Com.Wiseape.Gateway.Email.Data.Model;

namespace Com.Wiseape.Gateway.Email.Data.Repository
{
    public class EmailTemplateRepository : BaseRepository<EmailTemplate>
    {
        public EmailTemplateRepository() : base("EmailTemplate")
        {
        }
    }
}
