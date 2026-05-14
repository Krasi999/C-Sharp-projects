using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Name
        {
            get { return _user.Name; }
            set { _user.Name = value; }
        }

        public string Password
        {
            get { return _user.Password; }
            set { _user.Password = value; }
        }

        public string FacNumber
        {
            get { return _user.FacNumber; }
            set { _user.FacNumber = value; }
        }

        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

        public UserRolesEnum Role
        {
            get { return _user.Role; }
            set { _user.Role = value; }
        }

        public int Id
        {
            get { return _user.Id; }
            set { _user.Id = value; }
        }

        public DateTime Expires
        {
            get { return _user.Expires; }
            set { _user.Expires = value; }
        }
    }
}
