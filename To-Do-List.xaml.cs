using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace zadanie5
{
    /// <summary>
    /// Логика взаимодействия для To_Do_List.xaml
    /// </summary>
    public partial class To_Do_List : Window
    {
        ToDolist allTasks = new ToDolist();
        public To_Do_List()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string title = textBoxTitle.Text;
                string desc = textBoxDesc.Text;
                if(title != string.Empty)
                {
                    //создаем экзепляр класса задачи
                    Task newTask = new Task(title, desc, false);
                    //добавляем новую задачув список всех задач
                    allTasks.add_task(newTask);
                    //добавляем новую задачу в листбокс
                    DisplayListBox.Items.Add(newTask.ToString());
                }
                else
                {
                    MessageBox.Show("Укажите название!");
                }
            }
            catch { MessageBox.Show("Что-то пошло не так! Проверьте поля на заполнение"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //создаем переменную которая равна выбранному элемнту листбокса, приведенному к типу Таск
                int selectedTask = DisplayListBox.SelectedIndex;
                Task task = allTasks.Tasks[selectedTask];
                //убираем задачу из списка
                allTasks.remove_task(task);
                //убираем задачу из листбокса
                DisplayListBox.Items.RemoveAt(selectedTask);
            }
            catch { MessageBox.Show("Что-то пошло не так!"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {

                string selectedItem = DisplayListBox.SelectedItem.ToString();
                int selectedTask = DisplayListBox.SelectedIndex;
                allTasks.Tasks[selectedTask].mark_as_completed();

                if (selectedItem.Contains("невыполнено"))
                {
                    DisplayListBox.Items[selectedTask] = selectedItem.Replace("невыполнено", "выполнено");
                }

                DisplayListBox.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DisplayListBox.Items.Clear();
            List<Task> completedTasks = new List<Task>();
            completedTasks = allTasks.get_completed_tasks();
            for(int i = 0; i < completedTasks.Count; i++)
            {
                DisplayListBox.Items.Add(completedTasks[i].ToString());
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DisplayListBox.Items.Clear();
            List<Task> incompletedTasks = new List<Task>();
            incompletedTasks = allTasks.get_incompleted_tasks();
            for (int i = 0; i < incompletedTasks.Count; i++)
            {
                DisplayListBox.Items.Add(incompletedTasks[i].ToString());
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            DisplayListBox.Items.Clear();
            for (int i = 0; i < allTasks.Tasks.Count; i++)
            {
                DisplayListBox.Items.Add(allTasks.Tasks[i].ToString());
            }
        }
    }
}
