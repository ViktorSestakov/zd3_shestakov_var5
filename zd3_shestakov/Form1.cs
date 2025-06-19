using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLib;

namespace zd3_shestakov
{
    public partial class Form1 : Form
    {
        private List<Operator> operators = new List<Operator>();
        private Dictionary<string, Operator> operatorDict = new Dictionary<string, Operator>();

        public Form1()
        {
            InitializeComponent();
            HideAllControls();
        }

        private void HideAllControls()
        {
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();

            textBox1.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();
            numericUpDown3.Hide();
            numericUpDown4.Hide();
            numericUpDown5.Hide();

            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var op in operators)
            {
                listBox1.Items.Add(op.GetInfo());
            }
        }

        private void button1_Click(object sender, EventArgs e) // добавление оператора
        {
            button3.Show();
            button4.Show();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e) // удаление оператора
        {
            button5.Show();
            button6.Show();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e) // добавление обычного оператора
        {
            HideAllControls();

            textBox1.Show();
            numericUpDown1.Show();
            numericUpDown2.Show();
            numericUpDown3.Show();
            numericUpDown4.Show(); // для международных звонков (bool как 0/1)

            label1.Show();
            label2.Show();
            label6.Show();
            label3.Show();
            label5.Show();

            button8.Show();

        }

        private void button4_Click(object sender, EventArgs e) // добавление премиум оператора
        {
            HideAllControls();

            textBox1.Show();
            numericUpDown1.Show();
            numericUpDown2.Show();
            numericUpDown3.Show();
            numericUpDown4.Show(); // для международных звонков (bool как 0/1)
            numericUpDown5.Show(); // для ежемесячной платы

            label1.Show();
            label2.Show();
            label6.Show();
            label3.Show();
            label5.Show();
            label4.Text = "Ежемесячная плата";
            label4.Show();

            button7.Show();
        }

        private void button7_Click(object sender, EventArgs e) // добавление обычного оператора
        {
            try
            {
                string name = textBox1.Text;
                decimal cost = numericUpDown1.Value;
                double coverage = (double) numericUpDown2.Value;
                int subscribers = (int) numericUpDown3.Value;
                bool hasInternational = numericUpDown4.Value == 1;

                Operator newOperator = new Operator(name, cost, coverage, subscribers, hasInternational);
                operators.Add(newOperator);
                operatorDict[name] = newOperator;

                UpdateListBox();
                HideAllControls();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button8_Click(object sender, EventArgs e) // добавление премиум оператора
        {
            try
            {
                string name = textBox1.Text;
                decimal cost = numericUpDown1.Value;
                double coverage = (double) numericUpDown2.Value;
                int subscribers = (int) numericUpDown3.Value;
                bool hasInternational = numericUpDown4.Value == 1;
                bool hasFee = numericUpDown5.Value == 1;
                decimal monthlyFee = numericUpDown5.Value;

                PremiumOperator newOperator = new PremiumOperator(
                    name, cost, coverage, subscribers, hasInternational, hasFee, monthlyFee);

                operators.Add(newOperator);
                operatorDict[name] = newOperator;

                UpdateListBox();
                HideAllControls();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e) // удаление по имени
        {
            HideAllControls();
            textBox1.Show();
            label1.Show();
            button9.Show();
        }

        private void button6_Click(object sender, EventArgs e) // удаление по индексу
        {
            HideAllControls();
            numericUpDown1.Show();
            label7.Show();
            button10.Show();
        }

        private void button9_Click(object sender, EventArgs e) // удаление по имени
        {
            try
            {
                string name = textBox1.Text;
                if (operatorDict.ContainsKey(name))
                {
                    Operator opToRemove = operatorDict[name];
                    operators.Remove(opToRemove);
                    operatorDict.Remove(name);
                    UpdateListBox();
                }
                else
                {
                    MessageBox.Show("Оператор с таким именем не найден.");
                }

                HideAllControls();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button10_Click(object sender, EventArgs e) // удаление по индексу
        {
            try
            {
                int index = (int) numericUpDown1.Value;
                if (index >= 0 && index < operators.Count)
                {
                    Operator opToRemove = operators[index];
                    operatorDict.Remove(opToRemove.OperatorName);
                    operators.RemoveAt(index);
                    UpdateListBox();
                }
                else
                {
                    MessageBox.Show("Неверный индекс.");
                }

                HideAllControls();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}