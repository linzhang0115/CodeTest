using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess: IContactsDataAccess
    {
        public static List<Contact> Contacts;

        public List<Contact> GetContactsByLastName(string lastName, bool orderByDefault = true)
        {
            this.initilizeData();
            var contacts = Contacts.Where(c => c.LastName == lastName);
            if (orderByDefault)
            {
                return contacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList(); 
            }
            else
            {
                return contacts.OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName).ToList();
            }
        }

        public Contact GetContactByEmail(string email)
        {
            this.initilizeData();
            return Contacts.FirstOrDefault(c => c.Email == email);
        }

        public void Add(Contact contact)
        {            
            Contacts.Add(contact);
        }

        public void Remove(Contact contact)
        {
            this.initilizeData();
            Contacts.Remove(contact);
        }

        public List<Contact> GetAll(bool orderByDefault = true)
        {
            this.initilizeData();

            if (orderByDefault)
            {
                return Contacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
            }
            else
            {
                return Contacts.OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName).ToList();
            }
        }  

        private void initilizeData()
        {
            if (Contacts == null)
            {
                Contacts = new List<Contact>();
            }

            if (!Contacts.Any())
            {
                Contacts.Add(new Contact("Meyer", "Ryan", "r@email.com"));
                Contacts.Add(new Contact("Zhang", "Lin", "l@email.com"));
                Contacts.Add(new Contact("Sun", "Yang", "y@email.com"));
            }
        }
    }
}
