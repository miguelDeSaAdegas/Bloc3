using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exo_semaine1.domaine
{
    [Serializable]
    public class Person  
    {


    private static readonly long serialVersionUID = 1L;

    private readonly String name;
	private readonly String firstname;
	private readonly DateTime birthDate;
	
	public virtual String GetName()
    {
        return name;
    }

    public String GetFirstname()
    {
        return firstname;
    }

    public DateTime GetBirthDate()
    {
            return new DateTime();
    }


    public Person(String name, String firstname, DateTime birthDate)
    {
        this.name = name;
        this.firstname = firstname;
        this.birthDate = birthDate;
    }

    public override String ToString()
    {
        return "Person [name = " + name + ", firstname = " + firstname + ", birthDate =  " + GetBirthDate() + "]";
    }


}
}
