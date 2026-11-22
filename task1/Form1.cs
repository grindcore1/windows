
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;
        private TextBox textBox2;

        private RadioButton radioAdd;
        private RadioButton radioSubtract;
        private RadioButton radioMultiply;
        private RadioButton radioDivide;

        private Button buttonCalculate;
        private Label labelResult;

        public Form1()
        {
            // Настройки окна
            Text = "Калькулятор";
            Size = new Size(400, 400);
            StartPosition = FormStartPosition.CenterScreen;

            // Первое число
            Label label1 = new Label();
            label1.Text = "Первое число:";
            label1.Location = new Point(30, 30);
            label1.Size = new Size(120, 25);
            Controls.Add(label1);

            textBox1 = new TextBox();
            textBox1.Location = new Point(160, 30);
            textBox1.Size = new Size(170, 25);
            Controls.Add(textBox1);

            // Второе число
            Label label2 = new Label();
            label2.Text = "Второе число:";
            label2.Location = new Point(30, 70);
            label2.Size = new Size(120, 25);
            Controls.Add(label2);

            textBox2 = new TextBox();
            textBox2.Location = new Point(160, 70);
            textBox2.Size = new Size(170, 25);
            Controls.Add(textBox2);

            // Контейнер операций
            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Выберите операцию";
            groupBox.Location = new Point(30, 115);
            groupBox.Size = new Size(300, 100);
            Controls.Add(groupBox);

            // Радиокнопка сложения
            radioAdd = new RadioButton();
            radioAdd.Text = "+";
            radioAdd.Location = new Point(20, 25);
            radioAdd.Size = new Size(50, 25);
            groupBox.Controls.Add(radioAdd);

            // Радиокнопка вычитания
            radioSubtract = new RadioButton();
            radioSubtract.Text = "-";
            radioSubtract.Location = new Point(90, 25);
            radioSubtract.Size = new Size(50, 25);
            groupBox.Controls.Add(radioSubtract);

            // Радиокнопка умножения
            radioMultiply = new RadioButton();
            radioMultiply.Text = "*";
            radioMultiply.Location = new Point(160, 25);
            radioMultiply.Size = new Size(50, 25);
            groupBox.Controls.Add(radioMultiply);

            // Радиокнопка деления
            radioDivide = new RadioButton();
            radioDivide.Text = "/";
            radioDivide.Location = new Point(230, 25);
            radioDivide.Size = new Size(50, 25);
            groupBox.Controls.Add(radioDivide);

            // Кнопка вычисления
            buttonCalculate = new Button();
            buttonCalculate.Text = "Вычислить";
            buttonCalculate.Location = new Point(120, 230);
            buttonCalculate.Size = new Size(130, 35);
            Controls.Add(buttonCalculate);

            // Метка результата
            labelResult = new Label();
            labelResult.Text = "Результат: ";
            labelResult.Location = new Point(30, 290);
            labelResult.Size = new Size(300, 30);
            labelResult.Font = new Font(
                "Arial", 12, FontStyle.Bold);
            Controls.Add(labelResult);

            // Ручная подписка на обработчик
            buttonCalculate.Click += ButtonCalculate_Click;
        }

        // Обработчик кнопки
        private void ButtonCalculate_Click(
            object sender, EventArgs e)
        {
            // Проверка первого числа
            if (!double.TryParse(
                textBox1.Text,
                NumberStyles.Float | NumberStyles.AllowThousands,
                CultureInfo.CurrentCulture,
                out double number1))
            {
                MessageBox.Show(
                    "Введите корректные числа",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Проверка второго числа
            if (!double.TryParse(
                textBox2.Text,
                NumberStyles.Float | NumberStyles.AllowThousands,
                CultureInfo.CurrentCulture,
                out double number2))
            {
                MessageBox.Show(
                    "Введите корректные числа",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            double result;

            // Определение операции
            if (radioAdd.Checked)
            {
                result = number1 + number2;
            }
            else if (radioSubtract.Checked)
            {
                result = number1 - number2;
            }
            else if (radioMultiply.Checked)
            {
                result = number1 * number2;
            }
            else if (radioDivide.Checked)
            {
                // Проверка деления на ноль
                if (number2 == 0)
                {
                    MessageBox.Show(
                        "Деление на ноль невозможно!",
                        "Предупреждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                result = number1 / number2;
            }
            else
            {
                MessageBox.Show(
                    "Выберите операцию!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Вывод результата с двумя знаками после запятой
            labelResult.Text = "Результат: " +
                result.ToString("F2", CultureInfo.CurrentCulture);
        }
    }
}
