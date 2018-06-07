
/***********************************************************************
* 
* 	File Name: EmailSentForm.cs
* 	Created Date: 3/17/2017 3:20:16 PM
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
	* Class Name	: EmailSentForm
	* Description	: Form Class for EmailSent module.
	*/
	public class EmailSentForm : DataForm
	{
	
	
		private Int64 idEmailSent;
		public Int64 IdEmailSent
		{
			set
			{
				idEmailSent = value;
			}
			get
			{
				return idEmailSent;
			}
		}
	
		private String emailFrom;
		public String EmailFrom
		{
			set
			{
				emailFrom = value;
			}
			get
			{
				return emailFrom;
			}
		}
	
		private String emailTos;
		public String EmailTos
		{
			set
			{
				emailTos = value;
			}
			get
			{
				return emailTos;
			}
		}
	
		private String emailSubject;
		public String EmailSubject
		{
			set
			{
				emailSubject = value;
			}
			get
			{
				return emailSubject;
			}
		}
	
		private String emailContent;
		public String EmailContent
		{
			set
			{
				emailContent = value;
			}
			get
			{
				return emailContent;
			}
		}
	
		private DateTime sentDate;
		public DateTime SentDate
		{
			set
			{
				sentDate = value;
			}
			get
			{
				return sentDate;
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

        public SenderEmailAccountForm SenderEmailAccountForm { get; set; }

        /* Constructor */
        public EmailSentForm()
		{
		}


		//protected properties
	


	}//End of class

	

}

