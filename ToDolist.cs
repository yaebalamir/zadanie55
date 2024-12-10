using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie5
{
    internal class ToDolist
    {
        private List<Task> tasks = new List<Task>();
        public List<Task> Tasks { get {  return tasks; } set { tasks = value; } }
        //метож добавления задачи
        public void add_task(Task task)
        {
            tasks.Add(task);
        }
        //метод удаления задачи
        public void remove_task (Task task)
        {
            tasks.Remove(task);
        }
        public string get_all_tasks()
        {
            string allTasks = "";
            foreach (Task task in tasks)
            {
                allTasks += task.ToString() + " ";
            }
            return allTasks;
        }
        public List<Task> get_completed_tasks()
        {
            List<Task> completedTasks = new List<Task>();
            foreach (Task task in tasks)
            {
                if (task.Is_Completed)
                {
                    completedTasks.Add(task);
                }
            }
            return completedTasks;
        }
        public List<Task> get_incompleted_tasks()
        {
            List<Task> incompletedTasks = new List<Task>();
            foreach (Task task in tasks)
            {
                if (!task.Is_Completed)
                {
                    incompletedTasks.Add(task);
                }
            }
            return incompletedTasks;
        }
    }
}
