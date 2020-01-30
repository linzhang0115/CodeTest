using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.BusinessLogic
{
	public class ContactsService : IContactsService
	{
		private readonly IContactsDataAccess _contactsDataAccess;

		public ContactsService(IContactsDataAccess contactsDataAccess)
		{
			_contactsDataAccess = contactsDataAccess;
		}

		public List<ContactModel> GetContactsByLastName(string lastName, bool orderByDefault = true)
		{
			var entities = _contactsDataAccess.GetContactsByLastName(lastName, orderByDefault);
			var models = new List<ContactModel>();
			foreach (var entity in entities)
			{
				models.Add(this.convertEntityToModel(entity));
			}

			return models;
		}

		public ContactModel GetContactByEmail(string email)
		{
			var entity = _contactsDataAccess.GetContactByEmail(email);
			if (entity == null)
				return null;
			else
				return this.convertEntityToModel(entity);
		}

		public bool Add(ContactModel model)
		{
			if (string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.Email))
			{
				return false;
			}

			if (GetContactByEmail(model.Email) != null)
			{
				return false;
			}

			if (!this.isValidEmail(model.Email))
			{
				return false;
			}

			_contactsDataAccess.Add(this.convertModelToEntity(model));
			return true;
		}

		private bool isValidEmail(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}

		public bool Remove(string email)
		{
			var contact = _contactsDataAccess.GetContactByEmail(email);
			if (contact == null)
			{
				return false;
			}

			_contactsDataAccess.Remove(contact);
			return true;
		}

		public bool Update(ContactModel model)
		{
			var contact = _contactsDataAccess.GetContactByEmail(model.Email);
			if (contact == null)
			{
				return false;
			}

			contact.LastName = model.LastName;
			contact.FirstName = model.FirstName;			
			return true;
		}

		public List<ContactModel> GetAll(bool orderByDefault = true)
		{
			var entities = _contactsDataAccess.GetAll(orderByDefault);
			var models = new List<ContactModel>();
			foreach (var entity in entities)
			{
				models.Add(this.convertEntityToModel(entity));
			}

			return models;
		}

		private Contact convertModelToEntity(ContactModel model)
		{
			var contact = new Contact();
			if (model == null)
			{
				return contact;
			}
			else
			{
				contact.LastName = model.LastName;
				contact.FirstName = model.FirstName;
				contact.Email = model.Email;
				return contact;
			}
		}

		private ContactModel convertEntityToModel(Contact entity)
		{
			var model = new ContactModel();
			if (entity == null)
			{
				return model;
			}
			else
			{
				model.LastName = entity.LastName;
				model.FirstName = entity.FirstName;
				model.Email = entity.Email;
				return model;
			}
		}
	}
}
