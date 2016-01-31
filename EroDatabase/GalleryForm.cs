using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EroDatabase
{
    public partial class GalleryForm : Form
    {
        String[] imagesPath;
        Form prevForm;

        public GalleryForm(String[] imagesPath, Form prevForm)
        {
            InitializeComponent();
            this.imagesPath = imagesPath;
            this.prevForm = prevForm;
        }

        private void GalleryForm_Load(object sender, EventArgs e)
        {
            int temp = 0;
            for (int i = 0; i < imagesPath.Length; i++)
            {
                //Inserting thumbnails
                imageList1.Images.Add(ThumbnailMaker.makeThumb(Image.FromFile(imagesPath[i]), 256, 256, true));

                //Labelling thumbnails
                int titleFound;
                titleFound = imagesPath[i].IndexOf("package");
                if (titleFound == -1)
                {
                    titleFound = imagesPath[i].IndexOf("title");
                }

                if (titleFound != -1)
                {
                    listView1.Items.Add("Title", i);
                }
                else
                {
                    listView1.Items.Add("Screenshot " + temp, i);
                    temp++;
                }
            }
            listView1.View = View.LargeIcon;
        }

        private void GalleryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            prevForm.Show();
        }

        private void GalleryForm_SizeChanged(object sender, EventArgs e)
        {
            //listView1.TileSize = new Size(this.Size.Width, listView1.TileSize.Height);
        }
    }
}
