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
using System.Diagnostics;

namespace DataBaseGUI
{
    public partial class DBGUI : Form
    {
        string ConnectionName = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C# saves\\DataBaseGUI\\DataBaseGUI\\TelecomCompany.mdf;Integrated Security=True";
        SqlConnection con;
        Add AddForm = new Add();
        public DBGUI()
        {
            InitializeComponent();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                AddForm.Show();
            }
            else { MessageBox.Show("Please Connect To DataBase"); }
            
            
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(Image.FromFile(@"D:\\C# saves\\DataBaseGUI\\Databaseicon5.png"));
            con = new SqlConnection(ConnectionName);
            con.Open();

            ////////////////
           
            DataTable t = con.GetSchema("Tables");
            if (ConnectTreeView.Nodes.Count <= 0 )
            {
                ConnectTreeView.Nodes.Add(t.ToString());
                foreach (DataRow row in t.Rows)
                {
                    if ((string)row[2] == "Customers" || (string)row[2] == "Phone_Plans" || (string)row[2] == "Employees" || (string)row[2] == "Sites")
                    {
                        ConnectTreeView.Nodes[0].Nodes.Add((string)row[2]);
                    }
                    ConnectTreeView.ImageList = myImageList;
                }
            }
            ////////////////        
        }
        private void ConnectTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionName))
            {
                string sqlQuery = "SELECT * from "+e.Node.Text+"";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            ConnectTreeView.Nodes.Clear();
            con.Close();
            Debug.WriteLine("connection terminated");
            dataGridView1.DataSource = "null";
        }

       
    }
}
