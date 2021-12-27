using CardManagerBackend.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CardManagerBackend.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastPasswordChange { get; set; }
        public bool IsAdmin { get; set; }



        public void ChangePassword(string password)
        {
            HashedPassword = Hasher.HashPassword(password);
            LastPasswordChange = DateTime.UtcNow;
        }

        public bool CheckLoginCredentials(string email, string password) {

            Debug.WriteLine(Hasher.HashPassword(password) + " = " + HashedPassword);
            if (Hasher.VerifyPassword(HashedPassword, password) && email == Email) {
                return true;
            }
            return false;
        }
    }
}
