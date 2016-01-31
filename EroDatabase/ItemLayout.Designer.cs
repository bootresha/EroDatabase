using System.Drawing;
namespace EroDatabase
{
    partial class ItemLayout
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code
        private void InitializeComponent(string imageDir, string name, string circle, string date, string lang, string link, string type)
        {
            this.entryTitleImage = new System.Windows.Forms.PictureBox();
            this.entryName = new System.Windows.Forms.Label();
            this.entryCircle = new System.Windows.Forms.Label();
            this.entryDate = new System.Windows.Forms.Label();
            this.buttonGenre = new System.Windows.Forms.Button();
            this.buttonPics = new System.Windows.Forms.Button();
            this.entryLang = new System.Windows.Forms.Label();
            this.entryLink = new System.Windows.Forms.Label();
            this.entryType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.entryTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // entryTitleImage
            // 
            this.entryTitleImage.Location = new System.Drawing.Point(3, 3);
            this.entryTitleImage.Name = "entryTitleImage";
            this.entryTitleImage.Size = new System.Drawing.Size(160, 160);
            this.entryTitleImage.TabIndex = 0;
            this.entryTitleImage.TabStop = false;
            //FIX THIS SOMETIME (What to do if image doesn't exist)
            try
            {
                this.entryTitleImage.Image = ThumbnailMaker.makeThumb(Image.FromFile(imageDir), this.entryTitleImage.Size.Width, this.entryTitleImage.Size.Height, false);
            }
            catch
            {
            };

            // 
            // entryName
            // 
            this.entryName.AutoSize = true;
            this.entryName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryName.Location = new System.Drawing.Point(169, 3);
            this.entryName.Name = "entryName";
            this.entryName.Size = new System.Drawing.Size(47, 19);
            this.entryName.TabIndex = 1;
            this.entryName.Text = "Name: " + name;
            // 
            // entryCircle
            // 
            this.entryCircle.AutoSize = true;
            this.entryCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.entryCircle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryCircle.Location = new System.Drawing.Point(169, 41);
            this.entryCircle.Name = "entryCircle";
            this.entryCircle.Size = new System.Drawing.Size(46, 19);
            this.entryCircle.TabIndex = 2;
            this.entryCircle.Text = "Circle: " + circle;
            this.entryCircle.Click += new System.EventHandler(this.entryCircle_MouseClick);
            this.entryCircle.MouseLeave += new System.EventHandler(this.entryCircle_MouseLeave);
            this.entryCircle.MouseHover += new System.EventHandler(this.entryCircle_MouseHover);
            // 
            // entryDate
            // 
            this.entryDate.AutoSize = true;
            this.entryDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryDate.Location = new System.Drawing.Point(169, 22);
            this.entryDate.Name = "entryDate";
            this.entryDate.Size = new System.Drawing.Size(40, 19);
            this.entryDate.TabIndex = 3;
            this.entryDate.Text = "Date: " + date;
            // 
            // buttonGenre
            // 
            this.buttonGenre.Location = new System.Drawing.Point(172, 140);
            this.buttonGenre.Name = "buttonGenre";
            this.buttonGenre.Size = new System.Drawing.Size(130, 23);
            this.buttonGenre.TabIndex = 4;
            this.buttonGenre.Text = "Genre: " + "Genre";
            this.buttonGenre.UseVisualStyleBackColor = true; ;
            this.buttonGenre.Click += new System.EventHandler(this.buttonGenre_Click);
            // 
            // buttonPics
            // 
            this.buttonPics.Location = new System.Drawing.Point(308, 140);
            this.buttonPics.Name = "buttonPics";
            this.buttonPics.Size = new System.Drawing.Size(148, 23);
            this.buttonPics.TabIndex = 5;
            this.buttonPics.Text = "Entry Pictures";
            this.buttonPics.UseVisualStyleBackColor = true;
            this.buttonPics.Click += new System.EventHandler(this.buttonPics_Click);
            // 
            // entryLang
            // 
            this.entryLang.AutoSize = true;
            this.entryLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.entryLang.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLang.Location = new System.Drawing.Point(169, 79);
            this.entryLang.Name = "entryLang";
            this.entryLang.Size = new System.Drawing.Size(72, 19);
            this.entryLang.TabIndex = 7;
            this.entryLang.Text = "Language: " + lang;
            this.entryLang.Click += new System.EventHandler(this.entryLang_MouseClick);
            this.entryLang.MouseLeave += new System.EventHandler(this.entryLang_MouseLeave);
            this.entryLang.MouseHover += new System.EventHandler(this.entryLang_MouseHover);
            // 
            // entryLink
            // 
            this.entryLink.AutoSize = true;
            this.entryLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.entryLink.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLink.Location = new System.Drawing.Point(169, 60);
            this.entryLink.Name = "entryLink";
            this.entryLink.Size = new System.Drawing.Size(101, 19);
            this.entryLink.TabIndex = 6;
            this.entryLink.Text = "Link: " + link;
            this.entryLink.Click += new System.EventHandler(this.entryLink_MouseClick);
            this.entryLink.MouseLeave += new System.EventHandler(this.entryLink_MouseLeave);
            this.entryLink.MouseHover += new System.EventHandler(this.entryLink_MouseHover);
            // 
            // entryType
            // 
            this.entryType.AutoSize = true;
            this.entryType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.entryType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryType.Location = new System.Drawing.Point(169, 98);
            this.entryType.Name = "entryType";
            this.entryType.Size = new System.Drawing.Size(39, 19);
            this.entryType.TabIndex = 8;
            this.entryType.Text = "Type: " + type;
            this.entryType.Click += new System.EventHandler(this.entryType_MouseClick);
            this.entryType.MouseLeave += new System.EventHandler(this.entryType_MouseLeave);
            this.entryType.MouseHover += new System.EventHandler(this.entryType_MouseHover);
            // 
            // ItemLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.entryType);
            this.Controls.Add(this.entryLang);
            this.Controls.Add(this.entryLink);
            this.Controls.Add(this.buttonPics);
            this.Controls.Add(this.buttonGenre);
            this.Controls.Add(this.entryDate);
            this.Controls.Add(this.entryCircle);
            this.Controls.Add(this.entryName);
            this.Controls.Add(this.entryTitleImage);
            this.Name = "ItemLayout";
            this.Size = new System.Drawing.Size(591, 166);
            ((System.ComponentModel.ISupportInitialize)(this.entryTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox entryTitleImage;
        private System.Windows.Forms.Label entryName;
        private System.Windows.Forms.Label entryCircle;
        private System.Windows.Forms.Label entryDate;
        private System.Windows.Forms.Button buttonGenre;
        private System.Windows.Forms.Button buttonPics;
        private System.Windows.Forms.Label entryLang;
        private System.Windows.Forms.Label entryLink;
        private System.Windows.Forms.Label entryType;

        //Depreceated
        private void InitializeComponent()
        {
            this.entryTitleImage = new System.Windows.Forms.PictureBox();
            this.entryName = new System.Windows.Forms.Label();
            this.entryCircle = new System.Windows.Forms.Label();
            this.entryDate = new System.Windows.Forms.Label();
            this.buttonGenre = new System.Windows.Forms.Button();
            this.buttonPics = new System.Windows.Forms.Button();
            this.entryLang = new System.Windows.Forms.Label();
            this.entryLink = new System.Windows.Forms.Label();
            this.entryType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.entryTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // entryTitleImage
            // 
            this.entryTitleImage.Location = new System.Drawing.Point(3, 3);
            this.entryTitleImage.Name = "entryTitleImage";
            this.entryTitleImage.Size = new System.Drawing.Size(160, 160);
            this.entryTitleImage.TabIndex = 0;
            this.entryTitleImage.TabStop = false;
            // 
            // entryName
            // 
            this.entryName.AutoSize = true;
            this.entryName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryName.Location = new System.Drawing.Point(169, 3);
            this.entryName.Name = "entryName";
            this.entryName.Size = new System.Drawing.Size(55, 19);
            this.entryName.TabIndex = 1;
            this.entryName.Text = "Name: ";
            // 
            // entryCircle
            // 
            this.entryCircle.AutoSize = true;
            this.entryCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.entryCircle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryCircle.Location = new System.Drawing.Point(169, 41);
            this.entryCircle.Name = "entryCircle";
            this.entryCircle.Size = new System.Drawing.Size(54, 19);
            this.entryCircle.TabIndex = 2;
            this.entryCircle.Text = "Circle: ";
            this.entryCircle.Click += new System.EventHandler(this.entryCircle_MouseClick);
            this.entryCircle.MouseLeave += new System.EventHandler(this.entryCircle_MouseLeave);
            this.entryCircle.MouseHover += new System.EventHandler(this.entryCircle_MouseHover);
            // 
            // entryDate
            // 
            this.entryDate.AutoSize = true;
            this.entryDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryDate.Location = new System.Drawing.Point(169, 22);
            this.entryDate.Name = "entryDate";
            this.entryDate.Size = new System.Drawing.Size(48, 19);
            this.entryDate.TabIndex = 3;
            this.entryDate.Text = "Date: ";
            // 
            // buttonGenre
            // 
            this.buttonGenre.Location = new System.Drawing.Point(172, 140);
            this.buttonGenre.Name = "buttonGenre";
            this.buttonGenre.Size = new System.Drawing.Size(130, 23);
            this.buttonGenre.TabIndex = 4;
            this.buttonGenre.Text = "Genre: ";
            this.buttonGenre.UseVisualStyleBackColor = true;
            this.buttonGenre.Click += new System.EventHandler(this.buttonGenre_Click);
            // 
            // buttonPics
            // 
            this.buttonPics.Location = new System.Drawing.Point(440, 140);
            this.buttonPics.Name = "buttonPics";
            this.buttonPics.Size = new System.Drawing.Size(148, 23);
            this.buttonPics.TabIndex = 5;
            this.buttonPics.Text = "Entry Pictures";
            this.buttonPics.UseVisualStyleBackColor = true;
            this.buttonPics.Click += new System.EventHandler(this.buttonPics_Click);
            // 
            // entryLang
            // 
            this.entryLang.AutoSize = true;
            this.entryLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.entryLang.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLang.Location = new System.Drawing.Point(169, 79);
            this.entryLang.Name = "entryLang";
            this.entryLang.Size = new System.Drawing.Size(80, 19);
            this.entryLang.TabIndex = 7;
            this.entryLang.Text = "Language: ";
            this.entryLang.Click += new System.EventHandler(this.entryLang_MouseClick);
            this.entryLang.MouseLeave += new System.EventHandler(this.entryLang_MouseLeave);
            this.entryLang.MouseHover += new System.EventHandler(this.entryLang_MouseHover);
            // 
            // entryLink
            // 
            this.entryLink.AutoSize = true;
            this.entryLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.entryLink.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLink.Location = new System.Drawing.Point(169, 60);
            this.entryLink.Name = "entryLink";
            this.entryLink.Size = new System.Drawing.Size(43, 19);
            this.entryLink.TabIndex = 6;
            this.entryLink.Text = "Link: ";
            this.entryLink.Click += new System.EventHandler(this.entryLink_MouseClick);
            this.entryLink.MouseLeave += new System.EventHandler(this.entryLink_MouseLeave);
            this.entryLink.MouseHover += new System.EventHandler(this.entryLink_MouseHover);
            // 
            // entryType
            // 
            this.entryType.AutoSize = true;
            this.entryType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.entryType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryType.Location = new System.Drawing.Point(169, 98);
            this.entryType.Name = "entryType";
            this.entryType.Size = new System.Drawing.Size(47, 19);
            this.entryType.TabIndex = 8;
            this.entryType.Text = "Type: ";
            this.entryType.Click += new System.EventHandler(this.entryType_MouseClick);
            this.entryType.MouseLeave += new System.EventHandler(this.entryType_MouseLeave);
            this.entryType.MouseHover += new System.EventHandler(this.entryType_MouseHover);
            // 
            // ItemLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.entryType);
            this.Controls.Add(this.entryLang);
            this.Controls.Add(this.entryLink);
            this.Controls.Add(this.buttonPics);
            this.Controls.Add(this.buttonGenre);
            this.Controls.Add(this.entryDate);
            this.Controls.Add(this.entryCircle);
            this.Controls.Add(this.entryName);
            this.Controls.Add(this.entryTitleImage);
            this.Name = "ItemLayout";
            this.Size = new System.Drawing.Size(591, 166);
            ((System.ComponentModel.ISupportInitialize)(this.entryTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
