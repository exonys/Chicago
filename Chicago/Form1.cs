using System;
using System.Windows.Forms;
using System.Reflection;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            var types = ReflectionHelper.GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Chicago.JobHandlers");
            foreach (var type in types)
            {
                comboBox1.Items.Add(type.ToString());
            }
        }
    }
}