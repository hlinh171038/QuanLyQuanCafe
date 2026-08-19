using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class TableDAO
    {
        private static TableDAO instance;

        internal static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private TableDAO() { }

        public static int TableWidth = 90;
        public static int TableHeight = 100;

        public List<Table> LoadTableList()
        {
            List<Table> Tablelist = new List<Table>();

            DataTable data = dataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                Tablelist.Add(table);
            }
            return Tablelist;
        }
    }
}
