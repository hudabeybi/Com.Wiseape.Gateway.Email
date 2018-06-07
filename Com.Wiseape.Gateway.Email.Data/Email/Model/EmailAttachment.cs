namespace Com.Wiseape.Gateway.Email.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailAttachment")]
    public partial class EmailAttachment
    {
        [Key]
        public long IdEmailAttachment { get; set; }

        [StringLength(250)]
        public string Filename { get; set; }

        [Column(TypeName = "text")]
        public string FileContent { get; set; }

        public long? EmailSentId { get; set; }

        public virtual EmailSent EmailSent { get; set; }
    }
}
