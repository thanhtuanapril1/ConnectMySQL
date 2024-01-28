using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;

namespace WindowsFormsApplication1
{
    public partial class FormMySQL : Form
    {
        //Initial variable
        static string connStr = "server=localhost;port=3306;user=root;password=OTM159357!;database=studentinformation;";
        MySqlConnection conn = new MySqlConnection(connStr);
        public FormMySQL()
        {
            InitializeComponent();
        }


        /*      SUB PROGRAM     */
        void viewGridData()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from Student", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }
        void ClearTextbox()
        {
            tbID.Clear();
            tbRegNo.Clear();
            tbStudentName.Clear();
            tbAddress.Clear();
        }
        void Sql_Command(String SqlCmd)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(SqlCmd, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Command Successfully!");
            }
            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }

        }
        /*    END SUB PROGRAM   */
        private void FormMySQL_Load(object sender, EventArgs e)
        {
            //viewGridData();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            viewGridData();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbID.Text))
            {
                String insert = "insert into student (Id,RegNo,student,address) value('"
                    + tbID.Text + "','" + tbRegNo.Text + "','" + tbStudentName.Text + "','" + tbAddress.Text + "' )";
                Sql_Command(insert);
                //For datagrid
                viewGridData();
                ClearTextbox();
            }
            
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            String update = "update student set Regno = '" + tbRegNo.Text + "',student='" + tbStudentName.Text + "',address= '"
                    + tbAddress.Text + "' where id =" + tbID.Text + " ";
            Sql_Command(update);
            //For datagrid
            viewGridData();
            ClearTextbox();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

            String delete = "delete from student where id ='" + tbID.Text + "';";
            Sql_Command(delete);
            //For datagrid
            viewGridData();
            ClearTextbox();
        }
            
    }
}
