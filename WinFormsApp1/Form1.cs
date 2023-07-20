using System.Data;
using System.Data.SqlClient;
namespace WinFormsApp1
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Practice;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            //Insert
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Employees values('" + textBox1.Text + "','" + textBox2.Text + "')", con);
            int i = cmd.ExecuteNonQuery(); //that donot return any table/table values
            MessageBox.Show(i + " Data Saved");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            con.Open();
            SqlCommand cmd = new SqlCommand("update Employees set EName='" + textBox1.Text + "',Department='" + textBox2.Text + "' where Id=" + textBox3.Text, con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show(i + " Data Updated");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Employees where Id=" + textBox3.Text, con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show(i + " Data Deleted");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Search Name
            con.Open();
            SqlCommand cmd = new SqlCommand("select EName from Employees where Id=" + textBox3.Text, con);
            string? s = Convert.ToString(cmd.ExecuteScalar());
            MessageBox.Show("Employee Name: " + s);
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Search Employee
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Employees where Id="+textBox3.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Employee Name: " + dr[1].ToString()+"\n Employee Dept: " + dr["Department"].ToString()); ;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            //View
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Employees", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Search Dept
            con.Open();
            SqlCommand cmd = new SqlCommand("select Department from Employees where Id=" + textBox3.Text, con);
            string s = Convert.ToString(cmd.ExecuteScalar());
            MessageBox.Show("Employee Department: " + s);
            con.Close();
        }
    }
}