using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Printing;

namespace wineStore
{
    public partial class Form1 : Form
    {

        private DataSet dataSet = new DataSet();
        private SqlConnection sqlConnection;

        private SqlDataAdapter dataAdapterProducers, dataAdapterWines;
        private readonly BindingSource bindingProducers = new BindingSource();
        private readonly BindingSource bindingWines = new BindingSource();

        public void Form1_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            InitializeUI();
        }

        private void InitializeDatabase()
        {
            String connectionString = "Data Source=ROGER;Initial Catalog=wine_store;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            dataAdapterProducers = new SqlDataAdapter("SELECT * FROM producers", sqlConnection);
            dataAdapterWines = new SqlDataAdapter("SELECT * FROM wines", sqlConnection);

            dataAdapterProducers.Fill(dataSet, "producers");
            dataAdapterWines.Fill(dataSet, "wines");

            var relation = new DataRelation("fk_producers", dataSet.Tables["producers"].Columns["p_id"], dataSet.Tables["wines"].Columns["p_id"]);
            dataSet.Relations.Add(relation);
        }

        private void InitializeUI()
        {
            bindingProducers.DataSource = dataSet;
            bindingProducers.DataMember = "producers";

            bindingWines.DataSource = bindingProducers;
            bindingWines.DataMember = "fk_producers";

            listBox1.DataSource = bindingProducers;
            listBox1.DisplayMember = "name";
            dgvWines.DataSource = bindingWines;
        }

        public Form1() => InitializeComponent();

        private void saveButton_Click(object sender, EventArgs e)
        {
            _ = new SqlCommandBuilder(dataAdapterWines);
            dataAdapterWines.Update(dataSet, "wines");
            dataAdapterProducers.Update(dataSet, "producers");
                
            MessageBox.Show("Data saved successfully");

            dataSet.Tables["wines"].Clear();
            dataSet.Tables["producers"].Clear();

            dataAdapterProducers.Fill(dataSet, "producers");
            dataAdapterWines.Fill(dataSet, "wines");
        }
    }
}
