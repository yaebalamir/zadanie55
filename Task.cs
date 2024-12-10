using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie5
{
    internal class Task
    {
        private string title;
        private string description;
        private bool is_completed = false;

        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public bool Is_Completed { get { return is_completed; } set { is_completed = value; } }

        public Task(string title, string desc, bool is_completed) 
        {
            Title = title; Description = desc; Is_Completed = is_completed;
        }
        public string mark_as_completed()
        {
            Is_Completed = true;
            return boolToStr();
        }
        //пока непонятно надо ли
        public string boolToStr()
        {
            if (Is_Completed) return "выполнено"; else return "невыполнено";
        }
        public override string ToString()
        {
            return $"Название задачи: {Title}, описание: {Description}, статус: {boolToStr()}";
        }
    }
}
