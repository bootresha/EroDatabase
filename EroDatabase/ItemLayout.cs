using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EroDatabase
{
    public partial class ItemLayout : UserControl
    {
        private Form mainForm;
        private String imageDir;

        public ItemLayout(string imageTitleDir, string name, string circle, string date, string lang, string link, string type, Form mainForm)
        {
            InitializeComponent(imageTitleDir, name, circle, date, lang, link, type);
            if (String.IsNullOrEmpty(circle) || String.IsNullOrEmpty(date) || String.IsNullOrEmpty(type))
            {
                this.BackColor = Color.Aqua;
            }
            if (!File.Exists(imageTitleDir))
            {
                this.BackColor = Color.Red;
            }
            this.mainForm = mainForm;
            int slashIndex = 0;
            for (int i = 0; i < imageTitleDir.Length; i++)
            {
                if (String.Equals(imageTitleDir.Substring(i, 1), @"\"))
                {
                    slashIndex = i;
                }
            }
            this.imageDir = imageTitleDir.Substring(0, slashIndex);
        }

        private void entryCircle_MouseHover(object sender, EventArgs e)
        {
            entryCircle.Font = new Font(entryCircle.Font, entryCircle.Font.Style | System.Drawing.FontStyle.Underline);
        }

        private void entryCircle_MouseLeave(object sender, EventArgs e)
        {
            entryCircle.Font = new Font(entryCircle.Font, entryCircle.Font.Style & ~System.Drawing.FontStyle.Underline);
        }

        private void entryCircle_MouseClick(object sender, EventArgs e)
        {
            // Sort shit out
        }

        private void entryLink_MouseHover(object sender, EventArgs e)
        {
            entryLink.Font = new Font(entryLink.Font, entryLink.Font.Style | System.Drawing.FontStyle.Underline);
        }

        private void entryLink_MouseLeave(object sender, EventArgs e)
        {
            entryLink.Font = new Font(entryLink.Font, entryLink.Font.Style & ~System.Drawing.FontStyle.Underline);
        }

        private void entryLink_MouseClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(entryLink.Text.Substring(6, entryLink.Text.Length - 6));
            }
            catch { }
        }

        private void entryLang_MouseHover(object sender, EventArgs e)
        {
            entryLang.Font = new Font(entryLang.Font, entryLang.Font.Style | System.Drawing.FontStyle.Underline);
        }

        private void entryLang_MouseLeave(object sender, EventArgs e)
        {
            entryLang.Font = new Font(entryLang.Font, entryLang.Font.Style & ~System.Drawing.FontStyle.Underline);
        }

        private void entryLang_MouseClick(object sender, EventArgs e)
        {
            // Sort shit out
        }

        private void entryType_MouseHover(object sender, EventArgs e)
        {
            entryType.Font = new Font(entryType.Font, entryType.Font.Style | System.Drawing.FontStyle.Underline);
        }

        private void entryType_MouseLeave(object sender, EventArgs e)
        {
            entryType.Font = new Font(entryType.Font, entryType.Font.Style & ~System.Drawing.FontStyle.Underline);
        }

        private void entryType_MouseClick(object sender, EventArgs e)
        {
            // Sort shit out
        }

        private void buttonGenre_Click(object sender, EventArgs e)
        {
            // Filter
        }

        private void buttonPics_Click(object sender, EventArgs e)
        {
            //Testing
            //new GalleryForm(Directory.GetFiles("C:\\!DL_TOR\\!DL\\!\\[softhouse-seal GRANDEE] [140328] ももいろ性癖開放宣言！"), mainForm).Show();

            //Actual Code
            if (File.Exists(imageDir))
            {
                new GalleryForm(Directory.GetFiles(imageDir), mainForm).Show();
                mainForm.Hide();
            }
        }
    }
}
