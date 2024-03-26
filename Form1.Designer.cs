namespace LW2Graphics
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            objectPositionlabel = new Label();
            placeObjectButton = new Button();
            applyButton = new Button();
            inputLabel2 = new Label();
            input2 = new TextBox();
            inputLabel1 = new Label();
            input1 = new TextBox();
            startLabel = new Label();
            menuStrip1 = new MenuStrip();
            choiseToolStripMenuItem = new ToolStripMenuItem();
            changePositionToolStripMenuItem = new ToolStripMenuItem();
            flipObjectToolStripMenuItem = new ToolStripMenuItem();
            changeSizeToolStripMenuItem = new ToolStripMenuItem();
            pictureBox = new PictureBox();
            contextMenuStrip = new ContextMenuStrip(components);
            restoreInitialObject = new ToolStripMenuItem();
            fillObjectToolStripMenuItem = new ToolStripMenuItem();
            colorDialog1 = new ColorDialog();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(objectPositionlabel);
            panel1.Controls.Add(placeObjectButton);
            panel1.Controls.Add(applyButton);
            panel1.Controls.Add(inputLabel2);
            panel1.Controls.Add(input2);
            panel1.Controls.Add(inputLabel1);
            panel1.Controls.Add(input1);
            panel1.Controls.Add(startLabel);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(859, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 715);
            panel1.TabIndex = 0;
            // 
            // objectPositionlabel
            // 
            objectPositionlabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            objectPositionlabel.Location = new Point(106, 490);
            objectPositionlabel.Name = "objectPositionlabel";
            objectPositionlabel.Size = new Size(131, 57);
            objectPositionlabel.TabIndex = 8;
            objectPositionlabel.Text = "Расположение объекта";
            objectPositionlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // placeObjectButton
            // 
            placeObjectButton.BackColor = Color.FromArgb(0, 192, 0);
            placeObjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            placeObjectButton.ForeColor = Color.FromArgb(128, 255, 128);
            placeObjectButton.Location = new Point(90, 550);
            placeObjectButton.Name = "placeObjectButton";
            placeObjectButton.Size = new Size(168, 40);
            placeObjectButton.TabIndex = 7;
            placeObjectButton.Text = "По центру";
            placeObjectButton.UseVisualStyleBackColor = false;
            placeObjectButton.Click += PlaceObjectButton_Click;
            placeObjectButton.KeyDown += Form1_KeyDown;
            // 
            // applyButton
            // 
            applyButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            applyButton.Location = new Point(123, 348);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(114, 50);
            applyButton.TabIndex = 6;
            applyButton.Text = "Применить";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Visible = false;
            applyButton.Click += ApplyButton_Click;
            // 
            // inputLabel2
            // 
            inputLabel2.Font = new Font("Segoe UI", 12F);
            inputLabel2.Location = new Point(201, 163);
            inputLabel2.Name = "inputLabel2";
            inputLabel2.Size = new Size(128, 107);
            inputLabel2.TabIndex = 5;
            inputLabel2.Text = "Ввод второго значения";
            inputLabel2.TextAlign = ContentAlignment.MiddleCenter;
            inputLabel2.Visible = false;
            // 
            // input2
            // 
            input2.Location = new Point(215, 273);
            input2.Name = "input2";
            input2.Size = new Size(100, 23);
            input2.TabIndex = 4;
            input2.Visible = false;
            input2.KeyDown += Form1_KeyDown;
            // 
            // inputLabel1
            // 
            inputLabel1.Font = new Font("Segoe UI", 12F);
            inputLabel1.Location = new Point(26, 163);
            inputLabel1.Name = "inputLabel1";
            inputLabel1.Size = new Size(128, 107);
            inputLabel1.TabIndex = 3;
            inputLabel1.Text = "Ввод первого значения";
            inputLabel1.TextAlign = ContentAlignment.MiddleCenter;
            inputLabel1.Visible = false;
            // 
            // input1
            // 
            input1.Location = new Point(40, 273);
            input1.Name = "input1";
            input1.Size = new Size(100, 23);
            input1.TabIndex = 2;
            input1.Visible = false;
            input1.KeyDown += Form1_KeyDown;
            // 
            // startLabel
            // 
            startLabel.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            startLabel.Location = new Point(52, 106);
            startLabel.MaximumSize = new Size(262, 0);
            startLabel.Name = "startLabel";
            startLabel.Size = new Size(262, 0);
            startLabel.TabIndex = 1;
            startLabel.Text = "Выберите действие, которое необходимо выполнить";
            startLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { choiseToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(350, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // choiseToolStripMenuItem
            // 
            choiseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changePositionToolStripMenuItem, flipObjectToolStripMenuItem, changeSizeToolStripMenuItem });
            choiseToolStripMenuItem.Name = "choiseToolStripMenuItem";
            choiseToolStripMenuItem.Size = new Size(108, 20);
            choiseToolStripMenuItem.Text = "Выбор действия";
            // 
            // changePositionToolStripMenuItem
            // 
            changePositionToolStripMenuItem.Name = "changePositionToolStripMenuItem";
            changePositionToolStripMenuItem.Size = new Size(204, 22);
            changePositionToolStripMenuItem.Text = "Передвинуть объект";
            changePositionToolStripMenuItem.Click += ChangePositionToolStripMenuItem_Click;
            // 
            // flipObjectToolStripMenuItem
            // 
            flipObjectToolStripMenuItem.Name = "flipObjectToolStripMenuItem";
            flipObjectToolStripMenuItem.Size = new Size(204, 22);
            flipObjectToolStripMenuItem.Text = "Повернуть объект";
            flipObjectToolStripMenuItem.Click += FlipObjectToolStripMenuItem_Click;
            // 
            // changeSizeToolStripMenuItem
            // 
            changeSizeToolStripMenuItem.Name = "changeSizeToolStripMenuItem";
            changeSizeToolStripMenuItem.Size = new Size(204, 22);
            changeSizeToolStripMenuItem.Text = "Сжать (разжать) объект";
            changeSizeToolStripMenuItem.Click += ChangeSizeToolStripMenuItem_Click;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(859, 715);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.MouseClick += PictureBox_MouseClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { restoreInitialObject, fillObjectToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(256, 48);
            // 
            // restoreInitialObject
            // 
            restoreInitialObject.Name = "restoreInitialObject";
            restoreInitialObject.Size = new Size(255, 22);
            restoreInitialObject.Text = "Восстановить начальный объект";
            restoreInitialObject.Click += RestoreInitialObject_Click;
            // 
            // fillObjectToolStripMenuItem
            // 
            fillObjectToolStripMenuItem.Name = "fillObjectToolStripMenuItem";
            fillObjectToolStripMenuItem.Size = new Size(255, 22);
            fillObjectToolStripMenuItem.Text = "Закрасить объект";
            fillObjectToolStripMenuItem.Click += FillObjectToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 715);
            Controls.Add(pictureBox);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1224, 752);
            Name = "Form1";
            Text = "ЛР2 Никончук ВИ КЭ-243";
            SizeChanged += Form1_SizeChanged;
            KeyDown += Form1_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem choiseToolStripMenuItem;
        private ToolStripMenuItem changePositionToolStripMenuItem;
        private ToolStripMenuItem flipObjectToolStripMenuItem;
        private ToolStripMenuItem changeSizeToolStripMenuItem;
        private Label startLabel;
        private TextBox input1;
        private PictureBox pictureBox;
        private Label inputLabel2;
        private TextBox input2;
        private Label inputLabel1;
        private Button applyButton;
        private Button placeObjectButton;
        private Label objectPositionlabel;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem restoreInitialObject;
        private ToolStripMenuItem fillObjectToolStripMenuItem;
        private ColorDialog colorDialog1;
    }
}
