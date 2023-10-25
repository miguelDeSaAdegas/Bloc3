// See https://aka.ms/new-console-template for more information

using SchoolApp.Models;
using SchoolApp.Repository;
using System.Collections;

SchoolContext context = new SchoolContext();

BaseRepositorySQL<Section> repoSect = new BaseRepositorySQL<Section>(context);
BaseRepositorySQL<Student> repoStud = new BaseRepositorySQL<Student>(context);

Section sectInfo = new Section { Name = "Info"};
repoSect.Save(sectInfo, s => s.Name.Equals(sectInfo.Name));
Section sectDiet = new Section { Name = "Diet" };
repoSect.Save(sectDiet, s => s.Name.Equals(sectDiet.Name));

IList<Section> sections = repoSect.GetAll().ToList();

foreach (Section section in sections)
{
    Console.WriteLine(section.Name);
}

Student studinfo1 = new Student();
studinfo1.Name = "de sa adegas";
studinfo1.Firstname = "miguel";
studinfo1.YearResult = 100;
studinfo1.Section = sectInfo;

Student studdiet = new Student();
studdiet.Name = "Vandeputte";
studdiet.Firstname = "françois";
studdiet.YearResult = 120;
studdiet.Section = sectDiet;

Student studinfo2 = new Student();
studinfo2.Name = "lapinski";
studinfo2.Firstname = "Damien";
studinfo2.YearResult = 110;
studinfo2.Section = sectInfo;

repoStud.Save(studinfo1, s => s.Name.Equals(studinfo1.Name) && s.Firstname.Equals(studinfo1.Firstname));
repoStud.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));
repoStud.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));



IList<Student> list = repoStud.GetAll();

foreach (Student ele in list)
{
    Console.WriteLine(ele.Name);
}