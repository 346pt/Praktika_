using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Название тренировки";
            dataGridView1.Columns[1].Name = "Время(в минутах)";
            dataGridView1.Columns[2].Name = "Сложность";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string[] row = new string[] { textBox1.Text, textBox2.Text, textBox3.Text };
            dataGridView1.Rows.Add(row);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;

            dataGridView1[0, selectedRow].Value = textBox1.Text;
            dataGridView1[1, selectedRow].Value = textBox2.Text;
            dataGridView1[2, selectedRow].Value = textBox3.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовый файл|*.txt";
            saveFileDialog1.Title = "Сохранить данные об активностях";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Создание или перезапись файла для сохранения данных
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            file.WriteLine(row.Cells[0].Value.ToString() + "," + row.Cells[1].Value.ToString() + "," + row.Cells[2].Value.ToString());
                        }
                    }
                }
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Текстовый файл|*.txt";
            openFileDialog1.Title = "Открыть данные об активностях";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        dataGridView1.Rows.Add(data);
                    }
                }
            }
        }

        private void chartButton_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            chart1.Series.Add("PhysicalActivity");

            chart1.Series["PhysicalActivity"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            // Добавление данных из DataGridView в серию диаграммы
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string activityName = row.Cells[0].Value.ToString();
                    int time = Convert.ToInt32(row.Cells[1].Value);
                    chart1.Series["PhysicalActivity"].Points.AddXY(activityName, time);
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
