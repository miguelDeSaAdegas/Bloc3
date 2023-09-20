// See https://aka.ms/new-console-template for more information
using LINQDataContext;

DataContext dc = new DataContext();

Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{
    Console.WriteLine(jdepp.Last_Name + " " + jdepp.First_Name + "\n");
}


var querry22 = dc.Students.Select(s => new { 
    nom = s.Last_Name + " " + s.First_Name,
    id = s.Student_ID,
    naissance = s.BirthDate
});

foreach (var student in querry22)
{
    Console.WriteLine(student + "\n");
}

var query31 = dc.Students.Select(s => new
{
    nom = s.Last_Name,
    yearResult = s.Year_Result,
    status = s.Year_Result > 11 ? "OK" : "KO"
});

foreach (var student in query31)
{
    Console.WriteLine(student + "\n");
}

var quary34 = dc.Students.
    Where(s => s.Year_Result < 4).
    OrderByDescending(s => s.Year_Result).
    Select(s => new
{
    nom = s.First_Name,
    resultat = s.Year_Result
});

foreach (var student in quary34)
{
    Console.WriteLine(student + "\n");
}
