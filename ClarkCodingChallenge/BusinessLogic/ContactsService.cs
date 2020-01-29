using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService: IContactsService
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

        public void Add(ContactModel model)
        {
            _contactsDataAccess.Add(this.convertModelToEntity(model));
        }

        public void Remove(ContactModel model)
        {
            _contactsDataAccess.Remove(this.convertModelToEntity(model));
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
