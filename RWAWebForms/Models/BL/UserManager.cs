using RWAWebForms.Models.DAL;
using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RWAWebForms.Models.BL
{
    public class UserManager
    {

        public IRepo repo { get; set; }

        public UserManager(string chosenRepo)
        {
            repo = RepoFactory.GetChosenRepo(chosenRepo);
        }

        public UserManager()
        {
            repo = RepoFactory.GetDefaultInstance();
        }

        // -------------------------------------- JAVNE METODE  --------------------------------------
        // DODAVANJE NOVOG USERA KAO ENTITETA
        public void AddUserFromInput(User user)
        {
            foreach (Email email in user.Emails)
            {
                // baci grešku ako nije unique email neki
                if (!IsEmailUnique(email.UserName))
                {
                    throw new Exception("Email must be unique!");
                }
            }
            repo.AddUser(user);
        }

        // dohvati sve mailove, ako postoji takav mail i useru je taj password, vraća čru
        public User GetUserByEmail(string email)
        {
            foreach (User user in repo.GetUsers())
            {
                if (user.Emails.Exists(x => x.UserName == email))
                {
                    return user;
                }
            }
            return null;
        }

        // UPDATENJE USERA
        public void UpdateUser(User u)
        {
            repo.UpdateUser(u);
        }

        // BRISANJE USERA
        public void DeleteUser(User u)
        {
            repo.DeleteUser(u);
        }

        // DOHVAĆANJE SVIH PODATAKA
        public List<User> GetUsers()
        {
            List<User> allUsers = new List<User>(repo.GetUsers());
            allUsers.Sort();
            return allUsers;
        }

        // DOHVAĆANJE JEDNOG USERA
        public User GetUser(int idUser)
        {
            return repo.GetUser(idUser);
        }

        // -------------------------------------- PRIVATNE METODE  --------------------------------------

        // DOHVAĆANJE SVIH MAILOVA
        private List<Email> GetEmails(int idUser)
        {
            // tu mogu još neki sort nabacit?
            return new List<Email>(repo.GetEmails(idUser));
        }

        // -------------------------------------- HELPER (isto PRIVATNE) METODE  --------------------------------------
        // POSTOJI LI VEĆ TAKI MAIL
        private bool IsEmailUnique(string userName)
        {
            if (repo.GetEmails().Exists(x => x.UserName == userName))
            {
                return false;
            }
            return true;
        }

        


    }
}