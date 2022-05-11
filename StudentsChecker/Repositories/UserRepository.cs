using System;

using StudentsControl;
using StudentsControl.Models;

namespace StudentsChecker.Repositories
{
    public class UserRepository 
    {
        private   readonly ApplicationContext Context;

        public UserRepository(ApplicationContext context)
        {
            Context=context;
        }

       public User? FindUser(string? passwordHasah, string Fcs)
        {
            return Context.Users.FirstOrDefault(x=>x.PasswordHash==passwordHasah&&x.Fcs==Fcs);
        }

       
    }
}

