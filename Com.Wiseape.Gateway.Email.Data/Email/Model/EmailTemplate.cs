namespace Com.Wiseape.Gateway.Email.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailTemplate")]
    public partial class EmailTemplate
    {
        [Key]
        public long IdEmailTemplate { get; set; }

        [StringLength(250)]
        public string EmailSubject { get; set; }

        [Column(TypeName = "text")]
        public string EmailContent { get; set; }

        [StringLength(50)]
        public string Tag { get; set; }

        public long UserId { get; set; }

        public int? IsActive { get; set; }
    }
}
