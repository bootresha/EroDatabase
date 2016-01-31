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
using System.Data.SQLite;

/* List to-do
 * 
 * Implement insert database from folder selection
 * Implement function to insert data to database
 * Implement function to retreive/query data from database (kinda done)
 * Implement function to populate Main Form
 * Perhaps make a class for the database things
 * Mini-bug in ItemLayout thumbnail function
 * 
 * 
 * 
 */

namespace EroDatabase
{
    public partial class eroDatabase : Form
    {
        //List<ItemLayout> mainFormContent = new List<ItemLayout>();

        private EroDatabaseAdapter mainDatabase;
        private List<String> readerDBwhere1 = new List<string>();
        private List<String> readerDBwhere2 = new List<string>();

        public eroDatabase()
        {
            InitializeComponent();
            mainDatabase = new EroDatabaseAdapter();

            //// Example for querying stuff
            //readerDBwhere1.Add("Language");
            //readerDBwhere2.Add("'Jap'");
            //readDB(readerDBwhere1, readerDBwhere2, "mainTable", "Id");

            //populateLayoutView(null, null, new String[2] { "Circle", "Date" });
        }

        private void addTableViewElement(ItemLayout content)
        {
            layoutPanel.Controls.Add(content);
        }

        private void removeTableViewElement(int target)
        {
            layoutPanel.Controls.RemoveAt(target);
        }

        private void readFolder()
        {
            folderBrowserDialog1.Description = "Select Directory. (Subdir will not be checked)";
            folderBrowserDialog1.SelectedPath = Directory.GetCurrentDirectory();
            folderBrowserDialog1.ShowDialog();
            String Targetdirectory = folderBrowserDialog1.SelectedPath;
            String[] list = Directory.GetDirectories(Targetdirectory);
            String folderName;
            foreach (string element in list)
            {
                folderName = element.Remove(0, Targetdirectory.Length);
                if (folderName.StartsWith("!"))
                {
                    continue;
                }
                else if (folderName.StartsWith("\\"))
                {
                    folderName = folderName.Remove(0, 1);
                }

                // TODO: Return type is String[4], but then what to do?
                if (folderName.StartsWith("["))
                {
                    String[] dataRead = acquireDataFromFolderName(folderName);
                    mainDatabase.addToDatabase(dataRead[0], dataRead[1], dataRead[2], dataRead[3], dataRead[4], dataRead[5], dataRead[6], dataRead[7], dataRead[8]);
                }
            }
        }

        private String[] acquireDataFromFolderName(string folderName)
        {

            String[] dataRead = new String[9];
            int bracket1 = 0;

            for (int i = 0; i < folderName.Length; i++)
            {
                if (String.Equals(folderName.Substring(i, 1), "["))
                {
                    bracket1 = i;
                }
            }

            //Get Circle
            dataRead[2] = folderName.Substring(1, bracket1 - 3);
            //Get Date
            dataRead[3] = folderName.Substring(bracket1 + 1, 6);
            dataRead[3] = (String.Equals(dataRead[3].Substring(0, 1), "9") ? "19" : "20") + dataRead[3].Substring(0, 2) + //Year 19XX or 20XX
                "-" + dataRead[3].Substring(2, 2) + // Month
                "-" + dataRead[3].Substring(4, 2);  // Day
            //Get Title
            dataRead[4] = folderName.Substring(bracket1 + 9, folderName.Length - (bracket1 + 9));
            //Get EntryType
            String[] foldersInCurrentDir = Directory.GetDirectories(folderBrowserDialog1.SelectedPath + "\\" + folderName);
            String[] filesInCurrentDir;
            foreach (string element in foldersInCurrentDir)
            {
                if (element.Contains("Installer"))
                {
                    dataRead[7] = "Installer";
                    break;
                }
                else if (element.Contains("Game Files"))
                {
                    dataRead[7] = "Portable";
                }
                else if (element.Contains("Audio"))
                {
                    dataRead[7] = "Audio";
                }
                else if (element.Contains("Animation"))
                {
                    dataRead[7] = "Animation";
                }
            }
            filesInCurrentDir = Directory.GetFiles(folderBrowserDialog1.SelectedPath + "\\" + folderName);
            foreach (string element in filesInCurrentDir)
            {
                if (element.Contains("package.jpg"))
                {
                    dataRead[0] = "Getchu";
                    dataRead[1] = element.Substring(folderBrowserDialog1.SelectedPath.Length + folderName.Length + 3, element.IndexOf("package") - (folderBrowserDialog1.SelectedPath.Length + folderName.Length + 3));
                    dataRead[8] = element;
                }
                else if (element.Contains("img_main"))
                {
                    if (element.Contains("RJ"))
                    {
                        dataRead[0] = "DLSite Japanese";
                    }
                    else if (element.Contains("RE"))
                    {
                        dataRead[0] = "DLSite English";
                    }
                    else if (element.Contains("VJ"))
                    {
                        dataRead[0] = "DLSite Japanese Professional";
                    }
                    dataRead[1] = element.Substring(folderBrowserDialog1.SelectedPath.Length + folderName.Length + 4, 6);
                    dataRead[8] = element;
                }
            }
            return dataRead;
        }

