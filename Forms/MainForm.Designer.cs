namespace RePaint.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.paintPanel = new System.Windows.Forms.Panel();
            this.toolBox = new System.Windows.Forms.Panel();
            this.selectAreaBtn = new System.Windows.Forms.Button();
            this.bucketBtn = new System.Windows.Forms.Button();
            this.selectlAllBtn = new System.Windows.Forms.Button();
            this.brushBtn = new System.Windows.Forms.Button();
            this.penStyleBtn = new System.Windows.Forms.Button();
            this.sprayBtn = new System.Windows.Forms.Button();
            this.curveBtn = new System.Windows.Forms.Button();
            this.brushStylePnl = new System.Windows.Forms.Panel();
            this.lineBezierBtn = new System.Windows.Forms.Button();
            this.ellipsePieBtn = new System.Windows.Forms.Button();
            this.ellipseBtn = new System.Windows.Forms.Button();
            this.widthLabel = new System.Windows.Forms.Label();
            this.penWidthTrBar = new System.Windows.Forms.TrackBar();
            this.deleterBtn = new System.Windows.Forms.Button();
            this.rectangleBtn = new System.Windows.Forms.Button();
            this.cursorBtn = new System.Windows.Forms.Button();
            this.altClrPnl = new System.Windows.Forms.Panel();
            this.brushClrPnl = new System.Windows.Forms.Panel();
            this.lineBtn = new System.Windows.Forms.Button();
            this.eraserBtn = new System.Windows.Forms.Button();
            this.swapBtn = new System.Windows.Forms.Button();
            this.statusInfo = new System.Windows.Forms.Panel();
            this.btmStatusStrp = new System.Windows.Forms.StatusStrip();
            this.tlStrpStCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlStrpStRes = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlStrpStpFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rasterizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthTrBar)).BeginInit();
            this.statusInfo.SuspendLayout();
            this.btmStatusStrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenu,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.createToolStripMenuItem.Text = "Создать (Ctrl + N)";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.openToolStripMenuItem.Text = "Открыть (Ctrl + O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.saveToolStripMenuItem.Text = "Сохранить (Ctrl + S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как (Ctrl + Shift + S)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.exitToolStripMenuItem.Text = "Выход (Ctrl + Q)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenu
            // 
            this.editToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.rasterizeToolStripMenuItem});
            this.editToolStripMenu.Name = "editToolStripMenu";
            this.editToolStripMenu.Size = new System.Drawing.Size(99, 20);
            this.editToolStripMenu.Text = "Редактировать";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Enabled = false;
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.backToolStripMenuItem.Text = "Назад (Ctrl + Z)";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Enabled = false;
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.forwardToolStripMenuItem.Text = "Вперёд (Ctrl + Y)";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // canvasPanel
            // 
            this.canvasPanel.AutoSize = true;
            this.canvasPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.canvasPanel.Controls.Add(this.paintPanel);
            this.canvasPanel.Controls.Add(this.toolBox);
            this.canvasPanel.Controls.Add(this.statusInfo);
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 24);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(1184, 737);
            this.canvasPanel.TabIndex = 1;
            // 
            // paintPanel
            // 
            this.paintPanel.AutoScroll = true;
            this.paintPanel.AutoSize = true;
            this.paintPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.paintPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paintPanel.Location = new System.Drawing.Point(91, 0);
            this.paintPanel.Name = "paintPanel";
            this.paintPanel.Size = new System.Drawing.Size(1093, 712);
            this.paintPanel.TabIndex = 4;
            // 
            // toolBox
            // 
            this.toolBox.BackColor = System.Drawing.SystemColors.Menu;
            this.toolBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBox.Controls.Add(this.selectAreaBtn);
            this.toolBox.Controls.Add(this.bucketBtn);
            this.toolBox.Controls.Add(this.selectlAllBtn);
            this.toolBox.Controls.Add(this.brushBtn);
            this.toolBox.Controls.Add(this.penStyleBtn);
            this.toolBox.Controls.Add(this.sprayBtn);
            this.toolBox.Controls.Add(this.curveBtn);
            this.toolBox.Controls.Add(this.brushStylePnl);
            this.toolBox.Controls.Add(this.lineBezierBtn);
            this.toolBox.Controls.Add(this.ellipsePieBtn);
            this.toolBox.Controls.Add(this.ellipseBtn);
            this.toolBox.Controls.Add(this.widthLabel);
            this.toolBox.Controls.Add(this.penWidthTrBar);
            this.toolBox.Controls.Add(this.deleterBtn);
            this.toolBox.Controls.Add(this.rectangleBtn);
            this.toolBox.Controls.Add(this.cursorBtn);
            this.toolBox.Controls.Add(this.altClrPnl);
            this.toolBox.Controls.Add(this.brushClrPnl);
            this.toolBox.Controls.Add(this.lineBtn);
            this.toolBox.Controls.Add(this.eraserBtn);
            this.toolBox.Controls.Add(this.swapBtn);
            this.toolBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBox.Location = new System.Drawing.Point(0, 0);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(91, 712);
            this.toolBox.TabIndex = 2;
            // 
            // selectAreaBtn
            // 
            this.selectAreaBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.selectAreaBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectAreaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAreaBtn.Image = global::RePaint.Properties.Resources.selectArea14x14;
            this.selectAreaBtn.Location = new System.Drawing.Point(3, 118);
            this.selectAreaBtn.Name = "selectAreaBtn";
            this.selectAreaBtn.Size = new System.Drawing.Size(23, 23);
            this.selectAreaBtn.TabIndex = 24;
            this.selectAreaBtn.UseVisualStyleBackColor = false;
            this.selectAreaBtn.Click += new System.EventHandler(this.selectAreaBtn_Click);
            // 
            // bucketBtn
            // 
            this.bucketBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bucketBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bucketBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bucketBtn.Image = global::RePaint.Properties.Resources.bucket14x14;
            this.bucketBtn.Location = new System.Drawing.Point(61, 89);
            this.bucketBtn.Name = "bucketBtn";
            this.bucketBtn.Size = new System.Drawing.Size(23, 23);
            this.bucketBtn.TabIndex = 23;
            this.bucketBtn.UseVisualStyleBackColor = false;
            this.bucketBtn.Click += new System.EventHandler(this.bucketBtn_Click);
            // 
            // selectlAllBtn
            // 
            this.selectlAllBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.selectlAllBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectlAllBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectlAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectlAllBtn.Location = new System.Drawing.Point(0, 673);
            this.selectlAllBtn.Name = "selectlAllBtn";
            this.selectlAllBtn.Size = new System.Drawing.Size(89, 37);
            this.selectlAllBtn.TabIndex = 22;
            this.selectlAllBtn.Text = "Выделить фигуры\r\n";
            this.selectlAllBtn.UseVisualStyleBackColor = false;
            this.selectlAllBtn.Click += new System.EventHandler(this.selectlAllBtn_Click);
            // 
            // brushBtn
            // 
            this.brushBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.brushBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brushBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brushBtn.Image = ((System.Drawing.Image)(resources.GetObject("brushBtn.Image")));
            this.brushBtn.Location = new System.Drawing.Point(32, 2);
            this.brushBtn.Name = "brushBtn";
            this.brushBtn.Size = new System.Drawing.Size(23, 23);
            this.brushBtn.TabIndex = 1;
            this.brushBtn.UseVisualStyleBackColor = false;
            this.brushBtn.Click += new System.EventHandler(this.brushBtn_Click);
            // 
            // penStyleBtn
            // 
            this.penStyleBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.penStyleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.penStyleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.penStyleBtn.Image = global::RePaint.Properties.Resources.style29x5;
            this.penStyleBtn.Location = new System.Drawing.Point(50, 147);
            this.penStyleBtn.Name = "penStyleBtn";
            this.penStyleBtn.Size = new System.Drawing.Size(29, 14);
            this.penStyleBtn.TabIndex = 21;
            this.penStyleBtn.UseVisualStyleBackColor = false;
            this.penStyleBtn.Click += new System.EventHandler(this.penStyleBtn_Click);
            // 
            // sprayBtn
            // 
            this.sprayBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sprayBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sprayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sprayBtn.Image = ((System.Drawing.Image)(resources.GetObject("sprayBtn.Image")));
            this.sprayBtn.Location = new System.Drawing.Point(3, 60);
            this.sprayBtn.Name = "sprayBtn";
            this.sprayBtn.Size = new System.Drawing.Size(23, 23);
            this.sprayBtn.TabIndex = 20;
            this.sprayBtn.UseVisualStyleBackColor = false;
            this.sprayBtn.Click += new System.EventHandler(this.sprayBtn_Click);
            // 
            // curveBtn
            // 
            this.curveBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.curveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.curveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.curveBtn.Image = ((System.Drawing.Image)(resources.GetObject("curveBtn.Image")));
            this.curveBtn.Location = new System.Drawing.Point(32, 31);
            this.curveBtn.Name = "curveBtn";
            this.curveBtn.Size = new System.Drawing.Size(23, 23);
            this.curveBtn.TabIndex = 19;
            this.curveBtn.UseVisualStyleBackColor = false;
            this.curveBtn.Click += new System.EventHandler(this.curveBtn_Click);
            // 
            // brushStylePnl
            // 
            this.brushStylePnl.BackColor = System.Drawing.Color.White;
            this.brushStylePnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.brushStylePnl.Location = new System.Drawing.Point(50, 163);
            this.brushStylePnl.Name = "brushStylePnl";
            this.brushStylePnl.Size = new System.Drawing.Size(30, 30);
            this.brushStylePnl.TabIndex = 6;
            // 
            // lineBezierBtn
            // 
            this.lineBezierBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lineBezierBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lineBezierBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineBezierBtn.Image = ((System.Drawing.Image)(resources.GetObject("lineBezierBtn.Image")));
            this.lineBezierBtn.Location = new System.Drawing.Point(32, 60);
            this.lineBezierBtn.Name = "lineBezierBtn";
            this.lineBezierBtn.Size = new System.Drawing.Size(23, 23);
            this.lineBezierBtn.TabIndex = 17;
            this.lineBezierBtn.UseVisualStyleBackColor = false;
            this.lineBezierBtn.Click += new System.EventHandler(this.lineBezierBtn_Click);
            // 
            // ellipsePieBtn
            // 
            this.ellipsePieBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ellipsePieBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ellipsePieBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ellipsePieBtn.Image = ((System.Drawing.Image)(resources.GetObject("ellipsePieBtn.Image")));
            this.ellipsePieBtn.Location = new System.Drawing.Point(32, 89);
            this.ellipsePieBtn.Name = "ellipsePieBtn";
            this.ellipsePieBtn.Size = new System.Drawing.Size(23, 23);
            this.ellipsePieBtn.TabIndex = 12;
            this.ellipsePieBtn.UseVisualStyleBackColor = false;
            this.ellipsePieBtn.Click += new System.EventHandler(this.ellipsePieBtn_Click);
            // 
            // ellipseBtn
            // 
            this.ellipseBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ellipseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ellipseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ellipseBtn.Image = ((System.Drawing.Image)(resources.GetObject("ellipseBtn.Image")));
            this.ellipseBtn.Location = new System.Drawing.Point(3, 89);
            this.ellipseBtn.Name = "ellipseBtn";
            this.ellipseBtn.Size = new System.Drawing.Size(23, 23);
            this.ellipseBtn.TabIndex = 11;
            this.ellipseBtn.UseVisualStyleBackColor = false;
            this.ellipseBtn.Click += new System.EventHandler(this.ellipseBtn_Click);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(14, 236);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(65, 13);
            this.widthLabel.TabIndex = 2;
            this.widthLabel.Text = "Толщина: 5";
            // 
            // penWidthTrBar
            // 
            this.penWidthTrBar.Location = new System.Drawing.Point(3, 204);
            this.penWidthTrBar.Maximum = 350;
            this.penWidthTrBar.Minimum = 1;
            this.penWidthTrBar.Name = "penWidthTrBar";
            this.penWidthTrBar.Size = new System.Drawing.Size(81, 45);
            this.penWidthTrBar.TabIndex = 10;
            this.penWidthTrBar.TickFrequency = 30;
            this.penWidthTrBar.Value = 5;
            this.penWidthTrBar.ValueChanged += new System.EventHandler(this.penWidthTrBar_ValueChanged);
            // 
            // deleterBtn
            // 
            this.deleterBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.deleterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleterBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleterBtn.Image")));
            this.deleterBtn.Location = new System.Drawing.Point(3, 31);
            this.deleterBtn.Name = "deleterBtn";
            this.deleterBtn.Size = new System.Drawing.Size(23, 23);
            this.deleterBtn.TabIndex = 9;
            this.deleterBtn.UseVisualStyleBackColor = false;
            this.deleterBtn.Click += new System.EventHandler(this.deleterBtn_Click);
            // 
            // rectangleBtn
            // 
            this.rectangleBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rectangleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rectangleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rectangleBtn.Image = ((System.Drawing.Image)(resources.GetObject("rectangleBtn.Image")));
            this.rectangleBtn.Location = new System.Drawing.Point(61, 60);
            this.rectangleBtn.Name = "rectangleBtn";
            this.rectangleBtn.Size = new System.Drawing.Size(23, 23);
            this.rectangleBtn.TabIndex = 8;
            this.rectangleBtn.UseVisualStyleBackColor = false;
            this.rectangleBtn.Click += new System.EventHandler(this.rectangleBtn_Click);
            // 
            // cursorBtn
            // 
            this.cursorBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cursorBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cursorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cursorBtn.Image = ((System.Drawing.Image)(resources.GetObject("cursorBtn.Image")));
            this.cursorBtn.Location = new System.Drawing.Point(3, 2);
            this.cursorBtn.Name = "cursorBtn";
            this.cursorBtn.Size = new System.Drawing.Size(23, 23);
            this.cursorBtn.TabIndex = 7;
            this.cursorBtn.UseVisualStyleBackColor = false;
            this.cursorBtn.Click += new System.EventHandler(this.cursorBtn_Click);
            // 
            // altClrPnl
            // 
            this.altClrPnl.BackColor = System.Drawing.Color.White;
            this.altClrPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.altClrPnl.Location = new System.Drawing.Point(25, 178);
            this.altClrPnl.Name = "altClrPnl";
            this.altClrPnl.Size = new System.Drawing.Size(20, 20);
            this.altClrPnl.TabIndex = 6;
            this.altClrPnl.Click += new System.EventHandler(this.altClrPnl_Click);
            // 
            // brushClrPnl
            // 
            this.brushClrPnl.BackColor = System.Drawing.Color.Black;
            this.brushClrPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brushClrPnl.Location = new System.Drawing.Point(8, 163);
            this.brushClrPnl.Name = "brushClrPnl";
            this.brushClrPnl.Size = new System.Drawing.Size(30, 30);
            this.brushClrPnl.TabIndex = 5;
            this.brushClrPnl.Click += new System.EventHandler(this.brushClrPnl_Click);
            // 
            // lineBtn
            // 
            this.lineBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lineBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineBtn.Image = ((System.Drawing.Image)(resources.GetObject("lineBtn.Image")));
            this.lineBtn.Location = new System.Drawing.Point(61, 31);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(23, 23);
            this.lineBtn.TabIndex = 3;
            this.lineBtn.UseVisualStyleBackColor = false;
            this.lineBtn.Click += new System.EventHandler(this.lineBtn_Click);
            // 
            // eraserBtn
            // 
            this.eraserBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.eraserBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eraserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eraserBtn.Image = ((System.Drawing.Image)(resources.GetObject("eraserBtn.Image")));
            this.eraserBtn.Location = new System.Drawing.Point(61, 2);
            this.eraserBtn.Name = "eraserBtn";
            this.eraserBtn.Size = new System.Drawing.Size(23, 23);
            this.eraserBtn.TabIndex = 2;
            this.eraserBtn.UseVisualStyleBackColor = false;
            this.eraserBtn.Click += new System.EventHandler(this.eraserBtn_Click);
            // 
            // swapBtn
            // 
            this.swapBtn.BackColor = System.Drawing.Color.Transparent;
            this.swapBtn.FlatAppearance.BorderSize = 0;
            this.swapBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swapBtn.Image = ((System.Drawing.Image)(resources.GetObject("swapBtn.Image")));
            this.swapBtn.Location = new System.Drawing.Point(10, 147);
            this.swapBtn.Name = "swapBtn";
            this.swapBtn.Size = new System.Drawing.Size(14, 14);
            this.swapBtn.TabIndex = 18;
            this.swapBtn.UseVisualStyleBackColor = false;
            this.swapBtn.Click += new System.EventHandler(this.swapBtn_Click);
            // 
            // statusInfo
            // 
            this.statusInfo.BackColor = System.Drawing.SystemColors.Menu;
            this.statusInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusInfo.CausesValidation = false;
            this.statusInfo.Controls.Add(this.btmStatusStrp);
            this.statusInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusInfo.Location = new System.Drawing.Point(0, 712);
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(1184, 25);
            this.statusInfo.TabIndex = 3;
            // 
            // btmStatusStrp
            // 
            this.btmStatusStrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btmStatusStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlStrpStCoords,
            this.tlStrpStRes,
            this.tlStrpStpFileName});
            this.btmStatusStrp.Location = new System.Drawing.Point(0, 0);
            this.btmStatusStrp.Name = "btmStatusStrp";
            this.btmStatusStrp.Size = new System.Drawing.Size(1182, 23);
            this.btmStatusStrp.TabIndex = 0;
            this.btmStatusStrp.Text = "status";
            // 
            // tlStrpStCoords
            // 
            this.tlStrpStCoords.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlStrpStCoords.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tlStrpStCoords.Name = "tlStrpStCoords";
            this.tlStrpStCoords.Size = new System.Drawing.Size(70, 18);
            this.tlStrpStCoords.Text = "X:342;Y:543";
            // 
            // tlStrpStRes
            // 
            this.tlStrpStRes.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlStrpStRes.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tlStrpStRes.Name = "tlStrpStRes";
            this.tlStrpStRes.Size = new System.Drawing.Size(53, 18);
            this.tlStrpStRes.Text = "800x600";
            // 
            // tlStrpStpFileName
            // 
            this.tlStrpStpFileName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlStrpStpFileName.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tlStrpStpFileName.Name = "tlStrpStpFileName";
            this.tlStrpStpFileName.Size = new System.Drawing.Size(76, 18);
            this.tlStrpStpFileName.Text = "untitled.png";
            // 
            // ColorDialog
            // 
            this.ColorDialog.AnyColor = true;
            this.ColorDialog.FullOpen = true;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "jpg";
            this.SaveFileDialog.Filter = "Jpg|*.jpg|Jpeg|*.jpeg|Png|*.png|Bmp|*.bmp|Emf|*.emf|Wmf|*.wmf|GIF|*.gif|Exif|*.ex" +
    "if|Icon|*.ico|Rpif|*.rpif";
            this.SaveFileDialog.InitialDirectory = "%userprofile%\\Pictures";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "Jpg|*.jpg|Jpeg|*.jpeg|Png|*.png|Bmp|*.bmp|Emf|*.emf|Wmf|*.wmf|GIF|*.gif|Exif|*.ex" +
    "if|Icon|*.ico|Rpif|*.rpif";
            this.OpenFileDialog.InitialDirectory = "%userprofile%\\Pictures";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteToolStripMenuItem.Text = "Удалить (Delete)";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // rasterizeToolStripMenuItem
            // 
            this.rasterizeToolStripMenuItem.Name = "rasterizeToolStripMenuItem";
            this.rasterizeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.rasterizeToolStripMenuItem.Text = "Растеризовать (Ctrl + R)";
            this.rasterizeToolStripMenuItem.Click += new System.EventHandler(this.rasterizeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.canvasPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "RePaint";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.canvasPanel.ResumeLayout(false);
            this.canvasPanel.PerformLayout();
            this.toolBox.ResumeLayout(false);
            this.toolBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthTrBar)).EndInit();
            this.statusInfo.ResumeLayout(false);
            this.statusInfo.PerformLayout();
            this.btmStatusStrp.ResumeLayout(false);
            this.btmStatusStrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.Panel toolBox;
        private System.Windows.Forms.Panel statusInfo;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel paintPanel;
        private System.Windows.Forms.Button brushBtn;
        private System.Windows.Forms.Button eraserBtn;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.Panel altClrPnl;
        private System.Windows.Forms.Panel brushClrPnl;
        private System.Windows.Forms.Button cursorBtn;
        private System.Windows.Forms.Button rectangleBtn;
        private System.Windows.Forms.Button deleterBtn;
        private System.Windows.Forms.TrackBar penWidthTrBar;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.StatusStrip btmStatusStrp;
        private System.Windows.Forms.ToolStripStatusLabel tlStrpStCoords;
        private System.Windows.Forms.ToolStripStatusLabel tlStrpStpFileName;
        private System.Windows.Forms.Button ellipseBtn;
        private System.Windows.Forms.Button ellipsePieBtn;
        private System.Windows.Forms.Button lineBezierBtn;
        private System.Windows.Forms.Panel brushStylePnl;
        private System.Windows.Forms.Button swapBtn;
        public System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Button curveBtn;
        private System.Windows.Forms.Button sprayBtn;
        private System.Windows.Forms.ToolStripStatusLabel tlStrpStRes;
        private System.Windows.Forms.Button penStyleBtn;
        public System.Windows.Forms.SaveFileDialog SaveFileDialog;
        public System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button selectlAllBtn;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.Button bucketBtn;
        private System.Windows.Forms.Button selectAreaBtn;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rasterizeToolStripMenuItem;
    }
}

