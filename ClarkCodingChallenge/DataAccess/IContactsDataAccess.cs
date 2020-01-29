using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarkCodingChallenge.DataAccess
{
	public interface IContactsDataAccess
	{
		List<Contact> GetContactsByLastName(string lastName, bool orderByDefault = true);
		void Add(Contact contact);
		void Remove(Contact contact);
		List<Contact> GetAll(bool orderByDefault = true);
	}
}
