using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace dbms_lab_app
{
    public partial class Form1 : Form
    {

        SqlConnection conn;
        SqlDataAdapter daResources;
        SqlDataAdapter daProjects;
        DataSet ds;
        BindingSource bsResources;
        BindingSource bsProjects;

        SqlCommandBuilder cmdBuilder;

        string queryResources = "SELECT * FROM resources";
        string queryProjects = "SELECT * FROM projects";

        public Form1()
        {
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            conn = new SqlConnection("Data Source=Roger;Initial Catalog=app;Integrated Security=True");

            daResources = new SqlDataAdapter(queryResources, conn);
            daProjects = new SqlDataAdapter(queryProjects, conn);

            ds = new DataSet();

            daResources.Fill(ds, "resources");
            daProjects.Fill(ds, "projects");

            cmdBuilder = new SqlCommandBuilder(daResources);

            ds.Relations.Add("Projects_Resources",
                ds.Tables["projects"].Columns["project_id"],
                ds.Tables["resources"].Columns["project_id"]);

            this.dataGridView1.DataSource = ds.Tables["projects"];
            this.dataGridView2.DataSource = this.dataGridView1.DataSource;
            this.dataGridView1.DataMember = "Projects_Resources";

            cmdBuilder.GetUpdateCommand();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            daResources.Update(ds, "resources");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            cmdBuilder = new SqlCommandBuilder(daResources);
            cmdBuilder.GetInsertCommand();
            daResources.Update(ds, "resources");
            daProjects.Update(ds, "projects");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            daResources.Update(ds, "resources");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
