using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CadresApp
{
    public partial class Form1 : Form
    {
        //Создаем подключение к базе данных
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cadres.mdb";
        // Задаем имя подключению
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString); // создаем новый объект и выделяем память
            myConnection.Open(); // открываем соединение с БД
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cadresDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.cadresDataSet.Сотрудники);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close(); // Закрываем соединение с БД
        }


        private void button7_Click(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Fill(this.cadresDataSet.Сотрудники); // данная строчка позволяет обновлять данные
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Пишем код для добавления данных в БД

            int kod = Convert.ToInt32(textBox7.Text);
            string surname = textBox8.Text;
            string name = textBox9.Text;
            string position = textBox10.Text;
            string cabinet = textBox11.Text;
            string department = textBox12.Text;

            string query = "INSERT INTO Сотрудники ([Код сотрудника], Фамилия, Имя, Должность, Кабинет, Отдел) VALUES (" + kod + ", '" + surname + "', '" + name + "', '" + position + "', '" + cabinet + "', '" + department + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            //MessageBox.Show("Данные добавлены");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Пишем код для удаления данных

            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Сотрудники WHERE [Код сотрудника] =" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            //MessageBox.Show("Данные удалены");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Пишем код для изменения фамилии сотрудника
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Сотрудники SET Фамилия ='" + textBox3.Text + "'WHERE [Код сотрудника]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            //MessageBox.Show("Фамилия изменена");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Пишем код для изменения должности сотрудника
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Сотрудники SET Должность ='" + textBox4.Text + "'WHERE [Код сотрудника]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            //MessageBox.Show("Должность изменена");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Пишем код для изменения номера кабинета
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Сотрудники SET Кабинет ='" + textBox5.Text + "'WHERE [Код сотрудника]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            //MessageBox.Show("Кабинет изменен");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Пишем код для изменения отдела
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Сотрудники SET Отдел ='" + textBox6.Text + "'WHERE [Код сотрудника]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            //MessageBox.Show("Отдел изменен");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Пишем код для очистки полей
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Пишем код для перехода на форму поиска

            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Код для выхода из приложения
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //Справка
            MessageBox.Show("Автор программы Кадры: Иван Холодный., \nДата релиза: 18.03.2021 г.", "Внимание!!");
        }
    }
}
