﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system
{
    public partial class ViewReservedBook : Form
    {
        public ViewReservedBook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchUNumber.Clear();
        }

        private void ViewReservedBook_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM ReservedBooks";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            // Check if ViewReservedBook form is open
            if (Application.OpenForms.OfType<ViewReservedBook>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }

            }

        }

        private void txtSearchUNumber_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchUNumber.Text != "")

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM ReservedBooks WHERE Reserved_UserNumber LIKE '" + txtSearchUNumber.Text + "%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

            else

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM ReservedBooks";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Assuming you have a reference to the Dashboard form
            Dashboard dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();

            if (MessageBox.Show("Do you want to exit ?", "Are You Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Show the Dashboard form
                if (dashboardForm != null)
                {
                    dashboardForm.Show();
                }

                this.Close();
            }
        }
    }
}
