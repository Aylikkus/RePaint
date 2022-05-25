using System.Windows.Forms;

namespace RePaint.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void gitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(gitHubLink.Text);
        }
    }
}
