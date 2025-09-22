using System.ComponentModel;

namespace Todo_toma.Models
{
    public class TaskItem : INotifyPropertyChanged
    {
        string title;
        bool isDone;

        public string Title
        {
            get => title;
            set { if (title == value) return; title = value; OnPropertyChanged(nameof(Title)); }
        }

        public bool IsDone
        {
            get => isDone;
            set
            {
                if (isDone == value) return;
                isDone = value;
                OnPropertyChanged(nameof(IsDone));
                OnPropertyChanged(nameof(TextDecoration));
            }
        }

        public TextDecorations TextDecoration =>
            IsDone ? TextDecorations.Strikethrough : TextDecorations.None;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
