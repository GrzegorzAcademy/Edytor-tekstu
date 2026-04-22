using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Edytor_tekstu
{
    public partial class Form1 : Form


    {
        private bool isModified = false;

        private void editor_TextChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void SaveCurrentFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Pliki tekstowe|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
                File.WriteAllText(dlg.FileName, richTextBox1.Text);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void UtwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            if (isModified)
            {
                var result = MessageBox.Show(
                    "Czy chcesz zapisać zmiany?",
                    "Nowy dokument",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                    return;

                if (result == DialogResult.Yes)
                    SaveCurrentFile();
            }

            richTextBox1.Clear();
            isModified = false;
        }
    }
}
