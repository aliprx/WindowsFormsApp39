using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;

namespace WindowsFormsApp39
{
    public partial class Form1 : Form
    {
        void getDb()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyNote.csv");
            var db = new SQLiteConnection(databasePath);
            db.CreateTable<Id>();
            db.CreateTable<Note>();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SQLiteConnection db;
            db=new SQLiteConnection(databasePath:"MyNote.csv");
            var addById = new Id();
            var add=new Note()
            {
                title = txttitle.Text,
                text = txttext.Text,
                date = DateTime.Now
            };
            label1.Text = (add.title, add.text, add.date,addById.id).ToString();
            db.Insert(add);
            dataGridView1.Rows.Add(addById.id,add.title,add.text,add.date);
        }
    }
}
