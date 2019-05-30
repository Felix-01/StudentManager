using StudentManager.Models;
using StudentManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManager.DAL.Repository
{
    public class UserRepository
    {
        /// <summary>
        /// This method takes in the details of a user attempting to log in
        /// and validates provided credentials against what is in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserViewModel Validate(LoginViewModel model)
        {
            CourseContext context = new CourseContext();
            var user = context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                UserViewModel uvm = new UserViewModel();

                uvm.Username = user.Username;
                uvm.Name = user.Name;
                uvm.Email = user.Email;
                uvm.RoleName = user.RoleName;

                return uvm;
            }
            else
            {
                return null;
            }
        }
        //Add new user
        public void AddUser(UserViewModel model)
        {
            CourseContext context = new CourseContext();

            User user = new User();
            user.Username = model.Username;
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.RoleName = model.RoleName;

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}