        private void createGalleryForm(String[] imagesPath)
        {

            new GalleryForm(imagesPath, this).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readFolder();
            populateLayoutView(null, null, new String[2] { "Circle", "Date" });
        }

        private void populateLayoutView(List<String> where1, List<String> where2, String[] orderBy)
        {
            commandDB.CommandText = "SELECT * from mainTable";
            if (where1 != null && where1.Count > 0)
            {
                commandDB.CommandText += " WHERE";
                for (int i = 0; i < where1.Count; i++)
                {
                    commandDB.CommandText += " " + where1.ElementAt(i) + "=" + where2.ElementAt(i) + " AND";
                }
                commandDB.CommandText = commandDB.CommandText.Substring(0, commandDB.CommandText.Length - 3);
                where1.RemoveRange(0, where1.Count);
                where2.RemoveRange(0, where2.Count);
            }

            if (orderBy != null && orderBy.Length > 0)
            {
                commandDB.CommandText += " ORDER BY ";
                for (int i = 0; i < orderBy.Length; i++)
                {
                    commandDB.CommandText += orderBy[i] + ", ";
                }
                commandDB.CommandText = commandDB.CommandText.Substring(0, commandDB.CommandText.Length - 2);
            }
            readerDB = commandDB.ExecuteReader();

            String link = "";

            while (readerDB.Read())
            {
                //Console.WriteLine("ID           : " + DB_PrintToConsole(readerDB, 0) + " ");
                //Console.WriteLine("Source Site  : " + DB_PrintToConsole(readerDB, 1) + " ");
                //Console.WriteLine("Source ID    : " + DB_PrintToConsole(readerDB, 2) + " ");
                //Console.WriteLine("Circle Name  : " + DB_PrintToConsole(readerDB, 3) + " ");
                //Console.WriteLine("Date         : " + DB_PrintToConsole(readerDB, 4) + " ");
                //Console.WriteLine("Title        : " + DB_PrintToConsole(readerDB, 5) + " ");
                //Console.WriteLine("Title Altern : " + DB_PrintToConsole(readerDB, 6) + " ");
                //Console.WriteLine("Language     : " + DB_PrintToConsole(readerDB, 7) + " ");
                //Console.WriteLine("Data Type    : " + DB_PrintToConsole(readerDB, 8));
                //Console.WriteLine();
                int indexDBSite = -1;
                int indexDBID = -1;

                for (int i = 0; i < readerDB.FieldCount; i++)
                {
                    if (String.Equals(readerDB.GetName(i), "DBSite")) { indexDBSite = i; }
                    if (String.Equals(readerDB.GetName(i), "DBID")) { indexDBID = i; }
                    if (indexDBID > -1 && indexDBSite > -1)
                    {
                        break;
                    }
                }

                if (String.Equals(DB_PrintToConsole(readerDB, indexDBSite), "Getchu"))
                {
                    link = "http://www.getchu.com/soft.phtml?id=" + readerDB.GetInt32(indexDBID);
                }
                else if (String.Equals(DB_PrintToConsole(readerDB, indexDBSite), "DLSite Japanese"))
                {
                    link = "http://www.dlsite.com/maniax/work/=/product_id/RJ" + readerDB.GetInt32(indexDBID);
                }
                else if (String.Equals(DB_PrintToConsole(readerDB, indexDBSite), "DLSite English"))
                {
                    link = "http://www.dlsite.com/ecchi-eng/work/=/product_id/RE" + readerDB.GetInt32(indexDBID);
                }
                else if (String.Equals(DB_PrintToConsole(readerDB, indexDBSite), "DLSite Japanese Professional"))
                {
                    link = "http://www.dlsite.com/pro/work/=/product_id/VJ" + readerDB.GetInt32(indexDBID);
                }

                addTableViewElement(new ItemLayout(DB_PrintToConsole(readerDB, 9),
                    DB_PrintToConsole(readerDB, 5), DB_PrintToConsole(readerDB, 3),
                    DB_PrintToConsole(readerDB, 4), DB_PrintToConsole(readerDB, 7),
                    link, DB_PrintToConsole(readerDB, 8), this));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Testing Purpose
            //createGalleryForm(Directory.GetFiles("C:\\!DL_TOR\\!DL\\!\\[softhouse-seal GRANDEE] [140328] ももいろ性癖開放宣言！"));

            //Actual Code
            //createGalleryForm(??);
        }

        private void eroDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainDatabase.formClosing();
        }

        private void eroDatabase_SizeChanged(object sender, EventArgs e)
        {
            layoutPanel.Size = new Size(this.Size.Width - 40, this.Size.Height - 96);
        }
    }
}
