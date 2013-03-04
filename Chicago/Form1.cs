using System;
using System.Windows.Forms;
using NLog;

namespace Chicago
{

    public partial class Form1 : Form
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _logger.Trace("UI: Creating JobDispatcher");
            var jd = new JobDispatcher();
            jd.Execute();
        }
    }
}