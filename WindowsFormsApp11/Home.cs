using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Home : Form
    {
        Server ServerForm;
        Client ClientForm;

        public Home()
        {
            InitializeComponent();
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            ServerForm = new Server();
            ServerForm.Show();
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            ClientForm = new Client();
            ClientForm.Show();
        }
    }
}
