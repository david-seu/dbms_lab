using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Printing;

namespace examDB
{
    public partial class Form1 : Form
    {

        private DataSet dataSet = new DataSet();
        private SqlConnection sqlConnection;

        private SqlDataAdapter dataAdapterPatients, dataAdapterAppointments;
        private readonly BindingSource bindingPatients = new BindingSource();
        private readonly BindingSource bindingAppointments = new BindingSource();

        public void Form1_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            InitializeUI();
        }

        private void InitializeDatabase()
        {
            String connectionString = "Data Source=ROGER;Initial Catalog=exam_db;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            dataAdapterPatients = new SqlDataAdapter("SELECT * FROM patients", sqlConnection);
            dataAdapterAppointments = new SqlDataAdapter("SELECT * FROM appointments", sqlConnection);

            dataAdapterPatients.Fill(dataSet, "patients");
            dataAdapterAppointments.Fill(dataSet, "appointments");

            var relation = new DataRelation("FK_patients", dataSet.Tables["patients"].Columns["p_id"], dataSet.Tables["appointments"].Columns["p_id"]);
            dataSet.Relations.Add(relation);
        }

        private void InitializeUI()
        {
            bindingPatients.DataSource = dataSet;
            bindingPatients.DataMember = "patients";

            bindingAppointments.DataSource = bindingPatients;
            bindingAppointments.DataMember = "FK_patients";

            dgvPatient.DataSource = bindingPatients;
            dgvAppointments.DataSource = bindingAppointments;
        }

        public Form1() => InitializeComponent();

        private void saveButton_Click(object sender, EventArgs e)
        {
            _ = new SqlCommandBuilder(dataAdapterAppointments);
            dataAdapterAppointments.Update(dataSet, "appointments");
            dataAdapterPatients.Update(dataSet, "patients");
                
            MessageBox.Show("Data saved successfully");

            dataSet.Tables["appointments"].Clear();
            dataSet.Tables["patients"].Clear();

            dataAdapterPatients.Fill(dataSet, "patients");
            dataAdapterAppointments.Fill(dataSet, "appointments");
        }
    }
}
