using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            Helper.DB = new Entity.DBAutorization02Entities();

            comboBox1.Items.Add("Все категории");

            var users = Helper.DB.User.Select(x => new {x.Login, x.Password, x.Role.RoleName, x.Department.DepartmentName }).ToList();
            dataGridView1.DataSource = users;

            var deplom = Helper.DB.Department.ToList();
            foreach (var item in deplom)
            {
                comboBox1.Items.Add(item.DepartmentName);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }

        private void Show()
        {
            if (comboBox1.SelectedIndex != 0)
            {
                var users = Helper.DB.User.Where(x => x.DepartmentId == comboBox1.SelectedIndex).Select(x => new { x.Login, x.Password, x.Role.RoleName, x.Department.DepartmentName }).ToList();
                dataGridView1.DataSource = users;
            }
            else
            {
                var users = Helper.DB.User.Select(x => new { x.Login, x.Password, x.Role.RoleName, x.Department.DepartmentName }).ToList();
                dataGridView1.DataSource = users;
            }
        }
    }
}
