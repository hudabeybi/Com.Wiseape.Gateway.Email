
/***********************************************************************
* 
* 	File Name: SenderEmailAccountForm.cs
* 	Created Date: 3/17/2017 3:20:07 PM
* 
* **********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Wiseape.Framework;

namespace Com.Wiseape.Gateway.Email.View.Form
{
	/*
	* Class Name	: SenderEmailAccountForm
	* Description	: Form Class for SenderEmailAccount module.
	*/
	public class SenderEmailAccountForm : DataForm
	{
	
	
		private Int64 idSender;
		public Int64 IdSender
		{
			set
			{
				idSender = value;
			}
			get
			{
				return idSender;
			}
		}
	
		private String senderName;
		public String SenderName
		{
			set
			{
				senderName = value;
			}
			get
			{
				return senderName;
			}
		}
	
		private String senderEmail;
		public String SenderEmail
		{
			set
			{
				senderEmail = value;
			}
			get
			{
				return senderEmail;
			}
		}
	
		private String smtpServer;
		public String SmtpServer
		{
			set
			{
				smtpServer = value;
			}
			get
			{
				return smtpServer;
			}
		}
	
		private Int32 smtpPort;
		public Int32 SmtpPort
		{
			set
			{
				smtpPort = value;
			}
			get
			{
				return smtpPort;
			}
		}
	
		private Int32 enableSsl;
		public Int32 EnableSsl
		{
			set
			{
				enableSsl = value;
			}
			get
			{
				return enableSsl;
			}
		}
	
		private String emailAccount;
		public String EmailAccount
		{
			set
			{
				emailAccount = value;
			}
			get
			{
				return emailAccount;
			}
		}
	
		private String emailAccountPassword;
		public String EmailAccountPassword
		{
			set
			{
				emailAccountPassword = value;
			}
			get
			{
				return emailAccountPassword;
			}
		}
	
		private bool isDefault;
		public bool IsDefault
		{
			set
			{
				isDefault = value;
			}
			get
			{
				return isDefault;
			}
		}
	
		private Int64 userId;
		public Int64 UserId
		{
			set
			{
				userId = value;
			}
			get
			{
				return userId;
			}
		}
	
		private bool isActive;
		public bool IsActive
		{
			set
			{
				isActive = value;
			}
			get
			{
				return isActive;
			}
		}

        public string Tag { get; set; }



        /* Constructor */
        public SenderEmailAccountForm()
		{
		}


		//protected properties
	


	}//End of class

	

}

