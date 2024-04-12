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
            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            String database = ConfigurationManager.AppSettings["Database"];
            dbConnection = new SqlConnection(String.Format(connectionString, database));
            dataAdapterProjects = new SqlDataAdapter(ConfigurationManager.AppSettings["SelectParent"], dbConnection);
            dataAdapterResources = new SqlDataAdapter(ConfigurationManager.AppSettings["SelectChild"], dbConnection);

            new SqlCommandBuilder(dataAdapterResources);
            new SqlCommandBuilder(dataAdapterProjects).GetInsertCommand();

            dataAdapterProjects.Fill(dataSet, ConfigurationManager.AppSettings["ParentTableName"]);
            dataAdapterResources.Fill(dataSet, ConfigurationManager.AppSettings["ChildTableName"]);

            var dataRelation = new DataRelation(
                ConfigurationManager.AppSettings["ForeignKey"],
                dataSet.Tables[ConfigurationManager.AppSettings["ParentTableName"]].Columns[ConfigurationManager.AppSettings["ParentReferencedKey"]],
                dataSet.Tables[ConfigurationManager.AppSettings["ChildTableName"]].Columns[ConfigurationManager.AppSettings["ChildForeignKey"]]);
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


        public Form1()
        {
            InitializeComponent();
        }
    }
}
