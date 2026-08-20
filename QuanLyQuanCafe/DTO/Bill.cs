using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {

        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
        }

        // take row from dataTable and convert to bill object
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];

            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            var dateCheckoutValue = row["dateCheckOut"];
            if(dateCheckoutValue.ToString() != "")     
                this.DateCheckOut = (DateTime?)dateCheckoutValue;
            this.Status = (int)row["status"];
        }
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }

        private DateTime? dateCheckOut;

        private int status;
        public int Status { get => status; set => status = value; }
    }
}
