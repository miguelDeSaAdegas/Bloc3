// See https://aka.ms/new-console-template for more information

using SchoolApp.Models;
using SchoolApp.Repository;
using System.Collections;

SchoolContext context = new SchoolContext();

BaseRepositorySQL<Student> repoStudent = new BaseRepositorySQL<Student>(context);

Student eleve = new Student();
eleve.Name = "de sa adegas";
eleve.YearResult = 1;
eleve.Firstname = "miguel";


repoStudent.Insert(eleve);

IList<Student> list = repoStudent.GetAll();

foreach (Student ele in list)
{
    Console.WriteLine(ele.Name);
}