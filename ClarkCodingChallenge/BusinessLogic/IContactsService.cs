using ClarkCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarkCodingChallenge.BusinessLogic
{
	public interface IContactsService
	{
		List<ContactModel> GetContactsByLastName(string lastName, bool orderByDefault = true);
		ContactModel GetContactByEmail(string email);
		bool Add(ContactModel model);
		bool Remove(string email);
		List<ContactModel> GetAll(bool orderByDefault = true);
	}
}
