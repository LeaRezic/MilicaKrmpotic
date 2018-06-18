using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RWAWebForms.Models.Entities;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace RWAWebForms.Models.DAL
{
    public class DBRepo : IRepo
    {

        string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        // ------------------------- JAVNE METODE -------------------------
        public void AddUser(User u)
        {
            DataSet ds = SqlHelper.ExecuteDataset(cs, "InsertUser", u.FirstName, u.LastName, u.Password, u.Telephone, u.City.ToString(), u.IsAdmin ? "Administrator" : "User");
            DataTable tblNoviId = ds.Tables[0];
            DataRow rowNoviId = tblNoviId.Rows[0];
            int newUserId;
            newUserId = (int)rowNoviId[0];
            foreach (Email e in u.Emails)
            {
                SqlHelper.ExecuteNonQuery(cs, "InsertEmail", newUserId, e.UserName);
            }
        }

        public List<User> GetUsers()
        {
            List<User> allUsers = new List<User>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetUsersFull");
            DataTable tblUsers = ds.Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                User temp = new User();
                temp.IDUser = (int)row["IDUser"];
                temp.FirstName = row["FirstName"].ToString();
                temp.LastName = row["LastName"].ToString();
                temp.Password = row["Password"].ToString();
                temp.Telephone = row["Telephone"].ToString();
                temp.City = (Cities)Enum.Parse(typeof(Cities), row["City"].ToString());
                temp.IsAdmin = row["Status"].ToString() == "Administrator";
                temp.Emails = GetEmails(temp.IDUser);
                allUsers.Add(temp);
            }
            return allUsers;
        }

        public User GetUser(int idUser)
        {
            User temp = null;
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetUserFull", idUser);
            DataTable tblUsers = ds.Tables[0];
            if (ds.Tables[0].Rows.Count != 0)
            {
                temp = new User();
                var row = ds.Tables[0].Rows[0];
                temp.IDUser = (int)row["IDUser"];
                temp.FirstName = row["FirstName"].ToString();
                temp.LastName = row["LastName"].ToString();
                temp.Password = row["Password"].ToString();
                temp.Telephone = row["Telephone"].ToString();
                temp.City = (Cities)Enum.Parse(typeof(Cities), row["City"].ToString());
                temp.IsAdmin = row["Status"].ToString() == "Administrator";
                temp.Emails = GetEmails(temp.IDUser);
            }
            return temp;
        }

        public List<Email> GetEmails(int idUser)
        {
            List<Email> listOfEmails = new List<Email>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetEmailsForUser", idUser);
            DataTable tblUsers = ds.Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                Email temp = new Email();
                temp.IDEmail = (int)row["IDEmail"];
                temp.UserName = row["UserName"].ToString();
                listOfEmails.Add(temp);
            }
            return listOfEmails;
        }

        public List<Email> GetEmails()
        {
            List<Email> allEmails = new List<Email>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetAllEmails");
            DataTable tblUsers = ds.Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                Email temp = new Email();
                temp.IDEmail = (int)row["IDEmail"];
                temp.UserName = row["UserName"].ToString();
                allEmails.Add(temp);
            }
            return allEmails;
        }

        public void DeleteUser(User u)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteUser", u.IDUser);
        }

        public void UpdateUser(User u)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateUser", u.IDUser, u.FirstName, u.LastName, u.Password, u.Telephone, u.City.ToString(), u.IsAdmin ? "Administrator" : "User");
            foreach (Email e in u.Emails)
            {
                SqlHelper.ExecuteNonQuery(cs, "UpdateEmail", e.IDEmail, e.UserName);
            }
        }

        // TESTTEST TEST TEST TEST TEST
        //public DataSet GetDataSet()
        //{
        //    DataSet ds = SqlHelper.ExecuteDataset(cs, "GetUsersFull");
        //    return ds;
        //}

        //public void AddUser(User u)
        //{
        //    SqlParameter[] Params = new SqlParameter[7];
        //    Params[0] = new SqlParameter("@firstName", u.FirstName);
        //    Params[1] = new SqlParameter("@lastName", u.LastName);
        //    Params[2] = new SqlParameter("@password", u.Password);
        //    Params[3] = new SqlParameter("@telephone", u.Telephone);
        //    Params[4] = new SqlParameter("@city", u.City.ToString());
        //    Params[5] = new SqlParameter("@status", u.IsAdmin ? "Administrator" : "User");
        //    Params[6] = new SqlParameter("@noviId", SqlDbType.Int);
        //    Params[6].Direction = ParameterDirection.Output;
        //    SqlHelper.ExecuteNonQuery(cs, "InsertUser", Params);
        //    //string newUserId = Params[6].Value.ToString();
        //    int newId = int.Parse(newUserId);
        //    foreach (Email e in u.Emails)
        //    {
        //        SqlHelper.ExecuteNonQuery(cs, "InsertEmail", newUserId, e.UserName);
        //    }
        //}
    }
}