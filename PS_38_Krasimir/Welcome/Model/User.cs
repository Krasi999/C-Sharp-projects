using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public string Name { get; set; }

        private string _password;

        public string Password
        {
            get => Decrypt(_password);
            set => _password = Encrypt(value);
        }

        public string FacNumber {  get; set; }

        public string Email { get; set; }

        public UserRolesEnum Role { get; set; }

        private string Encrypt(string plainText)
        {
            if (plainText == null) return null;
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(bytes);
        }

        private string Decrypt(string encryptedText)
        {
            if (encryptedText == null) return null;
            byte[] bytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(bytes);
        }

        private int _id;
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _expires;

        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
    }
}
