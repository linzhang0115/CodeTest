﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarkCodingChallenge.Models
{
	public class ContactModel
	{
		[Required]
		public string LastName { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string Email { get; set; }
	}
}
