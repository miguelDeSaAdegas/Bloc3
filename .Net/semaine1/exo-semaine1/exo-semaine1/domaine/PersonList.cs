using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_semaine1.domaine
{
    public class PersonList
    {

        private static PersonList instance;
        private IDictionary<String, Person> personMap;

        private PersonList()
        {
            personMap = new Dictionary<String, Person>();
        }

        public static PersonList getInstance()
        {

            if (instance == null)
                instance = new PersonList();

            return instance;
        }

        public void addPerson(Person person)
        {
            if (person == null)
                throw new InvalidParameterException();
            personMap.Add(person.GetName(), person);
        }

        public IEnumerator<Person> personList()
        {
            return personMap.Values.GetEnumerator();
        }
    }
}
