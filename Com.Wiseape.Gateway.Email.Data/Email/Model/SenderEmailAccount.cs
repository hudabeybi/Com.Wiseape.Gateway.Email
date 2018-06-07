namespace Com.Wiseape.Gateway.Email.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SenderEmailAccount")]
    public partial class SenderEmailAccount
    {
        [Key]
        public long IdSender { get; set; }

        [StringLength(250)]
        public string SenderName { get; set; }

        [StringLength(250)]
        public string SenderEmail { get; set; }

        [StringLength(250)]
        public string SmtpServer { get; set; }

        public int? SmtpPort { get; set; }

        public int? EnableSsl { get; set; }

        [StringLength(250)]
        public string EmailAccount { get; set; }

        [Column(TypeName = "text")]
        public string EmailAccountPassword { get; set; }

        public int? IsDefault { get; set; }

        public long UserId { get; set; }

        [StringLength(50)]
        public string Tag { get; set; }

        public int? IsActive { get; set; }
    }
}
