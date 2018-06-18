using System;
using System.Collections.Generic;

namespace RWAWebForms.Models.Entities
{
    public class User : IComparable<User>
    {
        private static char DELIMITER = '#';

        public int IDUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Telephone { get; set; }
        public Cities City { get; set; }
        public List<Email> Emails { get; set; }

        // override to string
        public override string ToString() => $"{FirstName} {LastName}";

        // parse from file
        public static User ParseFromFile(string line)
        {
            User temp = new User();
            string[] details = line.Split(DELIMITER);
            temp.IDUser = int.Parse(details[0]);
            temp.FirstName = details[1];
            temp.LastName = details[2];
            temp.Password = details[3];
            temp.IsAdmin = bool.Parse(details[4]);
            temp.Telephone = details[5];
            temp.City = (Cities)Enum.Parse(typeof(Cities), details[6]);
            temp.Emails = Email.ParseFromFile(details[7]);
            return temp;
        }

        // format for file
        public string FormatForFile()
        {
            return $"{IDUser}{DELIMITER}{FirstName}{DELIMITER}{LastName}{DELIMITER}{Password}{DELIMITER}{IsAdmin.ToString()}{DELIMITER}{Telephone}{DELIMITER}{City.ToString()}{DELIMITER}";
        }

        // compare to
        public int CompareTo(User other)
        {
            if (other is User)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            else
            {
                return -1;
            }
        }
    }
}