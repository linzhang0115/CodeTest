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
		void Add(ContactModel model);
		void Remove(ContactModel model);
		List<ContactModel> GetAll(bool orderByDefault = true);
	}
}
