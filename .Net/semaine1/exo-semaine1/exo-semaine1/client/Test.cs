using exo_semaine1.domaine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_semaine1.client
{
    internal class Test
    {
        public static void Main(String[] args)
        {

            Actor[] myActors =  {
                new Actor( "Assange", "Julian", new DateTime(1961, 6, 3), 187),
                new Actor( "Paul", "Newmann", new DateTime(1925, 0, 26), 187),
                new Actor( "Becker", "Norma Jean", new DateTime(1926, 5, 1), 187)
        };

            Director[] myDirectors = {
                // month start 0
                new Director("Spielberg", "Steven", new DateTime(1946, 11, 18)),
                new Director("Coen", "Ettan", new DateTime(1957, 8, 21)),
                new Director("Coppolla", "Francis Ford", new DateTime(1939, 3, 7))
        };


            Movie bigLebow = new Movie("The Big Lebowski", 1996);
            Movie eT = new Movie("E.T.", 1982);

            eT.AddActor(myActors[0]);
            eT.AddActor(myActors[2]);
            eT.Director = myDirectors[0];

            bigLebow.AddActor(myActors[1]);
            bigLebow.AddActor(myActors[2]);
            bigLebow.Director = myDirectors[1];

            PersonList myPersons = PersonList.getInstance();

            foreach (Actor act in myActors)
            {
                myPersons.addPerson(act);
            }

            foreach (Director director in myDirectors)
            {
                myPersons.addPerson(director);
            }

            IEnumerator<Person> ActorIt = myPersons.personList();
            while (ActorIt.MoveNext())
            {
                Person person = ActorIt.Current;
                Console.WriteLine(person);

                IEnumerator<Movie> MoviesIt;

                if (person is Actor)
                {
                    Console.WriteLine("a jouÃ© dans les films suivants ");
                    MoviesIt = ((Actor)person).Movies();
                }
                else
                {
                    if (person is Director)
                    {
                        Console.WriteLine("a dirigÃ© les films suivants :");
                        MoviesIt = ((Director)person).Movies();
                    }
                    else
                    {
                        Console.WriteLine("est inconnu et n'a rien Ã  faire ici !!! ");
                        continue;
                    }
                }
                while (MoviesIt.MoveNext())
                {
                    Movie Movie = MoviesIt.Current;
                    Console.WriteLine(Movie);
                }

            }
        }
    }
}
