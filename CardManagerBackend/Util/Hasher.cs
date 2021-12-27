using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CardManagerBackend.Util
{
    public class Hasher
    {
        static PasswordHasher hasher = new PasswordHasher();
        public static string HashPassword(string password)
        {
            return hasher.HashPassword(password);
        }
        public static bool VerifyPassword(string hashedPassword, string passwordToCheck)
        {
            int result = (int)hasher.VerifyHashedPassword(hashedPassword, passwordToCheck);
            if ( result == 1)
                return true;
            return false;
        }

    }
}
