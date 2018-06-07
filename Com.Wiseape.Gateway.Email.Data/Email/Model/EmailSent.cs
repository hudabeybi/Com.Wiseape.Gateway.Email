namespace Com.Wiseape.Gateway.Email.Data.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailSent")]
    public partial class EmailSent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmailSent()
        {
            EmailAttachments = new HashSet<EmailAttachment>();
        }

        [Key]
        public long IdEmailSent { get; set; }

        [StringLength(250)]
        public string SenderName { get; set; }

        [StringLength(250)]
        public string EmailFrom { get; set; }

        [StringLength(250)]
        public string EmailFromAlias { get; set; }

        [Column(TypeName = "text")]
        public string EmailTos { get; set; }

        [Column(TypeName = "text")]
        public string EmailCcs { get; set; }

        [StringLength(250)]
        public string EmailSubject { get; set; }

        [Column(TypeName = "text")]
        public string EmailContent { get; set; }

        public DateTime? SentDate { get; set; }

        public int? IsSent { get; set; }

        public long? UserId { get; set; }

        public long? EmailAccountId { get; set; }

        public string FailReason { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmailAttachment> EmailAttachments { get; set; }
    }
}
