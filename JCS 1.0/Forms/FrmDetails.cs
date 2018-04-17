using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JCS_1._0.Forms
{
    public partial class FrmDetails : Form
    {
        public FrmDetails(string r)
        {
            InitializeComponent();
            richTextBox1.Text = r;
        }
    }
}
