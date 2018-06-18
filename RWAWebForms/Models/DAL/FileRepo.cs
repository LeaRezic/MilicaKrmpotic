using System;
using System.Collections.Generic;
using System.Linq;
using RWAWebForms.Models.Entities;
using System.IO;
using System.Text;

namespace RWAWebForms.Models.DAL
{
    public class FileRepo : IRepo
    {
        // neke interne stvari
        public static string PATH = @"C:\Users\Lea\Documents\Algebra\IV Semestar\RWA\RWA_WebFormsProject_LeaRezic\RWAWebForms\App_Data\Data.txt";

        // u konstruktoru stvori file ak već ne postoji
        public FileRepo()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        // -------------------------------------- JAVNE METODE  --------------------------------------
        // DODAVANJE USERA preko ENTITETA iz APLIKACIJE (kreira ga KK)
        public void AddUser(User u)
        {
            u.IDUser = GetNextUserID();
            int nextEmailID = GetNextEmailID();
            foreach (Email email in u.Emails)
            {
                email.IDEmail = nextEmailID++;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(FormatLineForFile(u));
            sb.Append(Environment.NewLine);
            File.AppendAllText(PATH, sb.ToString());
        }

        // UPDATE USERA (kojigod podatak)
        public void UpdateUser(User u)
        {
            List<User> allUsers = GetUsers();
            User userToUpdate = allUsers.Find(x => x.IDUser == u.IDUser);
            userToUpdate.FirstName = u.FirstName;
            userToUpdate.LastName = u.LastName;
            userToUpdate.Password = u.Password;
            userToUpdate.IsAdmin = u.IsAdmin;
            userToUpdate.Telephone = u.Telephone;
            userToUpdate.City = u.City;
            userToUpdate.Emails = u.Emails;
            WriteDataFromList(allUsers);
        }

        // BRISANJE USERA
        public void DeleteUser(User u)
        {
            List<User> usersWithoutDeletedUser = new List<User>();
            foreach (User user in GetUsers())
            {
                if (user.IDUser != u.IDUser)
                {
                    usersWithoutDeletedUser.Add(user);
                }
            }
            WriteDataFromList(usersWithoutDeletedUser);
        }

        // DOHVAĆANJE SVIH ILI JEDNOG USERA
        // svi useri
        public List<User> GetUsers()
        {
            List<User> allUsers = new List<User>();
            try
            {
                string[] data = File.ReadAllLines(PATH);
                //List<User> allUsers = new List<User>();
                data.ToList().ForEach(u => allUsers.Add(User.ParseFromFile(u)));
            }
            catch
            {
                throw new Exception("Failed to read the file repository.");
            }
            return allUsers;
        }
        // jedan user
        public User GetUser(int idUser)
        {
            return GetUsers().Find(x => x.IDUser == idUser);
        }

        // DOHVAĆANJE SVIH ILI NEKIH MAILOVA
        // svi mailovi
        public List<Email> GetEmails()
        {
            List<Email> emailList = new List<Email>();
            foreach (User user in GetUsers())
            {
                emailList.AddRange(user.Emails);
            }
            return emailList;
        }
        // mailovi za nekog usera
        public List<Email> GetEmails(int idUser)
        {
            return new List<Email>(GetUser(idUser).Emails);
        }

        // -------------------------------------- HELPER PRIVATNE METODE  --------------------------------------
        // TRAŽI NOVE ID-EVE
        // za usere
        private int GetNextUserID()
        {
            int highestID = 0;
            foreach (User user in GetUsers())
            {
                if (user.IDUser > highestID)
                {
                    highestID = user.IDUser;
                }
            }
            return ++highestID;
        }
        // za emajlove
        private int GetNextEmailID()
        {
            int highestID = 0;
            foreach (Email email in GetEmails())
            {
                if (email.IDEmail > highestID)
                {
                    highestID = email.IDEmail;
                }
            }
            return ++highestID;
        }
        
        // FORMATIRA USERA - svi podaci - ZA FILE (spaja User.formatFF i njegove Email.formatFF)
        private string FormatLineForFile(User u)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(u.FormatForFile());
            foreach (Email e in u.Emails)
            {
                sb.Append(e.FormatForFile());
            }
            return sb.ToString();
        }

        // ZAPISUJE sve LINIJE na file, od LISTE USERA
        private void WriteDataFromList(List<User> allUsers)
        {
            List<string> allUserLines = new List<string>();
            allUsers.ForEach(x => allUserLines.Add(FormatLineForFile(x)));
            File.WriteAllLines(PATH, allUserLines.ToArray());
        }
        
    }
}