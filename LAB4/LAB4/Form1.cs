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
using System.Diagnostics;

namespace LAB4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> list = new List<string>(); // Список слов 

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog(); // для выбора текстового файла
            fd.Filter = "текстовые файлы|*.txt"; // только txt
            if (fd.ShowDialog() == DialogResult.OK) // пользователь выбрал файл
            {
                Stopwatch t = new Stopwatch(); // для измерения времени выполнения потоков
                t.Start();
                //Чтение файла в виде строки                 
                string text = File.ReadAllText(fd.FileName);
                //Разделительные символы для чтения из файла                 
                char[] separators = new char[] {' ','.',',','!','?','/','\t','\n', ')', '('};  
                string[] textArray = text.Split(separators); // разделяет
                foreach (string strTemp in textArray)
                {
                    //Удаление пробелов в начале и конце строки                    
                    string str = strTemp.Trim();
                    //Добавление строки в список, если строка не содержится в списке        
                    if (!list.Contains(str)) list.Add(str);
                }

                this.label1.Text = t.Elapsed.ToString(); // по истечении интервала времени
                t.Stop();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл");
            } 
                }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Слово для поиска             
            string word = this.textBox1.Text.Trim();
            //Если слово для поиска не пусто            
            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            {
                //Слово для поиска в верхнем регистре            
                string wordUpper = word.ToUpper();
                //Временные результаты поиска               
                List<string> tempList = new List<string>();  

            Stopwatch t = new Stopwatch();
                t.Start();
            foreach (string str in list)
                { if (str.ToUpper().Contains(wordUpper))
                    {
                        tempList.Add(str);
                    }
                }
            t.Stop();
                this.label3.Text = t.Elapsed.ToString();
                this.listBox1.BeginUpdate();
                //Очистка списка                
                this.listBox1.Items.Clear();
                //Вывод результатов поиска               
                foreach (string str in tempList)
                {
                    this.listBox1.Items.Add(str);
                }
                this.listBox1.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }


}
