using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Serialization;

using RePaint.Utils;

namespace RePaint.Forms
{

    public partial class MainForm : Form
    {
        #region Дополнительные элементы управления
        TrackBar sprayPressureTrBar;
        Label sprayPressureLabel;

        TrackBar PieSweepAngleTrBar;
        Label sweepAngleLabel;

        TrackBar PieStartAngleTrBar;
        Label startAngleLabel;
        #endregion

        LinkedListNode<PaintArea> paintAreasActive;
        LinkedList<PaintArea> paintAreas;
        PaintArea paintArea;

        public void UpdateStatus()
        {
            tlStrpStRes.Text = $"{paintArea.PictureBox.Width}x{paintArea.PictureBox.Height}";
            tlStrpStpFileName.Text = $"{StringEditor.FileNameExt(SaveFileDialog.FileName)}";

            if (tlStrpStpFileName.Text == "")
                tlStrpStpFileName.Text = "untitled.png";
        }

        public void CreateNewPaintArea(Color color,
            int width = 800, int height = 600)
        {
            if (paintArea != null)
                paintArea.Clear();
                
            paintArea = new PaintArea(width, height, 
                new Pen(brushClrPnl.BackColor, penWidthTrBar.Value),
                color);

            ReInitializePaintArea();

            paintAreas = new LinkedList<PaintArea>();
            paintAreas.AddFirst(paintArea.Copy());

            paintAreasActive = paintAreas.First;
        }

        public void CreateNewPaintAreaFromImage(Image image)
        {
            if (paintArea != null)
                paintArea.Clear();

            paintArea = new PaintArea(image,
                new Pen(brushClrPnl.BackColor, penWidthTrBar.Value));

            ReInitializePaintArea();

            paintAreas = new LinkedList<PaintArea>();
            paintAreas.AddFirst(paintArea.Copy());

            paintAreasActive = paintAreas.First;
        }

        public void ReInitializePaintArea()
        {
            paintArea.AssignTo(paintPanel);
            
            paintArea.PictureBox.MouseMove += new MouseEventHandler(paintArea_MouseMove);
            paintArea.ImageUpdated += new EventHandler(paintArea_ImageChanged);
            paintArea.PictureBox.SizeChanged += new EventHandler(paintArea_SizeChanged);
        }

