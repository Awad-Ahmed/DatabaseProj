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
    public partial class Add : Form
    {
        string ConnectionName = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C# saves\\DataBaseGUI\\DataBaseGUI\\TelecomCompany.mdf;Integrated Security=True";
        SqlConnection con;
        
        public Add()
        {
           
            InitializeComponent();
        }
        // get the the sequence of primary keys
        public int GetRowsCount(string tablename)
        {
            string stmt = "SELECT COUNT(*) FROM "+tablename;
            int count = 0;

            
                using (SqlCommand CmdCount = new SqlCommand(stmt, con))
                {
                  
                    count = (int)CmdCount.ExecuteScalar();
                }
            
            return count;
        }
        //get foreign key
       public string GetForeignKey(string colname,string value,string tablename,string colkey )
        {
            string stmt = "SELECT "+colkey+ " FROM " +tablename+" where "+colname+"='"+value+"'";
            string ForeignKey;


            using (SqlCommand CmdCount = new SqlCommand(stmt, con))
            {
                
                SqlDataReader dr = CmdCount.ExecuteReader();

                dr.Read();

               ForeignKey =  dr[colkey].ToString();      
                      
                dr.Close();
            }

            
            return ForeignKey;
        }
        private void Add_Shown(object sender, EventArgs e)
        {
            con = new SqlConnection(ConnectionName);
            con.Open();
        }
        //handling data retrieval 
        private void PlanNameCHKBX_CheckedChanged(object sender, EventArgs e)
        {
            if (PlanNameCHKBX.Checked == true)
            {
                PlanNameCMBBX.Visible = true;
                

                //////
                string Plannamesql = "select [PP Name] from Phone_Plans";

                SqlCommand Plannamecmd = new SqlCommand(Plannamesql, con);


                SqlDataReader dr = Plannamecmd.ExecuteReader();
                PlanNameCMBBX.Items.Clear();
                while (dr.Read())
                {


                    PlanNameCMBBX.Items.Add(dr["PP Name"].ToString());

                }
                dr.Close();
                //////// 
            }
            else
            {
                BillingMethodCMBX.Visible = false; 
            }

        }
        private void BillingMethodCHKBX_CheckedChanged(object sender, EventArgs e)
        {
            if (BillingMethodCHKBX.Checked == true)
            {
                BillingMethodCMBX.Visible = true;
               

                //////
                string PostPaidsql = "select B_METHOD from Billing";

                SqlCommand Billingcmd = new SqlCommand(PostPaidsql, con);


                SqlDataReader dr = Billingcmd.ExecuteReader();
                BillingMethodCMBX.Items.Clear();
                while (dr.Read())
                {
                   
                        BillingMethodCMBX.Items.Add(dr["B_METHOD"].ToString());
                    
                }
                dr.Close();
                //////// 
            }
            else { BillingMethodCMBX.Visible = false;  
            }
        }
        private void FacilityBTN_Click(object sender, EventArgs e)
        {
            FacilityCMBBX.Visible = true;
            //////
            string Facilitysql = "select [Branch Name] from Facilities";

            SqlCommand Facilitycmd = new SqlCommand(Facilitysql, con);
            SqlDataReader dr = Facilitycmd.ExecuteReader();
            FacilityCMBBX.Items.Clear();
            while (dr.Read())
            {

                FacilityCMBBX.Items.Add(dr["Branch Name"].ToString());

            }
            dr.Close();
        }
        private void ChooseDPBTN_Click(object sender, EventArgs e)
        {
            DepartmentCMBBX.Visible = true;
            //////
            string Departmentsql = "select D_Name from Departments";

            SqlCommand Departmentcmd = new SqlCommand(Departmentsql, con);
            SqlDataReader dr = Departmentcmd.ExecuteReader();
            DepartmentCMBBX.Items.Clear();
            while (dr.Read())
            {

                DepartmentCMBBX.Items.Add(dr["D_Name"].ToString());

            }
            dr.Close();
            ////////
        }//
        //Adding the values
        private void CustomerADDBTN_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            
            int phonenum = 01000000000;
            phonenum += GetRowsCount("Customers");
            string GetPP_NO = GetForeignKey("[PP Name]",PlanNameCMBBX.Text,"Phone_Plans","PP_NO");
            string GetB_ID = GetForeignKey("[B_METHOD]", BillingMethodCMBX.Text, "Billing", "B_ID");
            string Values = string.Format("VALUES ({0}, '{1}',' {2}', '{3}','{4}',{5},{6})",phonenum,
                                                   C_FirstNameTXTBX.Text,C_LastNameTXTBX.Text
                                                   ,C_SSNTXTBX.Text,C_AddressTXTBX.Text,GetB_ID,GetPP_NO);
            string Custinsertsql = 
                "Insert Into Customers ( C_Phone_No, C_FirstName , C_LastName, C_SSN, C_Address, B_ID, PP_No)"
               + Values;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Custinsertsql;
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException m)
            { MessageBox.Show(m.Message); }

        }
        private void EmployeeADDBTN_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();

            int E_ID ;
            E_ID = GetRowsCount("Employees");
            string GetDP_NO = GetForeignKey("D_Name", DepartmentCMBBX.Text, "Departments", "D_ID");
            
            string Values = string.Format("VALUES ({0}, '{1}',' {2}', '{3}','{4}',{5},{6})", E_ID,
                                                   E_FirstNameTXTBX.Text, E_LastNameTXTBX.Text
                                                   , E_SSNTXTBX.Text, E_AddressTXTBX.Text,"GetDate()",GetDP_NO);
            string Einsertsql =
                "Insert Into Employees ( E_ID, E_FirstName , E_LastName, E_SSN, E_Address, since ,FK_Dep_ID)"
               + Values;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Einsertsql;
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException m)
            { MessageBox.Show(m.Message); }
        }
        private void PPADDBTN_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = con.CreateCommand();

            int PP_NO;
            PP_NO = GetRowsCount("Phone_Plans")+1;
           

            string Values = string.Format("VALUES ({0}, '{1}','{2}')", PP_NO,
                                                   PhonePlanNMETXTBX.Text, PhonePlanPriceTXTBX.Text
                                                   );
            string Einsertsql =
                "Insert Into Phone_Plans ( PP_NO, [PP Name] , [PP Price])"
               + Values;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Einsertsql;
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException m)
            { MessageBox.Show(m.Message); }
        }
        private void SitesADDBTN_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            int SITE_ID;
            SITE_ID = GetRowsCount("Sites");
            string FK_F_ID = GetForeignKey("[Branch Name]", FacilityCMBBX.Text, "Facilities", "F_ID");

            string Values = string.Format("VALUES ({0}, {1},{2}, '{3}')",SITE_ID,
                                                   "GetDate()", FK_F_ID
                                                   , SiteLocationTXTBX.Text);
            string Einsertsql =
                "Insert Into Sites ( SITE_ID, Last_Check , FK_F_ID, Location)"
               + Values;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Einsertsql;
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException m)
            { MessageBox.Show(m.Message); }

        }
        //
        //Closing the form
        private void Add_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                //con.Close();
                Add.ActiveForm.Hide();
            }
        }     
    }
}
