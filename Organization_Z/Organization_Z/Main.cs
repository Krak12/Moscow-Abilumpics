using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organization_Z
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var userTA = new dbDataSetTableAdapters.WorkersTableAdapter();
            var users = userTA.GetDataByLoginAndPass(textBox1.Text, textBox2.Text);

            if (users.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Data.UserAutorized = userTA.GetDataByLogin(textBox1.Text.Trim()).First();

            if (Data.UserAutorized.TypeAccount == 1)
            {
                Form cm = new CreatorMenu();
                DialogResult res = cm.ShowDialog();
                if (res != DialogResult.Cancel)
                {
                    Show();
                }
                else Close();
            }
            else if (Data.UserAutorized.TypeAccount == 2)
            {
                Form cm = new SpecialistMenu();
                DialogResult res = cm.ShowDialog();
                if (res != DialogResult.Cancel)
                {
                    Show();
                }
                else Close();
            }
            else if (Data.UserAutorized.TypeAccount == 3)
            {
                Form cm = new TechnicianMenu();
                DialogResult res = cm.ShowDialog();
                if (res != DialogResult.Cancel)
                {
                    Show();
                }
                else Close();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
