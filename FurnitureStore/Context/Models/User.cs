﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context.Models
{
	public class User
	{
		public Guid Id { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public Guid UserClaimsId { get; set; }

		public string UserRole { get; set; }
	}
}