﻿using Npgsql;
using PostgresConnectionExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD2_2024.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void showMessageBox(String txt, String title = "Atenção!")
        {
            MessageBox.Show(txt, title);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var connection = DatabasePostgresConnection.GetInstance().GetConnection())
            {
                using (var command = new NpgsqlCommand("SELECT version()", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            showMessageBox(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
