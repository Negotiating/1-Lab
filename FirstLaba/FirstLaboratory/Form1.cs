using System.Text.RegularExpressions;

namespace FirstLaboratory
{
    public partial class Form1 : Form
    {
        // Переменная, в которой хранится выделенный текст.
        private String selectedText; 
        public Form1()
        {
            //Метод инициализации всех графических компонентов
            InitializeComponent();
        }

        // Обработчик, который вызывается во время выделения текста.
        private void richTextBoxSelectionChanged(object sender, EventArgs e)
        {
            // Выделенный текст сохраняется в переменную selectedText.
            selectedText = richTextBox1.SelectedText.ToString();
        }

        // Обработчик, срабатывающийся во время нажатия по кнопки 1.
        private void button1_Click(object sender, EventArgs e)
        {
            // Добавляет выделенный текст в графический компонент Label, 
            // чтобы его можно было увидет на форме
            label1.Text = selectedText;
        }

        // Обработчик CheckBox-а, который ответственен за видимость Edit1
        private void checkBox1ForEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //Меняет свойство видимости у Edit1 при нажатии на CheckBox
            edit1.Visible = checkBox1.Checked;
        }

        // Обработчик CheckBox-а, который ответственен за видимость Memo1
        private void checkBox2ForMemo1_CheckedChanged(object sender, EventArgs e)
        {
            //Меняет свойство видимости у Memo1 при нажатии на CheckBox
            memo.Visible = checkBox2.Checked;
        }

        // Обработчик CheckBox-а, который ответственен за видимость RichEdit1
        private void checkBox3ForRichTextBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Меняет свойство видимости у RichEdit1 при нажатии на CheckBox
            richTextBox1.Visible = checkBox3.Checked;
        }

        //Обработчик, отвечающий за выравнивание текста у компонента Memo1
        private void radioButton_Click(object sender, EventArgs e)
        {
            // Если нажат перывй radioButton...
            if (radioButton1.Checked)
            {
                //то вырявнять текст слева
                memo.SelectionAlignment = HorizontalAlignment.Left;
            }
            // Если нажат второй radioButton...
            else if (radioButton2.Checked)
            {
                //то вырявнять текст по центру
                memo.SelectionAlignment= HorizontalAlignment.Center;
            }
            // Если нажат третий radioButton...
            else if (radioButton3.Checked)
            {
                //то вырявнять текст справа
                memo.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        //Обработчик кнопки, который загружает содержимое файла в компонент Memo
        private void button2_Click(object sender, EventArgs e)
        {
            // Запускает форму, для поиска нужного файла, и если файл выбран,
            // то запускаем логику вытаскивания данных
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // вытаскиваем все содержимое файла
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                // очищаем компонент от текста
                memo.Text = string.Empty;
                // итерируемся по массиву с содержимым файла
                foreach (string line in lines)
                {
                    // Добавляем построчно содержимое файла в компонент
                    memo.AppendText(line + '\n');
                }
            }
        }

        //Обработчик кнопки, который сохраняет текст из Memo в файл 
        private void button3_Click(object sender, EventArgs e)
        {
            //Сохранение текста в файл
            File.WriteAllText(openFileDialog1.FileName, memo.Text);
        }

        // Обработчик кнопки, который очищает компоненты TEdit, TLabel, TMemo, TRichEdit
        private void button4_Click(object sender, EventArgs e)
        {
            edit1.Text = string.Empty;
            memo.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            label1.Text = string.Empty;
        }

        // Обработчик кнопки, который разрешает редактирование всех компонентов
        // Поле ReadOnly отвечает за редактируемость компонентов. Если true, то редактировать нельзя,
        // а если false, то редактировать можно
        private void button5_Click(object sender, EventArgs e)
        {
            edit1.ReadOnly = false;
            memo.ReadOnly = false;
            richTextBox1.ReadOnly = false;
        }

        // Обработчик кнопки, который запрещает редактирование всех компонентов
        private void button6_Click(object sender, EventArgs e)
        {
            edit1.ReadOnly = true;
            memo.ReadOnly = true;
            richTextBox1.ReadOnly = true;
        }

        // Обработчик кнопки, который декомпозирует текст из TMemo в TRichEdit.
        // Каждое предложение располагается с новой строки со знака *
        private void button8_Click(object sender, EventArgs e)
        {
            // Отчищаем компонент RichEdit
            richTextBox1.Text = string.Empty;
            // Вытаскиваем текст из компонента TMemo
            String text = memo.Text;
            // Декомпозируем текст, используя регулярное выражение.
            // Комплилируем регулярное выражение
            Regex regex = new Regex(".*?[.?!]\\s");
            // Передаем текст из компонента TMemo в скомпилированный паттерн, чтобы получить результаты
            // применение регулярного выражения к тексту
            MatchCollection matches = regex.Matches(text);
            // Если совпадения в тексте по паттерну были найдены, то...
            if (matches.Count > 0)
            {
                // Итерируемся по найденным совпадениям...
                foreach (Match match in matches)
                {
                    // и добавляем их в панель TRichEdit
                    richTextBox1.AppendText("*" + match.Value + '\n');
                }

            }

        }
    }
}