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

namespace vki
{
    public partial class Form2 : Form
    {
        double x;
        public Form2()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e) {}

        private void button1_Click(object sender, EventArgs e)
        {
            x = (Convert.ToDouble(textBox1.Text) / (Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox2.Text)));
            x = Math.Round(x, 2);
            if (x < 18.5) { 
                richTextBox1.Text = x.ToString() + "\n" + "Zayıf";
                richTextBox1.ForeColor = Color.Yellow;
            }
            if (18.5 <= x && x <= 19.9) { 
                richTextBox1.Text = x.ToString() + "\n" + "Kabul Edilebilir";
                richTextBox1.ForeColor = Color.Orange;
            }
            if (20 <= x && x <= 24.9) { 
                richTextBox1.Text = x.ToString() + "\n" + "Normal";
                richTextBox1.ForeColor = Color.Green;
            }
            if (25 <= x && x < 29.9) { 
                richTextBox1.Text = x.ToString() + "\n" + "Hafif Şişman";
                richTextBox1.ForeColor = Color.HotPink;
            }
            if (30 <= x && x < 34.9) { 
                richTextBox1.Text = x.ToString() + "\n" + "1° Şişman";
                richTextBox1.ForeColor = Color.Red;
            }
            if (35 <= x && x < 39.9) { 
                richTextBox1.Text = x.ToString() + "\n" + "2° Şişman";
                richTextBox1.ForeColor = Color.Red;
            }
            if (40 <= x && x < 44.9) { 
                richTextBox1.Text = x.ToString() + "\n" + "3° Şişman";
                richTextBox1.ForeColor = Color.Red;
            }
            if (45 <= x) { 
                richTextBox1.Text = x.ToString() + "\n" + "Morbid Obez";
                richTextBox1.ForeColor = Color.DarkRed;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] bilgiler = { textBox3.Text, textBox4.Text, x.ToString() };
            listView1.Items.Add(new ListViewItem(bilgiler));

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            richTextBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem bilgi in listView1.CheckedItems)
            {
                bilgi.Remove();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Metin Dosyası|*.rtf";    
            save.OverwritePrompt = true; 
            save.CreatePrompt = true;  

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter yaz = new StreamWriter(save.FileName);

                for (int i = 0; i < listView1.CheckedItems.Count; i++)
                {

                    for (int j = 0; j < (listView1.Columns.Count - 1); j++)
                    {
                        yaz.Write(listView1.Items[i].SubItems[j].Text + " ");

                    }
                    yaz.Write(":" + listView1.Items[i].SubItems[2].Text + " VKİ");
                    yaz.WriteLine();

                }
                yaz.Close();
            }
            DialogResult mesaj = new DialogResult();
            mesaj = MessageBox.Show("Kaydedildi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Metin Dosyası|*.rtf";    
            save.OverwritePrompt = true;  
            save.CreatePrompt = true;  

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter yaz = new StreamWriter(save.FileName);

                for (int i = 0; i < listView1.Items.Count; i++)
                {

                    for (int j = 0; j < (listView1.Columns.Count - 1); j++)
                    {
                        yaz.Write(listView1.Items[i].SubItems[j].Text + " ");

                    }
                    yaz.Write(":" + listView1.Items[i].SubItems[2].Text + " VKİ");
                    yaz.WriteLine();

                }
                yaz.Close();
            }
            DialogResult mesaj = new DialogResult();
            mesaj = MessageBox.Show("Kaydedildi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form2_Load(object sender, EventArgs e) {}
        private void toolTip1_Popup(object sender, PopupEventArgs e) {}
    }
}
