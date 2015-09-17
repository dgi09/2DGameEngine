using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public class AppContext : ApplicationContext
    {
        Editor.StartForm startForm;
        Editor.MainForm mainForm;

        public AppContext()
        {
            startForm = new StartForm();


            startForm.Show();
            startForm.OnOpenProject += OnProjectOpen;
            
        }

        private void OnProjectOpen(object sender, OpenProjectArgs e)
        {
            startForm.Close();
            mainForm = new MainForm(e.Props);
            mainForm.Show();
        }
    }
}
