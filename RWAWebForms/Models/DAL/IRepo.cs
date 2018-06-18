using RWAWebForms.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWAWebForms.Models.DAL
{
    public interface IRepo
    {
        User GetUser(int idUser);
        List<User> GetUsers();
        List<Email> GetEmails(int idUser);
        List<Email> GetEmails();
        //int AddUser(string firstName, string lastName, string password, bool isAdmin, string telephone, string city);
        void AddUser(User u);
        //void AddEmail(string userName, int userId);
        //void AddEmail(Email e);
        void UpdateUser(User u);
        //void UpdateEmail(Email e);
        void DeleteUser(User u);
        //void DeleteEmail(Email e);

        // TEST TEST TEST
        //DataSet GetDataSet();

    }
}
