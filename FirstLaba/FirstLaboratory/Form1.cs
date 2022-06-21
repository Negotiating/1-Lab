using System.Text.RegularExpressions;

namespace FirstLaboratory
{
    public partial class Form1 : Form
    {
        // ����������, � ������� �������� ���������� �����.
        private String selectedText; 
        public Form1()
        {
            //����� ������������� ���� ����������� �����������
            InitializeComponent();
        }

        // ����������, ������� ���������� �� ����� ��������� ������.
        private void richTextBoxSelectionChanged(object sender, EventArgs e)
        {
            // ���������� ����� ����������� � ���������� selectedText.
            selectedText = richTextBox1.SelectedText.ToString();
        }

        // ����������, ��������������� �� ����� ������� �� ������ 1.
        private void button1_Click(object sender, EventArgs e)
        {
            // ��������� ���������� ����� � ����������� ��������� Label, 
            // ����� ��� ����� ���� ������ �� �����
            label1.Text = selectedText;
        }

        // ���������� CheckBox-�, ������� ������������ �� ��������� Edit1
        private void checkBox1ForEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //������ �������� ��������� � Edit1 ��� ������� �� CheckBox
            edit1.Visible = checkBox1.Checked;
        }

        // ���������� CheckBox-�, ������� ������������ �� ��������� Memo1
        private void checkBox2ForMemo1_CheckedChanged(object sender, EventArgs e)
        {
            //������ �������� ��������� � Memo1 ��� ������� �� CheckBox
            memo.Visible = checkBox2.Checked;
        }

        // ���������� CheckBox-�, ������� ������������ �� ��������� RichEdit1
        private void checkBox3ForRichTextBox1_CheckedChanged(object sender, EventArgs e)
        {
            //������ �������� ��������� � RichEdit1 ��� ������� �� CheckBox
            richTextBox1.Visible = checkBox3.Checked;
        }

        //����������, ���������� �� ������������ ������ � ���������� Memo1
        private void radioButton_Click(object sender, EventArgs e)
        {
            // ���� ����� ������ radioButton...
            if (radioButton1.Checked)
            {
                //�� ��������� ����� �����
                memo.SelectionAlignment = HorizontalAlignment.Left;
            }
            // ���� ����� ������ radioButton...
            else if (radioButton2.Checked)
            {
                //�� ��������� ����� �� ������
                memo.SelectionAlignment= HorizontalAlignment.Center;
            }
            // ���� ����� ������ radioButton...
            else if (radioButton3.Checked)
            {
                //�� ��������� ����� ������
                memo.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        //���������� ������, ������� ��������� ���������� ����� � ��������� Memo
        private void button2_Click(object sender, EventArgs e)
        {
            // ��������� �����, ��� ������ ������� �����, � ���� ���� ������,
            // �� ��������� ������ ������������ ������
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // ����������� ��� ���������� �����
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                // ������� ��������� �� ������
                memo.Text = string.Empty;
                // ����������� �� ������� � ���������� �����
                foreach (string line in lines)
                {
                    // ��������� ��������� ���������� ����� � ���������
                    memo.AppendText(line + '\n');
                }
            }
        }

        //���������� ������, ������� ��������� ����� �� Memo � ���� 
        private void button3_Click(object sender, EventArgs e)
        {
            //���������� ������ � ����
            File.WriteAllText(openFileDialog1.FileName, memo.Text);
        }

        // ���������� ������, ������� ������� ���������� TEdit, TLabel, TMemo, TRichEdit
        private void button4_Click(object sender, EventArgs e)
        {
            edit1.Text = string.Empty;
            memo.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            label1.Text = string.Empty;
        }

        // ���������� ������, ������� ��������� �������������� ���� �����������
        // ���� ReadOnly �������� �� ��������������� �����������. ���� true, �� ������������� ������,
        // � ���� false, �� ������������� �����
        private void button5_Click(object sender, EventArgs e)
        {
            edit1.ReadOnly = false;
            memo.ReadOnly = false;
            richTextBox1.ReadOnly = false;
        }

        // ���������� ������, ������� ��������� �������������� ���� �����������
        private void button6_Click(object sender, EventArgs e)
        {
            edit1.ReadOnly = true;
            memo.ReadOnly = true;
            richTextBox1.ReadOnly = true;
        }

        // ���������� ������, ������� ������������� ����� �� TMemo � TRichEdit.
        // ������ ����������� ������������� � ����� ������ �� ����� *
        private void button8_Click(object sender, EventArgs e)
        {
            // �������� ��������� RichEdit
            richTextBox1.Text = string.Empty;
            // ����������� ����� �� ���������� TMemo
            String text = memo.Text;
            // ������������� �����, ��������� ���������� ���������.
            // ������������ ���������� ���������
            Regex regex = new Regex(".*?[.?!]\\s");
            // �������� ����� �� ���������� TMemo � ���������������� �������, ����� �������� ����������
            // ���������� ����������� ��������� � ������
            MatchCollection matches = regex.Matches(text);
            // ���� ���������� � ������ �� �������� ���� �������, ��...
            if (matches.Count > 0)
            {
                // ����������� �� ��������� �����������...
                foreach (Match match in matches)
                {
                    // � ��������� �� � ������ TRichEdit
                    richTextBox1.AppendText("*" + match.Value + '\n');
                }

            }

        }
    }
}