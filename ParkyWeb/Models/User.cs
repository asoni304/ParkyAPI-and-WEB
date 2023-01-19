﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkyWeb.Models
{
	public class User
	{
		public string Name { get; set; }
		public string Username { get; set; }

		public string Password { get; set; }
		public string Role { get; set; }

		public string Token { get; set; }

		
	}
}
