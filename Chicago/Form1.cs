using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using Chicago.Properties;
using NLog;

namespace Chicago
{
    public partial class Form1 : Form
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Form1()
        {
            InitializeComponent();

            //Show version info
            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
// ReSharper disable DoNotCallOverridableMethodsInConstructor
            Text = Text + ' ' + fvi.ProductVersion;
// ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _logger.Trace("UI: Creating JobDispatcher");
            var jd = new JobDispatcher
                {
                    Handler = Assembly.GetExecutingAssembly().CreateInstance((string) comboBox1.SelectedItem)
                };
            jd.Execute();
            MessageBox.Show(Resources.l_Successful + jd.Successful.ToString(CultureInfo.InvariantCulture));
            MessageBox.Show(Resources.l_Failed + jd.Bad.ToString(CultureInfo.InvariantCulture));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var types = ReflectionHelper.GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Chicago.JobHandlers");
            foreach (Type type in types)
            {
                comboBox1.Items.Add(type.ToString());
            }
        }
    }
}