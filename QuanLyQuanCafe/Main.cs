using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            LoadTable();
        }

        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height =TableDAO.TableHeight };
                btn.Text = item.Name +Environment.NewLine + item.Status;
                btn.Click += btnTable_Click;
                // tag để lưu thông tin bàn vào button, khi click vào button sẽ lấy thông tin bàn từ tag , kiểu dữ liệu object nên cần ép kiểu về Table
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Available":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lvsBill.Items.Clear();
            List<BillInfo> listBillInfo = BillInfoDAO.Instance.getListBillInfo(BillDAO.Instance.GetUncheckBillIDByTableID(id));

            foreach (BillInfo item in listBillInfo) 
            {
                ListViewItem lsvItem = new ListViewItem(item.IdFood.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
               
                lvsBill.Items.Add(lsvItem);
            }
        }


        private void btnTable_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            ShowBill(tableID);
        }

        private void mnDiscount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void personalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccount f = new fAccount();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }
    }
}
