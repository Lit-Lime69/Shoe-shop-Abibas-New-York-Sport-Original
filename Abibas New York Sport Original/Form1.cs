using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abibas_New_York_Sport_Original
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password don t match");
                return;
            }

            if(textBox2.Text == textBox1.Text)
            {
                MessageBox.Show("Username and password must not match", "Error");
                return;
            }

            /*ValidstionLogin.LV = new ValidationLogin();
            if(LV.Validation(textBox1.Text)==false)
            {
                return;
            }
            else
            {
                Register(textBox1.Text, textBox2.Text);

                Form1 LF = new Form1();
                LF.Text = textBox1.Text;
                this.Hide();
            }*/
        }

        /*private void Register(string login, string password)
        {
            Hashing GH = new Hashing();
            string query = $"Insert into Пользователь(Логин, Пароль) values('{login}', '{GH.Hash(password)}'";

            var dbquery = new DBquery();
            dbquery.queryExecute(query);
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OutputOfTheShoeModelCatalog form2 = new OutputOfTheShoeModelCatalog();
            form2.Show();
            this.Hide();
        }
    }
}
