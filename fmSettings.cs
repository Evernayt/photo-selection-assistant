using Photo_Selection_Assistant.Properties;
using System;
using System.Windows.Forms;

namespace Photo_Selection_Assistant
{
    public partial class fmSettings : Form
    {
        string[] formats;

        public fmSettings()
        {
            InitializeComponent();
        }

        private void fmSettings_Load(object sender, EventArgs e)
        {
            chbxSubfolders.Checked = Settings.Default.subfolders;
            cbxSize.SelectedItem = Settings.Default.size;
            tbxFolderName.Text = Settings.Default.folderName;
            formats = Settings.Default.allFormtas.Split(',');

            for (int i = 0; i < formats.Length; i++)
                dataGridView1.Rows.Add(formats[i]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string temp = "";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                    temp += row.Cells[0].Value + ",";

                Settings.Default.allFormtas = temp.Trim(',');
                Settings.Default.Save();
            }

            MessageBox.Show("Сохранено", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите сбросить настройки?", Text,
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Settings.Default.Reset();
                MessageBox.Show("Настройки успешно сброшены.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                fmSettings_Load(null, null);
            }
        }

        private void cbxSize_DropDownClosed(object sender, EventArgs e)
        {
            Settings.Default.size = cbxSize.Text;
            Settings.Default.Save();
            groupBox2.Focus();
        }

        private void chbxSubfolders_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.subfolders = chbxSubfolders.Checked ? true : false;
            Settings.Default.Save();
        }

        private void tbxFolderName_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.folderName = tbxFolderName.Text;
            Settings.Default.Save();
        }
    }
}
