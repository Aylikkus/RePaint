using System.Drawing;
using System.Windows.Forms;

namespace RePaint.Forms
{
    public partial class NewPaintAreaForm : Form
    {
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 800;
        public Color Color { get; set; } = Color.White;

        MainForm mf;

        public NewPaintAreaForm(MainForm mf)
        {
            InitializeComponent();

            Width = (int)widthNumUpDown.Value;
            Height = (int)heightNumUpDown.Value;
            Color = clrPanel.BackColor;

            this.mf = mf;
        }

        private void widthNumUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            Width = (int)widthNumUpDown.Value;
        }

        private void heightNumUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            Height = (int)heightNumUpDown.Value;
        }

        private void clrPanel_Click(object sender, System.EventArgs e)
        {
            if (mf.ColorDialog.ShowDialog() == DialogResult.OK)
            {
                Color = mf.ColorDialog.Color;
                clrPanel.BackColor = mf.ColorDialog.Color;
            }
        }

        private void checkBtn_Click(object sender, System.EventArgs e)
        {
            mf.SaveFileDialog.FileName = "";
            mf.CreateNewPaintArea(Color, Width, Height);
            mf.UpdateStatus();
        }
    }
}
