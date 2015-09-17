using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class StartForm : Form
    {
        public EventHandler<OpenProjectArgs> OnOpenProject;

        public StartForm()
        {
            InitializeComponent();
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            NewProject dialog = new NewProject();
            DialogResult res = dialog.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                OpenProjectProps props = new OpenProjectProps();
                props.Type = OpenType.New;
                props.ProjectFolder = dialog.Directory;
                props.ProjectName = dialog.ProjectName;

                if (OnOpenProject != null)
                {
                    OnOpenProject(this, new OpenProjectArgs(props));
                }
            }
        }

        private void btnExisting_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult res = dialog.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                OpenProjectProps props = new OpenProjectProps();
                props.ProjectFile = dialog.FileName;
                props.Type = OpenType.Existing;

                if (OnOpenProject != null)
                {
                    OnOpenProject(this, new OpenProjectArgs(props));
                }
            }
        }
    }

    public class OpenProjectArgs : EventArgs
    {
        public OpenProjectProps Props { get; set; }

        public OpenProjectArgs(OpenProjectProps props)
        {
            Props = props;
        }
    }
}
