using System;
using Microsoft.EntityFrameworkCore;
using StudentsChecker.Models;
using StudentsControl;
using StudentsControl.Models;

namespace StudentsChecker.Repositories
{
	public class SubjectRepository
	{
		private readonly ApplicationContext Context;
		public SubjectRepository(ApplicationContext context)
		{
			Context = context;
		}
		public IEnumerable<SubjectStudent> GetSubjectsByGroup(string Group)
        {
			return Context.SubjectStudent.
				 Include(x => x.Student)
				.Include(x=>x.Subject)
                .ThenInclude(x=>x.Teachers)
				.Where(x => x.Student.Group.Name == Group)
				.Select(x=>x)
				;
        }

        internal void UpdateMany(IEnumerable<SubjectStudent> subjectStudents)
        {
			
			Context.SubjectStudent.UpdateRange(subjectStudents);
			Context.SaveChanges();
        }

        internal bool StatementContainId(int id)
        {
            return Context.SubjectStudent.Any(x=>x.Id==id);
        }

        internal SubjectStudent? Update(SubjectStudent currentStatement,bool isNew)
        {
            if (isNew)
            {
                Context.SubjectStudent.Add(currentStatement);
            }
            else
            {
                Context.SubjectStudent.Update(currentStatement);
            }
           
           Context.SaveChanges();
            return Context.SubjectStudent
                .Include(x=>x.Student)
                .Include(x=>x.Subject)
                .FirstOrDefault(x=>x.Student.Id==currentStatement.Student.Id&&x.Subject.Id==currentStatement.Subject.Id);
        }

        internal List<Subject> GroupSubject(string group)
        {
            return Context.Subjects.Include(x=>x.Teachers).Where(x => x.Groups.Any(x => x.Name == group) ).Select(x=>x).ToList();
        }

        internal SubjectStudent? FindByParams(Subject subject, Student student)
        {


            SubjectStudent? Statement= Context.SubjectStudent.FirstOrDefault(x => x.Student == student && x.Subject == subject);
            return Statement;
             
        }

        internal Subject FindById(int subjectId)
        {
            return Context.Subjects.First(x=>x.Id==subjectId);
        }

        internal Teacher GetTeacherById(int teacherId)
        {
            return Context.Teachers.FirstOrDefault(x=>x.Id==teacherId);
        }
    }
}

