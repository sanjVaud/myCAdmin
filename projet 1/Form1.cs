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
using MySql.Data.MySqlClient;

namespace projet_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection cn;
        bool Connecte = false;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "Se connecté")
            {
                cn = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=test;UID=root;PWD=root") ;

                try
                {
                    if (cn.State == ConnectionState.Closed) { cn.Open(); }
                    button1.Text = "Se déconnecter";
                    Connecte = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                button1.Text = "Se connecté";
                Connecte = false;
            }

            /*
            string connStr = "server=localhost;user=root;database=mysql;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            */
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Entrez un nom.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Entrez l'age.");
            }
            else
            {
                if (Connecte)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO utilisateurs(nom,age) VALUES(@nom,@age)", cn);
                    cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                    cmd.Parameters.AddWithValue("@age", int.Parse(textBox2.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    MessageBox.Show("Ajouté.");
                }
                else
                {
                    MessageBox.Show("Vous n'êtes pas connecté à la base de données");
                }
            }
        }
    }
}
