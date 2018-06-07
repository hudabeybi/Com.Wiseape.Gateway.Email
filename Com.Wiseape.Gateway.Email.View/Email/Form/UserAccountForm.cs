
/***********************************************************************
* 
* 	File Name: UserAccountForm.cs
* 	Created Date: 3/17/2017 3:20:05 PM
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
	* Class Name	: UserAccountForm
	* Description	: Form Class for UserAccount module.
	*/
	public class UserAccountForm : DataForm
	{
	
	
		private Int64 idUser;
		public Int64 IdUser
		{
			set
			{
				idUser = value;
			}
			get
			{
				return idUser;
			}
		}
	
		private String firstName;
		public String FirstName
		{
			set
			{
				firstName = value;
			}
			get
			{
				return firstName;
			}
		}
	
		private String lastName;
		public String LastName
		{
			set
			{
				lastName = value;
			}
			get
			{
				return lastName;
			}
		}
	
		private DateTime registerDate;
		public DateTime RegisterDate
		{
			set
			{
				registerDate = value;
			}
			get
			{
				return registerDate;
			}
		}
	
		private String username;
		public String Username
		{
			set
			{
				username = value;
			}
			get
			{
				return username;
			}
		}
	
		private String password;
		public String Password
		{
			set
			{
				password = value;
			}
			get
			{
				return password;
			}
		}
	
		private String appName;
		public String AppName
		{
			set
			{
				appName = value;
			}
			get
			{
				return appName;
			}
		}
	
		private String appToken;
		public String AppToken
		{
			set
			{
				appToken = value;
			}
			get
			{
				return appToken;
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
	
		/* Constructor */
		public UserAccountForm()
		{
		}


		//protected properties
	


	}//End of class

	

}