        public MainForm()
        {
            InitializeComponent();
            #region Инициализация дополнительных элементов управления
            // 
            // sweepAngleLabel
            // 
            sweepAngleLabel = new Label();
            sweepAngleLabel.Visible = false;
            sweepAngleLabel.Enabled = false;
            sweepAngleLabel.Location = new Point(3, 359);
            sweepAngleLabel.Name = "sweepAngleLabel";
            sweepAngleLabel.Size = new Size(81, 32);
            sweepAngleLabel.TabIndex = 16;
            sweepAngleLabel.Text = "Конец сектора: 270°";
            // 
            // PieSweepAngleTrBar
            // 
            PieSweepAngleTrBar = new TrackBar();
            PieSweepAngleTrBar.Visible = false;
            PieSweepAngleTrBar.Enabled = false;
            PieSweepAngleTrBar.Location = new Point(3, 323);
            PieSweepAngleTrBar.Maximum = 360;
            PieSweepAngleTrBar.Minimum = 1;
            PieSweepAngleTrBar.Size = new Size(81, 45);
            PieSweepAngleTrBar.TabIndex = 15;
            PieSweepAngleTrBar.TickFrequency = 20;
            PieSweepAngleTrBar.Value = 270;
            PieSweepAngleTrBar.ValueChanged += new EventHandler(PieSweepAngleTrBar_ValueChanged);
            // 
            // startAngleLabel
            // 
            startAngleLabel = new Label();
            startAngleLabel.Visible = false;
            startAngleLabel.Enabled = false;
            startAngleLabel.Location = new Point(3, 287);
            startAngleLabel.Size = new Size(81, 33);
            startAngleLabel.TabIndex = 14;
            startAngleLabel.Text = "Начало сектора: 180°";
            // 
            // PieStartAngleTrBar
            // 
            PieStartAngleTrBar = new TrackBar();
            PieStartAngleTrBar.Visible = false;
            PieStartAngleTrBar.Enabled = false;
            PieStartAngleTrBar.Location = new Point(3, 255);
            PieStartAngleTrBar.Maximum = 360;
            PieStartAngleTrBar.Minimum = 1;
            PieStartAngleTrBar.Size = new Size(81, 45);
            PieStartAngleTrBar.TabIndex = 13;
            PieStartAngleTrBar.TickFrequency = 20;
            PieStartAngleTrBar.Value = 180;
            PieStartAngleTrBar.ValueChanged += new EventHandler(PieStartAngleTrBar_ValueChanged);
            // 
            // sprayPressureLabel
            // 
            sprayPressureLabel = new Label();
            sprayPressureLabel.Visible = false;
            sprayPressureLabel.Enabled = false;
            sprayPressureLabel.Location = new Point(9, 292);
            sprayPressureLabel.Size = new Size(77, 29);
            sprayPressureLabel.TabIndex = 22;
            sprayPressureLabel.Text = $"Сила нажатия: 0.05";
            // 
            // sprayPressureTrBar
            // 
            sprayPressureTrBar = new TrackBar();
            sprayPressureTrBar.Visible = false;
            sprayPressureTrBar.Enabled = false;
            sprayPressureTrBar.Location = new Point(3, 255);
            sprayPressureTrBar.Maximum = 100;
            sprayPressureTrBar.Minimum = 1;
            sprayPressureTrBar.Name = "sprayPressureTrBar";
            sprayPressureTrBar.Size = new Size(81, 45);
            sprayPressureTrBar.TabIndex = 21;
            sprayPressureTrBar.TickFrequency = 30;
            sprayPressureTrBar.Value = 5;
            sprayPressureTrBar.ValueChanged += new EventHandler(sprayPressureTrBar_ValueChanged);

            toolBox.Controls.Add(sprayPressureLabel);
            toolBox.Controls.Add(sprayPressureTrBar);
            toolBox.Controls.Add(sweepAngleLabel);
            toolBox.Controls.Add(PieSweepAngleTrBar);
            toolBox.Controls.Add(startAngleLabel);
            toolBox.Controls.Add(PieStartAngleTrBar);
            #endregion

            foreach (Control ctrl in toolBox.Controls)
            {

                if (ctrl is Button)
                {
                    if (ctrl == swapBtn ||
                    ctrl == selectlAllBtn ||
                    ctrl == penStyleBtn)
                        continue;

                    ((Button)ctrl).Click += new EventHandler(stateButton_Click);
                }
            }

            DoubleBuffered = true;

            CreateNewPaintArea(Color.White);

            updateBrushStylePnl();
        }

        private void updateBrushStylePnl()
        {
            Image image = new Bitmap(brushStylePnl.Width, brushStylePnl.Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillEllipse(PaintAreaArgs.Pen.Brush, 0, 0, brushStylePnl.Width - 5, brushStylePnl.Height - 5);
            }

            brushStylePnl.BackgroundImage = image;
        }

        private void paintArea_MouseMove(object sender, MouseEventArgs e)
        {
            tlStrpStCoords.Text = $"X:{e.X};Y:{e.Y}";
        }

        private void paintArea_SizeChanged(object sender, EventArgs e)
        {
            tlStrpStpFileName.Text = ((PictureBox)sender).Size.ToString();
        }

        private void paintArea_ImageChanged(object sender, EventArgs e)
        {
            while (paintAreasActive.Next != null)
            {
                paintAreas.Remove(paintAreasActive.Next);
            }
            while (paintAreas.Count > 5)
            {
                paintAreas.RemoveFirst();
            }
            forwardToolStripMenuItem.Enabled = false;

            paintAreasActive = paintAreas.AddAfter(paintAreasActive, paintArea.Copy());
            backToolStripMenuItem.Enabled = true;
        }

        #region Методы, связанные с toolBox

        private void stateButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in toolBox.Controls)
            {
                if (ctrl is Button)
                    ctrl.BackColor = SystemColors.ControlLight;
            }

