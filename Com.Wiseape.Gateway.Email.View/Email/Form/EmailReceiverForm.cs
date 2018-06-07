
/***********************************************************************
* 
* 	File Name: EmailReceiverForm.cs
* 	Created Date: 3/17/2017 3:20:13 PM
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
	* Class Name	: EmailReceiverForm
	* Description	: Form Class for EmailReceiver module.
	*/
	public class EmailReceiverForm : DataForm
	{
	
	
		private Int64 idReceiver;
		public Int64 IdReceiver
		{
			set
			{
				idReceiver = value;
			}
			get
			{
				return idReceiver;
			}
		}
	
		private String receiverName;
		public String ReceiverName
		{
			set
			{
				receiverName = value;
			}
			get
			{
				return receiverName;
			}
		}
	
		private String receiverEmail;
		public String ReceiverEmail
		{
			set
			{
				receiverEmail = value;
			}
			get
			{
				return receiverEmail;
			}
		}
	
		private String receiverInfo;
		public String ReceiverInfo
		{
			set
			{
				receiverInfo = value;
			}
			get
			{
				return receiverInfo;
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
		public EmailReceiverForm()
		{
		}


		//protected properties
	


	}//End of class

	

}

