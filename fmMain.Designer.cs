
namespace Photo_Selection_Assistant
{
    partial class fmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.pDragDrop = new System.Windows.Forms.Panel();
            this.pLabels = new System.Windows.Forms.Panel();
            this.lblDragDrop = new System.Windows.Forms.Label();
            this.pbxPhotoAndFolder = new System.Windows.Forms.PictureBox();
            this.lblDragDrop2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspAction = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSubfolders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi1x = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi2x = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi3x = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi4x = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiСhangeFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbxFormtas = new System.Windows.Forms.ToolStripComboBox();
            this.tsmiApply = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiСancelSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiСompleteSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tstbxDirectory = new System.Windows.Forms.ToolStripTextBox();
            this.tsmiGo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.tipPicture = new System.Windows.Forms.ToolTip(this.components);
            this.flpThumbnails = new Photo_Selection_Assistant.MyFlowLayoutPanel();
            this.pDragDrop.SuspendLayout();
            this.pLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhotoAndFolder)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDragDrop
            // 
            this.pDragDrop.AllowDrop = true;
            this.pDragDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pDragDrop.BackColor = System.Drawing.Color.White;
            this.pDragDrop.Controls.Add(this.pLabels);
            this.pDragDrop.Location = new System.Drawing.Point(12, 38);
            this.pDragDrop.Name = "pDragDrop";
            this.pDragDrop.Size = new System.Drawing.Size(1270, 619);
            this.pDragDrop.TabIndex = 0;
            this.pDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.pDragDrop_DragDrop);
            this.pDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.pDragDrop_DragEnter);
            this.pDragDrop.DragLeave += new System.EventHandler(this.pDragDrop_DragLeave);
            this.pDragDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.pDragDrop_Paint);
            // 
            // pLabels
            // 
            this.pLabels.BackColor = System.Drawing.Color.White;
            this.pLabels.Controls.Add(this.lblDragDrop);
            this.pLabels.Controls.Add(this.pbxPhotoAndFolder);
            this.pLabels.Controls.Add(this.lblDragDrop2);
            this.pLabels.Location = new System.Drawing.Point(507, 217);
            this.pLabels.Name = "pLabels";
            this.pLabels.Size = new System.Drawing.Size(227, 180);
            this.pLabels.TabIndex = 2;
            // 
            // lblDragDrop
            // 
            this.lblDragDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDragDrop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDragDrop.Location = new System.Drawing.Point(24, 125);
            this.lblDragDrop.Name = "lblDragDrop";
            this.lblDragDrop.Size = new System.Drawing.Size(179, 25);
            this.lblDragDrop.TabIndex = 0;
            this.lblDragDrop.Text = "Перетащите сюда";
            this.lblDragDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxPhotoAndFolder
            // 
            this.pbxPhotoAndFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxPhotoAndFolder.BackgroundImage")));
            this.pbxPhotoAndFolder.Location = new System.Drawing.Point(0, 1);
            this.pbxPhotoAndFolder.Name = "pbxPhotoAndFolder";
            this.pbxPhotoAndFolder.Size = new System.Drawing.Size(227, 119);
            this.pbxPhotoAndFolder.TabIndex = 10;
            this.pbxPhotoAndFolder.TabStop = false;
            // 
            // lblDragDrop2
            // 
            this.lblDragDrop2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDragDrop2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDragDrop2.Location = new System.Drawing.Point(3, 155);
            this.lblDragDrop2.Name = "lblDragDrop2";
            this.lblDragDrop2.Size = new System.Drawing.Size(221, 17);
            this.lblDragDrop2.TabIndex = 1;
            this.lblDragDrop2.Text = "Фотографию или папку\r\n";
            this.lblDragDrop2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslCount,
            this.tslSelected,
            this.tslAction,
            this.tspAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1294, 22);
            this.statusStrip1.TabIndex = 13;
            // 
            // tslCount
            // 
            this.tslCount.Name = "tslCount";
            this.tslCount.Size = new System.Drawing.Size(50, 17);
            this.tslCount.Text = "Всего: 0";
            // 
            // tslSelected
            // 
            this.tslSelected.Name = "tslSelected";
            this.tslSelected.Size = new System.Drawing.Size(69, 17);
            this.tslSelected.Text = "Выбрано: 0";
            // 
            // tslAction
            // 
            this.tslAction.ForeColor = System.Drawing.Color.DarkRed;
            this.tslAction.Name = "tslAction";
            this.tslAction.Size = new System.Drawing.Size(1160, 17);
            this.tslAction.Spring = true;
            this.tslAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tspAction
            // 
            this.tspAction.Name = "tspAction";
            this.tspAction.Size = new System.Drawing.Size(200, 16);
            this.tspAction.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem,
            this.tsmiSettings,
            this.sizeToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.tsmiСompleteSelection,
            this.tstbxDirectory,
            this.tsmiGo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.menuStrip1.Size = new System.Drawing.Size(1294, 29);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiSubfolders,
            this.toolStripSeparator1,
            this.tsmiClear});
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.folderToolStripMenuItem.Text = "Папка";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOpen.Image")));
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.ShortcutKeyDisplayString = "(Ctrl+O)";
            this.tsmiOpen.Size = new System.Drawing.Size(176, 22);
            this.tsmiOpen.Text = "Открыть";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiSubfolders
            // 
            this.tsmiSubfolders.Name = "tsmiSubfolders";
            this.tsmiSubfolders.Size = new System.Drawing.Size(176, 22);
            this.tsmiSubfolders.Text = "Вложенные папки";
            this.tsmiSubfolders.Click += new System.EventHandler(this.tsmiSubfolders_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Image = ((System.Drawing.Image)(resources.GetObject("tsmiClear.Image")));
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.ShortcutKeyDisplayString = "(Ctrl+D)";
            this.tsmiClear.Size = new System.Drawing.Size(176, 22);
            this.tsmiClear.Text = "Очистить";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiSettings.Size = new System.Drawing.Size(79, 23);
            this.tsmiSettings.Text = "Настройки";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi1x,
            this.tsmi2x,
            this.tsmi3x,
            this.tsmi4x});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.sizeToolStripMenuItem.Text = "Масштаб";
            // 
            // tsmi1x
            // 
            this.tsmi1x.Checked = true;
            this.tsmi1x.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmi1x.Name = "tsmi1x";
            this.tsmi1x.Size = new System.Drawing.Size(85, 22);
            this.tsmi1x.Text = "1x";
            this.tsmi1x.Click += new System.EventHandler(this.tsmi1x_Click);
            // 
            // tsmi2x
            // 
            this.tsmi2x.Name = "tsmi2x";
            this.tsmi2x.Size = new System.Drawing.Size(85, 22);
            this.tsmi2x.Text = "2x";
            this.tsmi2x.Click += new System.EventHandler(this.tsmi2x_Click);
            // 
            // tsmi3x
            // 
            this.tsmi3x.Name = "tsmi3x";
            this.tsmi3x.Size = new System.Drawing.Size(85, 22);
            this.tsmi3x.Text = "3x";
            this.tsmi3x.Click += new System.EventHandler(this.tsmi3x_Click);
            // 
            // tsmi4x
            // 
            this.tsmi4x.Name = "tsmi4x";
            this.tsmi4x.Size = new System.Drawing.Size(85, 22);
            this.tsmi4x.Text = "4x";
            this.tsmi4x.Click += new System.EventHandler(this.tsmi4x_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.selectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiСhangeFormat,
            this.toolStripSeparator2,
            this.tsmiSelectAll,
            this.tsmiСancelSelect});
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
            this.selectToolStripMenuItem.Text = "Выбор";
            // 
            // tsmiСhangeFormat
            // 
            this.tsmiСhangeFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbxFormtas,
            this.tsmiApply});
            this.tsmiСhangeFormat.Name = "tsmiСhangeFormat";
            this.tsmiСhangeFormat.Size = new System.Drawing.Size(174, 22);
            this.tsmiСhangeFormat.Text = "Изменить формат";
            // 
            // tscbxFormtas
            // 
            this.tscbxFormtas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbxFormtas.Name = "tscbxFormtas";
            this.tscbxFormtas.Size = new System.Drawing.Size(121, 23);
            this.tscbxFormtas.DropDownClosed += new System.EventHandler(this.tscbxFormtas_DropDownClosed);
            // 
            // tsmiApply
            // 
            this.tsmiApply.Name = "tsmiApply";
            this.tsmiApply.Size = new System.Drawing.Size(181, 22);
            this.tsmiApply.Text = "Применить";
            this.tsmiApply.Click += new System.EventHandler(this.tsmiApply_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            this.tsmiSelectAll.Size = new System.Drawing.Size(174, 22);
            this.tsmiSelectAll.Text = "Выбрать все";
            this.tsmiSelectAll.Click += new System.EventHandler(this.tsmiSelectAll_Click);
            // 
            // tsmiСancelSelect
            // 
            this.tsmiСancelSelect.Name = "tsmiСancelSelect";
            this.tsmiСancelSelect.Size = new System.Drawing.Size(174, 22);
            this.tsmiСancelSelect.Text = "Отменить выбор";
            this.tsmiСancelSelect.Click += new System.EventHandler(this.tsmiСancelSelect_Click);
            // 
            // tsmiСompleteSelection
            // 
            this.tsmiСompleteSelection.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmiСompleteSelection.Image = ((System.Drawing.Image)(resources.GetObject("tsmiСompleteSelection.Image")));
            this.tsmiСompleteSelection.Name = "tsmiСompleteSelection";
            this.tsmiСompleteSelection.Size = new System.Drawing.Size(138, 23);
            this.tsmiСompleteSelection.Text = " Завершить выбор";
            this.tsmiСompleteSelection.Click += new System.EventHandler(this.tsmiСompleteSelection_Click);
            // 
            // tstbxDirectory
            // 
            this.tstbxDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbxDirectory.Name = "tstbxDirectory";
            this.tstbxDirectory.Size = new System.Drawing.Size(550, 23);
            // 
            // tsmiGo
            // 
            this.tsmiGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiGo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiGo.Image")));
            this.tsmiGo.Name = "tsmiGo";
            this.tsmiGo.Size = new System.Drawing.Size(28, 23);
            this.tsmiGo.Click += new System.EventHandler(this.tsmiGo_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenImage,
            this.tsmiAddFormat});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 48);
            // 
            // tsmiOpenImage
            // 
            this.tsmiOpenImage.Name = "tsmiOpenImage";
            this.tsmiOpenImage.Size = new System.Drawing.Size(145, 22);
            this.tsmiOpenImage.Text = "Открыть";
            this.tsmiOpenImage.Click += new System.EventHandler(this.tsmiOpenImage_Click);
            // 
            // tsmiAddFormat
            // 
            this.tsmiAddFormat.Name = "tsmiAddFormat";
            this.tsmiAddFormat.Size = new System.Drawing.Size(145, 22);
            this.tsmiAddFormat.Text = "Доп. формат";
            this.tsmiAddFormat.Click += new System.EventHandler(this.tsmiAddFormat_Click);
            // 
            // flpThumbnails
            // 
            this.flpThumbnails.AllowDrop = true;
            this.flpThumbnails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpThumbnails.AutoScroll = true;
            this.flpThumbnails.BackColor = System.Drawing.Color.White;
            this.flpThumbnails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpThumbnails.Location = new System.Drawing.Point(12, 38);
            this.flpThumbnails.Name = "flpThumbnails";
            this.flpThumbnails.Size = new System.Drawing.Size(1270, 619);
            this.flpThumbnails.TabIndex = 14;
            this.flpThumbnails.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpThumbnails_DragEnter);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1294, 682);
            this.Controls.Add(this.pDragDrop);
            this.Controls.Add(this.flpThumbnails);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1310, 720);
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Помощник по выбору фотографий";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmMain_KeyDown);
            this.Resize += new System.EventHandler(this.fmMain_Resize);
            this.pDragDrop.ResumeLayout(false);
            this.pLabels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhotoAndFolder)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.Panel pDragDrop;
        private System.Windows.Forms.Label lblDragDrop;
        private System.Windows.Forms.Label lblDragDrop2;
        private System.Windows.Forms.Panel pLabels;
        private System.Windows.Forms.PictureBox pbxPhotoAndFolder;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslCount;
        private System.Windows.Forms.ToolStripStatusLabel tslSelected;
        private System.Windows.Forms.ToolStripStatusLabel tslAction;
        private System.Windows.Forms.ToolStripProgressBar tspAction;
        private System.Windows.Forms.Timer timer1;
        private MyFlowLayoutPanel flpThumbnails;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiСhangeFormat;
        private System.Windows.Forms.ToolStripComboBox tscbxFormtas;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiSubfolders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.ToolStripTextBox tstbxDirectory;
        private System.Windows.Forms.ToolStripMenuItem tsmiGo;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiСompleteSelection;
        private System.Windows.Forms.ToolStripMenuItem tsmi1x;
        private System.Windows.Forms.ToolStripMenuItem tsmi2x;
        private System.Windows.Forms.ToolStripMenuItem tsmi3x;
        private System.Windows.Forms.ToolStripMenuItem tsmi4x;
        private System.Windows.Forms.ToolStripMenuItem tsmiApply;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiСancelSelect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFormat;
        private System.Windows.Forms.ToolTip tipPicture;
    }
}

