using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Windows.Forms;

namespace WinForms_EntityFramework
{
    public partial class Form1 : Form
    {
        DbRepository db;

        #region Конструктор
        public Form1()
        {
            InitializeComponent();

            db = new DbRepository();
            db.Players.Load();

            dataGridView1.DataSource = db.Players.Local.ToBindingList();
        }
        #endregion

        #region Добавление
        private void registration_button_Click(object sender, EventArgs e)
        {
            // Запускаем форму для добавления
            RegistrationForm plForm = new RegistrationForm();

            // Читаем результат диалога с пользователем - нажата ОК/нажата Cancel
            DialogResult result = plForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Player player = new Player();
            player.Name = plForm.textBox1.Text;
            player.Nickname = plForm.textBox2.Text;
            player.Birthday = plForm.dateTimePicker1.Value;
            player.Country = plForm.textBox4.Text;

            db.Players.Add(player);
            db.SaveChanges();

            MessageBox.Show("Новый объект добавлен");
        }
        #endregion

        #region Редактирование
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Достаем индекс выбранной строки
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                // Достаем из базы игрока с индексом
                Player player = db.Players.Find(id);

                // Запускаем форму для редактирования
                RegistrationForm plForm = new RegistrationForm();

                player.Name = plForm.textBox1.Text;
                player.Nickname = plForm.textBox2.Text;
                player.Birthday = plForm.dateTimePicker1.Value;
                player.Country = plForm.textBox4.Text;

                // Читаем результат диалога с пользователем - нажата ОК/нажата Cancel
                DialogResult result = plForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                player.Name = plForm.textBox1.Text;
                player.Nickname = plForm.textBox2.Text;
                player.Birthday = plForm.dateTimePicker1.Value;
                player.Country = plForm.textBox4.Text;

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");

            }
        }
        #endregion

        #region Удаление
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Достаем индекс выбранной строки
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                // Достаем из базы игрока с индексом
                Player player = db.Players.Find(id);
                db.Players.Remove(player);
                db.SaveChanges();

                MessageBox.Show("Объект удален");
            }
        }
        #endregion
    }
}