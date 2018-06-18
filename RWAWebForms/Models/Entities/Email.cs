using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWAWebForms.Models.Entities
{
    public class Email //: IComparable
    {
        private static char EMAIL_DELIMITER = '|';
        private static char EMAIL_DETAILS_DELIMITER = ';';

        public int IDEmail { get; set; }
        public string UserName { get; set; }

        // format for file
        public string FormatForFile()
        {
            return $"{IDEmail}{EMAIL_DETAILS_DELIMITER}{UserName}{EMAIL_DELIMITER}";
        }
        // kraće
        public static List<Email> ParseFromFile(string line)
        {
            List<Email> emailList = new List<Email>();
            string[] emails = line.Split(EMAIL_DELIMITER);
            foreach (string email in emails)
            {
                string[] details = email.Split(EMAIL_DETAILS_DELIMITER);
                if (details.Count() <= 1)
                {
                    return emailList;
                }
                Email temp = new Email();
                temp.IDEmail = int.Parse(details[0]);
                temp.UserName = details[1];
                emailList.Add(temp);
            }
            return emailList;
        }

        public override string ToString() => $"{UserName}";
    }
}