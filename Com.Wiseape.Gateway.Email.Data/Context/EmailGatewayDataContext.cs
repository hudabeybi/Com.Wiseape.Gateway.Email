namespace Com.Wiseape.Gateway.Email.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Com.Wiseape.Gateway.Email.Data.Model;

    public partial class EmailGatewayDataContext : DbContext
    {
        public EmailGatewayDataContext()
            : base("name=EmailGatewayDataContext")
        {
        }

        public virtual DbSet<EmailAttachment> EmailAttachments { get; set; }
        public virtual DbSet<EmailReceiver> EmailReceivers { get; set; }
        public virtual DbSet<EmailSent> EmailSents { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<SenderEmailAccount> SenderEmailAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailAttachment>()
                 .Property(e => e.Filename)
                 .IsUnicode(false);

            modelBuilder.Entity<EmailAttachment>()
                .Property(e => e.FileContent)
                .IsUnicode(false);

            modelBuilder.Entity<EmailReceiver>()
                .Property(e => e.ReceiverName)
                .IsUnicode(false);

            modelBuilder.Entity<EmailReceiver>()
                .Property(e => e.ReceiverEmail)
                .IsUnicode(false);

            modelBuilder.Entity<EmailReceiver>()
                .Property(e => e.ReceiverInfo)
                .IsUnicode(false);

            modelBuilder.Entity<EmailReceiver>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSent>()
                .Property(e => e.SenderName)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSent>()
                .Property(e => e.EmailFrom)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSent>()
                .Property(e => e.EmailFromAlias)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSent>()
                .Property(e => e.EmailTos)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSent>()
                .Property(e => e.EmailCcs)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSent>()
                .Property(e => e.EmailSubject)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSent>()
                .Property(e => e.EmailContent)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSent>()
                .HasMany(e => e.EmailAttachments)
                .WithOptional(e => e.EmailSent)
                .HasForeignKey(e => e.EmailSentId);

            modelBuilder.Entity<EmailSent>()
                .Property(e => e.FailReason)
                .IsUnicode(false);

            modelBuilder.Entity<EmailTemplate>()
                .Property(e => e.EmailSubject)
                .IsUnicode(false);

            modelBuilder.Entity<EmailTemplate>()
                .Property(e => e.EmailContent)
                .IsUnicode(false);

            modelBuilder.Entity<EmailTemplate>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<SenderEmailAccount>()
                .Property(e => e.SenderName)
                .IsUnicode(false);

            modelBuilder.Entity<SenderEmailAccount>()
                .Property(e => e.SenderEmail)
                .IsUnicode(false);

            modelBuilder.Entity<SenderEmailAccount>()
                .Property(e => e.SmtpServer)
                .IsUnicode(false);

            modelBuilder.Entity<SenderEmailAccount>()
                .Property(e => e.EmailAccount)
                .IsUnicode(false);

            modelBuilder.Entity<SenderEmailAccount>()
                .Property(e => e.EmailAccountPassword)
                .IsUnicode(false);

            modelBuilder.Entity<SenderEmailAccount>()
                .Property(e => e.Tag)
                .IsUnicode(false);
        }
    }
}
