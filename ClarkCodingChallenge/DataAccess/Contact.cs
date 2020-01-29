using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarkCodingChallenge.DataAccess
{
	public class Contact
	{
		public Contact()
		{
		}

		public Contact(string lastName, string firstName, string email)
		{
			LastName = lastName;
			FirstName = firstName;
			Email = email;
		}
		[Required]
		public string LastName { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string Email { get; set; }
	}
}
