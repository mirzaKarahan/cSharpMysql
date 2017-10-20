using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace csharpProje
{
    public class DataBase
    {

        public MySqlConnection mysqlCon = null;

        public Boolean OpenCon(){
            mysqlCon = new MySqlConnection("Server=Server;Database=database;Uid=username;Pwd='password';");
            try
            {
                mysqlCon.Open();
                if (mysqlCon.State != ConnectionState.Closed)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Connection Error!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hata! " + err.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        public void urunEkle(String table,String columns,String values)
        {
            String query = "INSERT INTO "+table+" ("+columns+") VALUES ("+values+")";

            try
            {
                if (this.OpenCon())
                {
                    MySqlCommand command = new MySqlCommand(query,mysqlCon);
                    command.ExecuteNonQuery();
                    mysqlCon.Close();
                }
            }
            catch{}
        }

        public void urunSil(String table, String where)
        {
            String query = "DELETE FROM "+table+" WHERE "+where;

            try
            {
                if (this.OpenCon())
                {
                    MySqlCommand command = new MySqlCommand(query, mysqlCon);
                    command.ExecuteNonQuery();
                    mysqlCon.Close();
                }
            }
            catch
            {
                mysqlCon.Close();
            }
        }

        public void urunGuncelle(String table,String set, String where)
        {
            String query = "UPDATE "+table+" SET "+set+" WHERE "+where;

            try
            {
                if (this.OpenCon())
                {
                    MySqlCommand command = new MySqlCommand(query, mysqlCon);
                    command.ExecuteNonQuery();
                    mysqlCon.Close();
                }
            }
            catch
            {
                mysqlCon.Close();
            }
        }

        public DataTable urunGetir(String table, String where)
        {
            String query = "SELECT * FROM " + table +" WHERE "+where;
            DataTable table = new DataTable();
            try
            {
                if (this.OpenCon())
                {
                    MySqlCommand command = new MySqlCommand(query, mysqlCon);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(table);
                    return table;
                    mysqlCon.Close();
                }
            }
            catch
            {
            
            }
            return table;
        }

        public DataTable urunGetir(String table)
        {
            String query = "SELECT * FROM " + table;
            DataTable table = new DataTable();
            try
            {
                if (this.OpenCon())
                {
                    MySqlCommand command = new MySqlCommand(query, mysqlCon);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(table);
                    mysqlCon.Close();
                    return table;
                }
            }
            catch
            {
                mysqlCon.Close();
            }
            return table;
        }

        public DataTable urunGetir(String table,String where,String like)
        {
            String query = "SELECT * FROM " + table+" WHERE "+where+" LIKE '%"+like+"%'";
            DataTable table = new DataTable();
            try
            {
                if (this.OpenCon())
                {
                    MySqlCommand command = new MySqlCommand(query, mysqlCon);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(table);
                    mysqlCon.Close();
                    return table;
                }
            }
            catch
            {
                mysqlCon.Close();
            }
            return table;
        }

    }
}
