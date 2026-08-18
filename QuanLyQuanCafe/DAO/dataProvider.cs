using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class dataProvider
    {
       private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanlyQuanCafe;Integrated Security=True;Encrypt=False";


        public DataTable ExecuteQuery(string query , object[] paramater = null )
        {
            DataTable data = new DataTable();
            // 1. connection to database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach ( string para in listPara)
                    {
                        if(para.Contains('@'))
                        {
                            command.Parameters.AddWithValue(para, paramater[i]);
                            i++;
                        }
                    }
                }                   
                
                
                SqlDataAdapter adapter = new SqlDataAdapter(command); //this is the line where everything happens. The query is sent, SQL Server executes it, rows come back, and data gets filled. Every line before this was just preparation.
                adapter.Fill(data);

                connection.Close();
            }

            

            return data;
        }
        
    }
}
