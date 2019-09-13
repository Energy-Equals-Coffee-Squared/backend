using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        UserdbmlDataContext db = new UserdbmlDataContext();

        public UserDetails LoginUser(string username, string password)
        {
            dynamic query = (from u in db.Users
                             where (u.email.Equals(username) || u.username.Equals(username)) && u.password.Equals(password)
                             select u).FirstOrDefault();

            if (query == null)
            {
                return null;
            }
            else
            {
                var usr = new UserDetails
                {
                    id = query.Id,
                    username = query.username,
                    email = query.email,
                    first_name = query.first_name,
                    last_name = query.last_name,
                    contact_number = query.contact_number,
                    created_at = query.created_at,
                    updated_at = query.updated_at,
                    isActive = Convert.ToBoolean(query.isActive),
                    isAdmin = Convert.ToBoolean(query.isAdmin),
                    isDeleted = Convert.ToBoolean(query.isDeleted)
                };

                return usr;
            }
        }

        public bool RegisterUser(string username, string email, string password, string rptPassword,
            string first_name, string last_name, string contact_number)
        {
            var NewUser = new User
            {
                username = username,
                email = email,
                first_name = first_name,
                last_name = last_name,
                password = password,
                contact_number = contact_number,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                isActive = 1,
                isAdmin = 0,
                isDeleted = 0
            };
            db.Users.InsertOnSubmit(NewUser);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }
    }
}
