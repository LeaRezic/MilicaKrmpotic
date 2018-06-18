using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWAWebForms.Models.DAL
{
    public class RepoFactory
    {
        
        public static IRepo GetDefaultInstance()
        {
            return new DBRepo();
        }

        //// ili ovek
        public static IRepo GetChosenRepo(string whichRepo = "2")
        {
            if (whichRepo != "2")
            {
                return new FileRepo();
            }
            else
            {
                return new DBRepo();
            }
        }
    }
}