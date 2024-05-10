using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace connect_to_sql
{
    public partial class Form1 : Form
    {
        string connectionstring = "Data Source=LENOVO\\SQLEXPRESS;" +
               "Initial Catalog=PracticeDB;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void bnt_save_click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_fName.Text))
                {
                    MessageBox.Show("Enter the name");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_id.Text))
                {
                    MessageBox.Show("Enter the Id");
                    return;
                }
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                string firstname = txt_fName.Text;
                string id = this.txt_id.Text;
                string query = "insert into users (id,[name]) values('" + firstname + "','" + id + "')";
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved");
                clear_form();
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
        private void clear_form()
        {
            txt_fName.Text = "";
            txt_id.Text = "";

        }
    }
}
