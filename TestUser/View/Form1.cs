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
            

            var users = Helper.DB.User.Select(x => new {x.Login, x.Password, x.Role.RoleName }).ToList();
            dataGridView1.DataSource = users;
        }
    }
}
