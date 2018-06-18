using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWAWebForms.Models
{
    public static class PasswordManager
    {
        private static string SALT = "%so!";

        public static string CreateHash(string password)
        {
            string saltedPwd = password + SALT;
            byte[] saltedPwdBytes = System.Text.Encoding.ASCII.GetBytes(saltedPwd);
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes = md5.ComputeHash(saltedPwdBytes);
            string hash = Convert.ToBase64String(hashedBytes);
            return hash;
        }

        public static bool IsMatchingHash(string password, string hash)
        {
            return CreateHash(password) == hash;
        }
    }
}