            #region Сокрытие доп. элементов управления
            if (sender != ellipsePieBtn)
            {
                sweepAngleLabel.Enabled = false;
                sweepAngleLabel.Visible = false;

                PieSweepAngleTrBar.Enabled = false;
                PieSweepAngleTrBar.Visible = false;

                startAngleLabel.Enabled = false;
                startAngleLabel.Visible = false;

                PieStartAngleTrBar.Enabled = false;
                PieStartAngleTrBar.Visible = false;
            }

            if (sender != sprayBtn)
            {
                sprayPressureTrBar.Enabled = false;
                sprayPressureTrBar.Visible = false;

                sprayPressureLabel.Enabled = false;
                sprayPressureLabel.Visible = false;
            }
            #endregion

            ((Button)sender).BackColor = SystemColors.GradientInactiveCaption;
        }

        private void cursorBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.Cursor;
        }

        private void deleterBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.Delete;
        }

        private void brushBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.Brush;
        }

        private void eraserBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.Eraser;
        }

        private void lineBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.Line;
        }

        private void rectangleBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.Rectangle;
        }

        private void ellipseBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.Ellipse;
        }

        private void ellipsePieBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.EllipsePie;

            #region Видимость доп. элементов управления
            sweepAngleLabel.Enabled = true;
            sweepAngleLabel.Visible = true;
            PieSweepAngleTrBar.Enabled = true;
            PieSweepAngleTrBar.Visible = true;
            startAngleLabel.Enabled = true;
            startAngleLabel.Visible = true;
            PieStartAngleTrBar.Enabled = true;
            PieStartAngleTrBar.Visible = true;
            #endregion

            PaintAreaArgs.PieStartAngle = PieStartAngleTrBar.Value;
            PaintAreaArgs.PieSweepAngle = PieSweepAngleTrBar.Value;
        }
        private void lineBezierBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.LineBezier;
        }

        private void curveBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.Curve;
        }

        private void sprayBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.SprayCurve;
            sprayPressureTrBar.Value = (int)(PaintAreaArgs.SprayDistribution * 100);

            #region Видимость доп. элементов управления
            sprayPressureTrBar.Visible = true;
            sprayPressureTrBar.Enabled = true;
            sprayPressureLabel.Visible = true;
            sprayPressureLabel.Enabled = true;
            #endregion
        }

        private void bucketBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.FillBucket;
        }

        private void selectAreaBtn_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.State = State.SelectArea;
        }

        private void swapBtn_Click(object sender, EventArgs e)
        {
            Color temp = brushClrPnl.BackColor;

            PaintAreaArgs.PenColor = Color.FromArgb(
                    PaintAreaArgs.PenColor.A, altClrPnl.BackColor);
            brushClrPnl.BackColor = altClrPnl.BackColor;

            altClrPnl.BackColor = temp;
        }

        private void brushClrPnl_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                PaintAreaArgs.PenColor = Color.FromArgb(
                    PaintAreaArgs.PenColor.A, ColorDialog.Color);
                brushClrPnl.BackColor = ColorDialog.Color;

                updateBrushStylePnl();
            }
        }

        private void altClrPnl_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
                altClrPnl.BackColor = ColorDialog.Color;
        }

        private void penStyleBtn_Click(object sender, EventArgs e)
        {
            var psef = new PenStyleEditForm();
            psef.Show();
        }

        private void selectlAllBtn_Click(object sender, EventArgs e)
        {
            paintArea.SelectAll();
        }

        private void penWidthTrBar_ValueChanged(object sender, EventArgs e)
        {
            PaintAreaArgs.PaintWidth = penWidthTrBar.Value;
            widthLabel.Text = $"Толщина: {penWidthTrBar.Value}";
        }
        private void PieStartAngleTrBar_ValueChanged(object sender, EventArgs e)
        {
            PaintAreaArgs.PieStartAngle = PieStartAngleTrBar.Value;
            startAngleLabel.Text = $"Начало сектора: {PieStartAngleTrBar.Value}°";
        }

        private void PieSweepAngleTrBar_ValueChanged(object sender, EventArgs e)
        {
            PaintAreaArgs.PieSweepAngle = PieSweepAngleTrBar.Value;
            sweepAngleLabel.Text = $"Конец сектора: {PieSweepAngleTrBar.Value}°";
        }

        private void sprayPressureTrBar_ValueChanged(object sender, EventArgs e)
        {
            PaintAreaArgs.SprayDistribution = sprayPressureTrBar.Value / 100f;
            sprayPressureLabel.Text = $"Сила нажатия: {sprayPressureTrBar.Value / 100f}";
        }
        #endregion

        #region Методы, связанные с MenuStrip
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var npaf = new NewPaintAreaForm(this);
            npaf.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog.FileName = OpenFileDialog.FileName;
                tlStrpStpFileName.Text = $"{StringEditor.FileNameExt(OpenFileDialog.FileName)}";
                if (string.Equals(StringEditor.Ext(SaveFileDialog.FileName), "rpif",
                    StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        paintArea = PaintAreaArgs.Deserialize(OpenFileDialog.FileName);
                    }
                    catch (SerializationException)
                    {
                        MessageBox.Show("Нечитаемый файл");
                        return;
                    }
                    ReInitializePaintArea();
                    return;
                }
                using (FileStream fs = new FileStream(OpenFileDialog.FileName, FileMode.Open))
                {
                    CreateNewPaintAreaFromImage(Image.FromStream(fs));
                    fs.Close();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.FileName == "")
            {
                saveAsToolStripMenuItem_Click(saveToolStripMenuItem, new EventArgs());
                return;
            }

            if (string.Equals(StringEditor.Ext(SaveFileDialog.FileName), "rpif",
                    StringComparison.OrdinalIgnoreCase))
            {
                PaintAreaArgs.Serialize(SaveFileDialog.FileName, paintArea);
                return;
            }

            tlStrpStpFileName.Text = $"{StringEditor.FileNameExt(SaveFileDialog.FileName)}";
            paintArea.PictureBox.Image.Save(SaveFileDialog.FileName);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (string.Equals(StringEditor.Ext(SaveFileDialog.FileName), "rpif",
                    StringComparison.OrdinalIgnoreCase))
                {
                    PaintAreaArgs.Serialize(SaveFileDialog.FileName, paintArea);
                    return;
                }

                paintArea.PictureBox.Image.Save(SaveFileDialog.FileName);
                tlStrpStpFileName.Text = $"{StringEditor.FileNameExt(SaveFileDialog.FileName)}";
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paintAreasActive.Previous != null)
            {
                forwardToolStripMenuItem.Enabled = true;

                paintArea = paintAreasActive.Previous.Value.Copy();
                paintAreasActive = paintAreasActive.Previous;
                ReInitializePaintArea();
            }

            if (paintAreasActive.Previous == null)
            {
                backToolStripMenuItem.Enabled = false;
            }
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paintAreasActive.Next != null)
            {
                backToolStripMenuItem.Enabled = true;

                paintArea = paintAreasActive.Next.Value.Copy();
                paintAreasActive = paintAreasActive.Next;
                ReInitializePaintArea();
            }

            if (paintAreasActive.Next == null)
            {
                forwardToolStripMenuItem.Enabled = false;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintArea.DeleteSelected();
        }

        private void rasterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintArea.RasterizeSelected();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About();
            about.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        backToolStripMenuItem_Click(this, EventArgs.Empty);
                        break;
                    case Keys.Y:
                        forwardToolStripMenuItem_Click(this, EventArgs.Empty);
                        break;
                    case Keys.N:
                        createToolStripMenuItem_Click(this, EventArgs.Empty);
                        break;
                    case Keys.O:
                        openToolStripMenuItem_Click(this, EventArgs.Empty);
                        break;
                    case Keys.S:
                        if (e.Shift)
                        {
                            saveAsToolStripMenuItem_Click(this, EventArgs.Empty);
                        }
                        else
                        {
                            saveToolStripMenuItem_Click(this, EventArgs.Empty);
                        }
                        break;
                    case Keys.R:
                        paintArea.RasterizeSelected();
                        break;
                    case Keys.Q:
                        exitToolStripMenuItem_Click(this, EventArgs.Empty);
                        break;
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                paintArea.DeleteSelected();
            }
        }
    }
}
