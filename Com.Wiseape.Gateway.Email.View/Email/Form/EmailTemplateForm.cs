
/***********************************************************************
* 
* 	File Name: EmailTemplateForm.cs
* 	Created Date: 3/17/2017 3:20:10 PM
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
	* Class Name	: EmailTemplateForm
	* Description	: Form Class for EmailTemplate module.
	*/
	public class EmailTemplateForm : DataForm
	{
	
	
		private Int64 idEmailTemplate;
		public Int64 IdEmailTemplate
		{
			set
			{
				idEmailTemplate = value;
			}
			get
			{
				return idEmailTemplate;
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
	
		private String tag;
		public String Tag
		{
			set
			{
				tag = value;
			}
			get
			{
				return tag;
			}
		}
	
		/* Constructor */
		public EmailTemplateForm()
		{
		}


		//protected properties
	


	}//End of class

	

}

