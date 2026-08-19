using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance 
        { 
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set =>instance = value; 
        }

        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "SELECT * FROM dbo.Account WHERE Username = N'"+username+"' AND Password = N'"+password+"'";

            DataTable result = dataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
            
        }
    }
}
