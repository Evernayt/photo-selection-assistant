using Photo_Selection_Assistant.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Selection_Assistant
{
    public partial class fmMain : Form
    {
        string path;
        string[] formats;
        bool dropped, subfolders = false;
        int thumbSize;     // Размеры эскизов.
        int averageSize, numSelected;
        int folderCount = 1;

        List<(string, string, int)> picInfo = new List<(string, string, int)>();    // Путь, формат, копии.                                                                     
        List<PictureBox> PictureBoxes = new List<PictureBox>();                     // Список для хранения фото, чтобы знать какие фото удалять.
        List<NumericUpDown> NumericUpDowns = new List<NumericUpDown>();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<PictureBox> CheckPictureBoxes = new List<PictureBox>();

        FileInfo file_info;
        PictureBox tempPic;

        Color selectedColor = Color.FromArgb(70, 163, 74);
        Color dndBorderColor = Color.DimGray;
        Color errorColor = Color.DarkRed;
        Color goodColor = Color.Green;

        public fmMain()
        {
            InitializeComponent();
        }

        public void fmMain_Load(object sender, EventArgs e)
        {
            subfolders = Settings.Default.subfolders;
            tsmiSubfolders.Checked = subfolders;

            SizeUnchecker();

            switch (Settings.Default.size)
            {
                case "1x":
                    thumbSize = 200;
                    tsmi1x.Checked = true;
                    break;
                case "2x":
                    thumbSize = 300;
                    tsmi2x.Checked = true;
                    break;
                case "3x":
                    thumbSize = 400;
                    tsmi3x.Checked = true;
                    break;
                case "4x":
                    thumbSize = 500;
                    tsmi4x.Checked = true;
                    break;
            }

            formats = Settings.Default.allFormtas.Split(',');
            tscbxFormtas.Items.AddRange(formats);
            tscbxFormtas.SelectedIndex = 0;
            pDragDrop.Select();
        }

        private void DnDLabel(string h1, string h2)
        {
            lblDragDrop.Text = h1;
            lblDragDrop2.Text = h2;
        }

        private void MemoryCleaner()
        {

            foreach (NumericUpDown nud in NumericUpDowns)
            {
                nud.KeyDown -= nudCopies_KeyDown;
                nud.ValueChanged -= nudCopies_ValueChanged;
                nud.Dispose();
            }

            foreach (ComboBox cbx in ComboBoxes)
            {
                cbx.DrawItem += cbxFormtas_DrawItem;
                cbx.DropDownClosed += cbxFormats_DropDownClosed;
                cbx.Dispose();
            }

            foreach (PictureBox picCheck in CheckPictureBoxes)
            {
                picCheck.Image.Dispose();
                picCheck.Dispose();
            }

            foreach (PictureBox pic in PictureBoxes)
            {
                pic.MouseClick -= PictureBox_MouseClick;
                pic.Image.Dispose();
                pic.Controls.Clear();
                pic.Dispose();
            }

            flpThumbnails.Controls.Clear();
        }

        // Показать эскизы для выбранного каталога.
        private async void SetDirectory()
        {
            if (tstbxDirectory.Text == "")
            {
                Notification("Папка не выбрана", errorColor);
                return;
            }
            else if (!Directory.Exists(tstbxDirectory.Text))
            {
                Notification("Выбранная папка не существует", errorColor);
                return;
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                DnDLabel("Загружаю", "Пожалуйста, подождите");
                await Task.Delay(500);

                SearchOption searchOption;

                if (subfolders)
                    searchOption = SearchOption.AllDirectories;
                else
                    searchOption = SearchOption.TopDirectoryOnly;

                MemoryCleaner();

                PictureBoxes = new List<PictureBox>();

                // Получить имена файлов в каталоге.
                List<string> filenames = new List<string>();
                string[] patterns = { "*.png", "*.jpg", "*.bmp", "*.tif", "*.jpeg" };
                foreach (string pattern in patterns)
                {
                    filenames.AddRange(Directory.GetFiles(tstbxDirectory.Text,
                        pattern, searchOption));
                }
                filenames.Sort();

                if (filenames.Count > 0)
                {
                    averageSize = thumbSize / 2;
                    picInfo.Clear();

                    TimerTicked();
                    tspAction.Visible = true;
                    tspAction.Maximum = filenames.Count;
                    tslCount.Text = $"Всего: { filenames.Count }";
                    numSelected = 0;
                    tslSelected.Text = $"Выбрано: { numSelected }";

                    // Загрузить файлы.
                    foreach (string filename in filenames)
                    {
                        // Загрузить изображение в PictureBox.
                        PictureBox pic = new PictureBox
                        {
                            ClientSize = new Size(thumbSize, thumbSize),
                            Image = new Bitmap(filename),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Если изображение слишком большое, то изменить режим.
                        if ((pic.Image.Width > thumbSize) || (pic.Image.Height > thumbSize))
                            pic.SizeMode = PictureBoxSizeMode.Zoom;
                        else
                            pic.SizeMode = PictureBoxSizeMode.CenterImage;

                        // Добавить обработчик событий MouseClick.
                        pic.MouseClick += PictureBox_MouseClick;

                        file_info = new FileInfo(filename);
                        tipPicture.SetToolTip(pic, file_info.Name +
                            $"\nРазмеры: { pic.Image.Width } x { pic.Image.Height }");
                        pic.Tag = file_info;

                        // Добавить PictureBox в FlowLayoutPanel.
                        pic.Parent = flpThumbnails;

                        #region NumericUpDown под PictureBox
                        NumericUpDown nudCopies = new NumericUpDown
                        {
                            BorderStyle = BorderStyle.FixedSingle,
                            TextAlign = HorizontalAlignment.Center,
                            Font = new Font("Segoe UI", 9.75F),
                            ClientSize = new Size(averageSize, 0)
                        };
                        nudCopies.Location = new Point(-1, thumbSize - nudCopies.Height);
                        nudCopies.Parent = pic;

                        nudCopies.KeyDown += nudCopies_KeyDown;
                        nudCopies.ValueChanged += nudCopies_ValueChanged;
                        #endregion

                        #region ComboBox под PictureBox
                        ComboBox cbxFormats = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Font = new Font("Segoe UI", 9.75F),
                            ClientSize = new Size(averageSize - 4, 0),
                            DrawMode = DrawMode.OwnerDrawFixed
                        };
                        cbxFormats.Items.AddRange(formats);
                        cbxFormats.SelectedIndex = 0;
                        cbxFormats.Location = new Point(averageSize - 1, thumbSize - cbxFormats.Height + 1);
                        cbxFormats.Parent = pic;

                        cbxFormats.DrawItem += cbxFormtas_DrawItem;
                        cbxFormats.DropDownClosed += cbxFormats_DropDownClosed;
                        #endregion

                        #region Галочка в углу PictureBox
                        PictureBox picCheck = new PictureBox
                        {
                            ClientSize = new Size(24, 24),
                            Image = Resources.check24,
                            Location = new Point(thumbSize - 30, 5),
                            Visible = false,
                            Parent = pic
                        };
                        #endregion

                        PictureBoxes.Add(pic);
                        NumericUpDowns.Add(nudCopies);
                        ComboBoxes.Add(cbxFormats);
                        CheckPictureBoxes.Add(picCheck);

                        tspAction.Value++;
                    }

                    timer1.Start();
                }

                Cursor = Cursors.Default;
                Notification("Загружено", goodColor);

                pDragDrop.Visible = false;
                flpThumbnails.Focus();
            }
        }

        private void cbxFormtas_DrawItem(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                // Always draw the background
                e.DrawBackground();

                // Drawing one of the items?
                if (e.Index >= 0)
                {
                    // Set the string alignment.  Choices are Center, Near and Far
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
                    // Assumes Brush is solid
                    Brush brush = new SolidBrush(cbx.ForeColor);

                    // If drawing highlighted selection, change brush
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    // Draw the string
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            if (e.Button == MouseButtons.Left)
            {
                NumericUpDown nudCopies = null;

                foreach (NumericUpDown nud in pic.Controls.OfType<NumericUpDown>())
                    if (nud.Name != "nudTemp")
                        nudCopies = nud;

                nudCopies.Value = pic.BackColor == selectedColor ? 0 : 1;
            }
            else if (e.Button == MouseButtons.Right)
            {
                file_info = pic.Tag as FileInfo;
                tempPic = pic;

                if (pic.Controls.Count == 3)
                    tsmiAddFormat.Checked = false;
                else
                    tsmiAddFormat.Checked = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void nudCopies_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numeric = sender as NumericUpDown;
            Control pic = numeric.Parent;
            PictureBox pictureBox = null;

            foreach (PictureBox picCheck in pic.Controls.OfType<PictureBox>())
                pictureBox = picCheck;

            if (numeric.Value > 0)
            {
                pic.BackColor = selectedColor;
                pictureBox.Visible = true;
            }
            else
            {
                pic.BackColor = Color.White;
                pictureBox.Visible = false;
            }

            #region Посчитать количество выбранных фото
            numSelected = 0;

            foreach (PictureBox picTemp in PictureBoxes)
                if (picTemp.BackColor == selectedColor)
                    numSelected++;

            tslSelected.Text = $"Выбрано: { numSelected }";
            #endregion
        }

        private void pDragDrop_DragDrop(object sender, DragEventArgs e)
        {
            DnDLabel("Загружаю", "Пожалуйста, подождите");

            path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            if (Directory.Exists(path))
            {
                tstbxDirectory.Text = path;
            }  
            else
            {
                if (Directory.Exists(Path.GetDirectoryName(path)))
                {
                    tstbxDirectory.Text = Path.GetDirectoryName(path);
                    path = Path.GetDirectoryName(path);
                }
            }

            SetDirectory();

            dropped = true;
        }

        private void pDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                DnDLabel("Отпустите кнопку", "Чтобы начать загрузку");
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pDragDrop_DragLeave(object sender, EventArgs e)
        {
            DnDLabel("Перетащите сюда", "Фотографию или папку");

            if (dropped)
                pDragDrop.Visible = false;
        }

        private void CopySelectedImages(string imagePath)
        {
            FileInfo file = new FileInfo(imagePath);
            string drive = Path.GetPathRoot(file.FullName);

            DriveInfo di = new DriveInfo(drive);
            long diskSize = di.AvailableFreeSpace;
            long totalSize = 0;
            string fullPath = path + "\\" + Settings.Default.folderName + "_" + folderCount++;

            for (int i = 0; i < picInfo.Count; i++)
            {
                file = new FileInfo(picInfo[i].Item1);
                totalSize += file.Length;
            }

            if (totalSize < diskSize)
            {
                if (Directory.Exists(fullPath))
                    fullPath += "_";

                Directory.CreateDirectory(fullPath);

                for (int i = 0; i < picInfo.Count; i++)
                {
                    // Создаем папку с форматами и кол-вом копий внутри этих папок с форматами
                    picInfo.Select(x => x.Item2).Distinct();
                    Directory.CreateDirectory(fullPath + "\\" + picInfo[i].Item2 + "\\" + picInfo[i].Item3 + " шт");

                    imagePath = fullPath + "\\" + picInfo[i].Item2 + "\\" + picInfo[i].Item3 + " шт\\" + i + Path.GetFileName(picInfo[i].Item1);
                    // Копируем фотки по нужным папкам
                    if (!File.Exists(imagePath))
                        File.Copy(picInfo[i].Item1, imagePath);

                    tspAction.Value++;
                }

                Notification("Копирование завершено", goodColor);

                DialogResult result = MessageBox.Show("Копирование завершено.\nОткрыть папку с выбранными фотографиями?", 
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    Process.Start(fullPath);
            }
            else
            {
                Notification($"Недостаточно места на диске { di }", errorColor);

                DialogResult result2 = MessageBox.Show($"Недостаточно места на диске { di }.\nНажмите ОК, чтобы указать другую директорию для выбранных фотографий.", 
                    Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result2 == DialogResult.OK)
                {
                    if (fbdDirectory.ShowDialog() == DialogResult.OK)
                        CopySelectedImages(fbdDirectory.SelectedPath);
                }
            }

            Cursor = Cursors.Default;
        }

        private void pDragDrop_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(dndBorderColor, 2)
            {
                DashPattern = new float[] { 4, 4 }
            };
            e.Graphics.DrawRectangle(pen, 1, 1, pDragDrop.Width - 2, pDragDrop.Height - 2);
        }

        private void flpThumbnails_DragEnter(object sender, DragEventArgs e)
        {
            pDragDrop.Visible = true;
        }

        private void fmMain_Resize(object sender, EventArgs e)
        {
            if (pDragDrop.Visible)
            {
                pLabels.Location = new Point(((pDragDrop.ClientSize.Width - pLabels.Width) / 2) - 8,
                   ((pDragDrop.ClientSize.Height - pLabels.Height) / 2) - 19);

                Refresh();
            }
        }

        private void nudCopies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                flpThumbnails.Focus();
        }

        private void cbxFormats_DropDownClosed(object sender, EventArgs e)
        {
            flpThumbnails.Focus();
        }

        private void TimerTicked()
        {
            tspAction.Value = 0;
            tspAction.Visible = false;
            tslAction.Text = "";
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerTicked();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = tstbxDirectory.Text;

            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                path = fbdDirectory.SelectedPath;
                tstbxDirectory.Text = path;

                SetDirectory();
            }

            flpThumbnails.Focus();
        }

        private void tsmiGo_Click(object sender, EventArgs e)
        {
            SetDirectory();
        }

        private void tsmiСompleteSelection_Click(object sender, EventArgs e)
        {
            if (numSelected > 0)
            {
                Cursor = Cursors.WaitCursor;

                picInfo.Clear();

                int copies = 1;
                string format = "";
                int copiesTemp = 1;
                string formatTemp = "";

                foreach (PictureBox pic in flpThumbnails.Controls.OfType<PictureBox>())
                {
                    if (pic.BackColor == selectedColor)
                    {
                        file_info = pic.Tag as FileInfo;

                        foreach (NumericUpDown nud in pic.Controls.OfType<NumericUpDown>())
                        {
                            if (nud.Name == "nudTemp")
                            {
                                NumericUpDown nudCopiesTemp = nud;
                                copiesTemp = Convert.ToInt32(nudCopiesTemp.Value);
                            }
                            else
                            {
                                NumericUpDown nudCopies = nud;
                                copies = Convert.ToInt32(nudCopies.Value);
                            }
                        }

                        foreach (ComboBox cbx in pic.Controls.OfType<ComboBox>())
                        {
                            if (cbx.Name == "cbxTemp")
                            {
                                ComboBox cbxFormatsTemp = cbx;
                                formatTemp = cbxFormatsTemp.Text;
                            }
                            else
                            {
                                ComboBox cbxFormats = cbx;
                                format = cbxFormats.Text;
                            }
                        }

                        picInfo.Add((file_info.FullName, format, copies));

                        if (formatTemp != "")
                            picInfo.Add((file_info.FullName, formatTemp, copiesTemp));

                        copiesTemp = 1;
                        formatTemp = "";
                    }
                }

                TimerTicked();
                tspAction.Visible = true;
                tspAction.Maximum = picInfo.Count;

                CopySelectedImages(path);
            }
            else
            {
                Notification("Ничего не выбрано", errorColor);
                flpThumbnails.Focus();
            }
        }

        private void SizeUnchecker()
        {
            tsmi1x.Checked = false;
            tsmi2x.Checked = false;
            tsmi3x.Checked = false;
            tsmi4x.Checked = false;
        }

        private void SizeSwitcher(int size)
        {
            SizeUnchecker();

            thumbSize = size;
            averageSize = thumbSize / 2;

            foreach (PictureBox pic in PictureBoxes)
            {
                pic.ClientSize = new Size(thumbSize, thumbSize);
            }

            foreach (NumericUpDown nudCopies in NumericUpDowns)
            {
                nudCopies.ClientSize = new Size(averageSize, 0);

                if (nudCopies.Name != "nudTemp")
                    nudCopies.Location = new Point(-1, thumbSize - nudCopies.Height + 1);
                else
                    nudCopies.Location = new Point(-1, thumbSize - nudCopies.Height * 2 + 1);
            }

            foreach (ComboBox cbxFormats in ComboBoxes)
            {
                cbxFormats.ClientSize = new Size(averageSize - 2, 0);

                if (cbxFormats.Name != "cbxTemp")
                    cbxFormats.Location = new Point(averageSize - 1, thumbSize - cbxFormats.Height + 2);
                else
                    cbxFormats.Location = new Point(averageSize - 1, thumbSize - cbxFormats.Height * 2 + 2);
            }

            foreach (PictureBox checkPic in CheckPictureBoxes)
            {
                checkPic.Location = new Point(thumbSize - 30, 5);
            }

            flpThumbnails.Focus();
        }

        private void tsmi1x_Click(object sender, EventArgs e)
        {
            SizeSwitcher(200);
            tsmi1x.Checked = true;
        }

        private void tsmi2x_Click(object sender, EventArgs e)
        {
            SizeSwitcher(300);
            tsmi2x.Checked = true;
        }

        private void tsmi3x_Click(object sender, EventArgs e)
        {
            SizeSwitcher(400);
            tsmi3x.Checked = true;
        }

        private void tsmi4x_Click(object sender, EventArgs e)
        {
            SizeSwitcher(500);
            tsmi4x.Checked = true;
        }

        private void tsmiApply_Click(object sender, EventArgs e)
        {
            if (tslSelected.Text != "Выбрано: 0")
            {
                foreach (PictureBox pic in flpThumbnails.Controls.OfType<PictureBox>())
                {
                    if (pic.BackColor == selectedColor)
                    {
                        foreach (ComboBox cbx in pic.Controls.OfType<ComboBox>())
                        {
                            ComboBox cbxFormats = cbx;
                            cbxFormats.SelectedItem = tscbxFormtas.SelectedItem;
                        }
                    }
                }

                Notification("Формат изменен", goodColor);
            }
            else
            {
                Notification("Ничего не выбрано", errorColor);
            }
        }

        private void tscbxFormtas_DropDownClosed(object sender, EventArgs e)
        {
            flpThumbnails.Focus();
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            if (tslCount.Text != "Всего: 0")
            {
                foreach (NumericUpDown nudCopies in NumericUpDowns)
                {
                    if (nudCopies.Value == 0)
                        nudCopies.Value = 1;
                }
            }
            else
            {
                Notification("Ничего не загружено", errorColor);
            }
        }

        private void tsmiСancelSelect_Click(object sender, EventArgs e)
        {
            if (tslSelected.Text != "Выбрано: 0")
            {
                foreach (NumericUpDown nudCopies in NumericUpDowns)
                {
                    if (nudCopies.Value > 0)
                        nudCopies.Value = 0;
                }
            }
            else
            {
                Notification("Ничего не выбрано", errorColor);
            }
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            if (tslCount.Text != "Всего: 0")
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите очистить загруженные фотографии?",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    tstbxDirectory.Text = null;
                    pDragDrop.Visible = true;
                    lblDragDrop.Text = "Перетащите сюда";
                    lblDragDrop2.Text = "Фотографию или папку";
                    dropped = false;
                    tspAction.Visible = false;
                    tslCount.Text = "Всего: 0";
                    tslSelected.Text = "Выбрано: 0";
                    MemoryCleaner();
                    Notification("Очищено", goodColor);
                }
            }
            else
            {
                Notification("Ничего не загружено", errorColor);
            }

            flpThumbnails.Select();
            fmMain_Resize(null, null);
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            using (fmSettings fmSettings = new fmSettings())
                fmSettings.ShowDialog();
        }

        private void tsmiOpenImage_Click(object sender, EventArgs e)
        {
            Process.Start(file_info.FullName);
        }

        private void tsmiAddFormat_Click(object sender, EventArgs e)
        {
            if (tsmiAddFormat.Checked)
            {
                tempPic.Controls["nudTemp"].Dispose();
                tempPic.Controls["cbxTemp"].Dispose();
                tsmiAddFormat.Checked = false;
            }
            else
            {
                #region NumericUpDown под PictureBox
                NumericUpDown nudCopies = new NumericUpDown
                {
                    Name = "nudTemp",
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = HorizontalAlignment.Center,
                    Font = new Font("Segoe UI", 9.75F),
                    ClientSize = new Size(averageSize, 0)
                };
                nudCopies.Location = new Point(-1, thumbSize - nudCopies.Height * 2 + 1);
                nudCopies.Parent = tempPic;

                nudCopies.KeyDown += nudCopies_KeyDown;
                #endregion

                #region ComboBox под PictureBox
                ComboBox cbxFormats = new ComboBox
                {
                    Name = "cbxTemp",
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font = new Font("Segoe UI", 9.75F),
                    ClientSize = new Size(averageSize - 4, 0),
                    DrawMode = DrawMode.OwnerDrawFixed
                };
                cbxFormats.Items.AddRange(formats);
                cbxFormats.SelectedIndex = 0;
                cbxFormats.Location = new Point(averageSize - 1, thumbSize - cbxFormats.Height * 2 + 2);
                cbxFormats.Parent = tempPic;

                cbxFormats.DrawItem += cbxFormtas_DrawItem;
                cbxFormats.DropDownClosed += cbxFormats_DropDownClosed;
                #endregion

                NumericUpDowns.Add(nudCopies);
                ComboBoxes.Add(cbxFormats);

                tsmiAddFormat.Checked = true;
            }
        }

        private void fmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.O))
                tsmiOpen_Click(null, null);
            else if (e.KeyData == (Keys.Control | Keys.D))
                tsmiClear_Click(null, null);
            else if (e.KeyData == (Keys.Control | Keys.S))
                tsmiСompleteSelection_Click(null, null);
        }

        private void tsmiSubfolders_Click(object sender, EventArgs e)
        {
            if (tsmiSubfolders.Checked)
            {
                subfolders = false;
                tsmiSubfolders.Checked = false;
            }
            else
            {
                subfolders = true;
                tsmiSubfolders.Checked = true;
            }
        }

        private void Notification(string message, Color color)
        {
            tslAction.ForeColor = color;
            tslAction.Text = message;
            timer1.Start();
        }
    }
}
