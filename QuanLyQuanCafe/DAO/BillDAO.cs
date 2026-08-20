using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        { get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
          private set => BillDAO.instance = value;
        }

        private BillDAO() 
        { }

        // success: return bill id, fail: return -1
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = dataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable =" + id + " and status =0");

            if ( data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
    }
}
