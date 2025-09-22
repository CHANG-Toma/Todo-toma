using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Todo_toma.Models;

namespace Todo_toma.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string newTaskTitle;

        public ObservableCollection<TaskItem> Tasks { get; } = new();

        public string NewTaskTitle
        {
            get => newTaskTitle;
            set { if (newTaskTitle == value) return; newTaskTitle = value; OnPropertyChanged(nameof(NewTaskTitle)); }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public MainViewModel()
        {
            AddTaskCommand = new Command(AddTask);
            DeleteTaskCommand = new Command<TaskItem>(DeleteTask);
        }

        void AddTask()
        {
            if (string.IsNullOrWhiteSpace(NewTaskTitle)) return;
            Tasks.Add(new TaskItem { Title = NewTaskTitle });
            NewTaskTitle = string.Empty;
        }

        void DeleteTask(TaskItem task)
        {
            if (task is null) return;
            if (Tasks.Contains(task)) Tasks.Remove(task);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
