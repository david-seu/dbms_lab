using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        private DataSet dataSet = new DataSet();
        private SqlConnection dbConnection;

        private SqlDataAdapter dataAdapterProjects, dataAdapterResources;
        private readonly BindingSource bindingProjects = new BindingSource();
        private readonly BindingSource bindingResources = new BindingSource();


        private void InitializeDatabase()
        {
            String connectionString = " ";
            String database = "app";
            dbConnection = new SqlConnection(String.Format(connectionString, database));
            dataAdapterProjects = new SqlDataAdapter("select * from areas", dbConnection);
            dataAdapterResources = new SqlDataAdapter("select * from projects", dbConnection);

            new SqlCommandBuilder(dataAdapterResources);
            new SqlCommandBuilder(dataAdapterProjects);

            dataAdapterProjects.Fill(dataSet, "areas");
            dataAdapterResources.Fill(dataSet, "projects");

            var dataRelation = new DataRelation(
                "fk_area",
                dataSet.Tables["areas"].Columns["area_id"],
                dataSet.Tables["projects"].Columns["area_id"]);
            dataSet.Relations.Add(dataRelation);
        }

        private void InitializeUI()
        {
            bindingProjects.DataSource = dataSet;
            bindingProjects.DataMember = ConfigurationManager.AppSettings["ParentTableName"];

            bindingResources.DataSource = bindingProjects;
            bindingResources.DataMember = ConfigurationManager.AppSettings["ForeignKey"];

            dataGridProjects.DataSource = bindingProjects;
            dataGridResources.DataSource = bindingResources;
        }

        private void buttonUpdateDB_Click(object sender, EventArgs e)
        {
            dataAdapterResources.Update(dataSet, ConfigurationManager.AppSettings["ChildTableName"]);
            dataAdapterProjects.Update(dataSet, ConfigurationManager.AppSettings["ParentTableName"]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            InitializeUI();
        }

        private void buttonRefreshDB_Click(object sender, EventArgs e)
        {
            dataSet.Tables[ConfigurationManager.AppSettings["ChildTableName"]].Clear();
            dataSet.Tables[ConfigurationManager.AppSettings["ParentTableName"]].Clear();
            dataAdapterProjects.Fill(dataSet, ConfigurationManager.AppSettings["ParentTableName"]);
            dataAdapterResources.Fill(dataSet, ConfigurationManager.AppSettings["ChildTableName"]);
        }


        private void buttonDeleteDB_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridResources.CurrentCell.RowIndex;
            dataGridResources.Rows.RemoveAt(rowIndex);
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
