namespace Com.Wiseape.Gateway.Email.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailReceiver")]
    public partial class EmailReceiver
    {
        [Key]
        public long IdReceiver { get; set; }

        [StringLength(250)]
        public string ReceiverName { get; set; }

        [StringLength(250)]
        public string ReceiverEmail { get; set; }

        [Column(TypeName = "text")]
        public string ReceiverInfo { get; set; }

        public long? UserId { get; set; }

        [StringLength(50)]
        public string Tag { get; set; }
    }
}
