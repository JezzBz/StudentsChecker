using System;
using Microsoft.EntityFrameworkCore;
using StudentsControl;
using StudentsControl.Models;

namespace StudentsChecker.Repositories
{
	public class StudentsRepository
	{
		private readonly ApplicationContext Context;
		public StudentsRepository(ApplicationContext context)
		{
			Context = context;
		}
		public IEnumerable<Student> GetAll()
		{
            return Context.Students.Include(x=>x.Group).OrderBy(x => x.Group).Select(x => x);

		}

		public IEnumerable<Group> GetGroups()
        {
			return Context.Groups.Select(x=>x);
        }

        internal void UpdateMany(IEnumerable<Student> students)
        {

			Context.Students.UpdateRange(students);
        }

        internal void CreateTestUsers()
        {
                    
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });
                    Context.Students.Add(new Student { Attendance = 100, IsStuding = "Обучается", Group=Context.Groups.FirstOrDefault() , Fcs = "!!!ФИО СТУДЕНТА!!!" });


            Context.SaveChanges();
            
        }

        internal void SaveChanges()
        {
			Context.SaveChanges();
        }

        internal IEnumerable<Student> GetStudentsByGroup(string Group)
        {
			return Context.Students.Where(x=>x.Group.Name == Group).Select(x => x);
        }

        internal Student FindById(int id)
        {
            return Context.Students.Include(x=>x.SubjectStudent).First(x=>x.Id==id);
        }

        internal void Recalculation(Student student,SubjectStudent statement)
        {
            Context.SubjectStudent.Update(statement);
            var Statements = Context.SubjectStudent.Include(x=>x.Subject).Where(x => x.Student.Id == student.Id).Select(x=>x).ToList();
            student.Attendance = ( Statements.Sum(x => x.VisitTime)/Statements.Select(x=>x.Subject.Time).Sum())*100;
            if (student.Attendance<50||(statement.Mark==2&&(statement.Type== TestType.Pass||statement.Type==TestType.PassA)))
            {
                student.Admitted = false;
                student.IsStuding = "Представлен к отчислению";
            }
            if (!student.SubjectStudent.Any(x=>x.Mark<3)&&student.Attendance>50)
            {
                student.Admitted = true;
                student.IsStuding = "Продолжает обучение";
            }
            Context.Students.Update(student);
            Context.SaveChanges();
        }
    }
   
}

