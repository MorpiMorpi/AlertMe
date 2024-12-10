namespace WpfApp2.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    public class TaskViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public ObservableCollection<string> StatusOptions { get; } = new ObservableCollection<string> { "Passed", "Missing" };

        private Task _selectedTask;
        public Task SelectedTask
        {
            get => _selectedTask;
            set { _selectedTask = value; OnPropertyChanged(); }
        }

        private bool _isAddTaskVisible;
        public bool IsAddTaskVisible
        {
            get => _isAddTaskVisible;
            set { _isAddTaskVisible = value; OnPropertyChanged(); }
        }

        public string NewTaskTitle { get; set; }
        public string NewTaskStatus { get; set; }
        public DateTime NewTaskDateAssigned { get; set; } = DateTime.Now;
        public DateTime NewTaskDueDate { get; set; } = DateTime.Now.AddDays(7);

        public ICommand ShowAddTaskCommand { get; }
        public ICommand SaveTaskCommand { get; }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Task>
            {
                new Task { Title = "Review chapters on Forces, Momentum, and Energy conservation", Status = "Missing", DateAssigned = DateTime.Now, DueDate = DateTime.Now.AddDays(3), Notes = "Important review", BackgroundColor = "#FFD700" },
                new Task { Title = "Lab report on Velocity, Acceleration, and Motion", Status = "Passed", DateAssigned = DateTime.Now.AddDays(-5), DueDate = DateTime.Now, Notes = "Complete report", BackgroundColor = "#ADD8E6" },
            };

            ShowAddTaskCommand = new RelayCommand(_ => IsAddTaskVisible = true);
            SaveTaskCommand = new RelayCommand(_ => AddNewTask());
        }

        public void AddNewTask() 
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle) && !string.IsNullOrWhiteSpace(NewTaskStatus))
            {
                Tasks.Add(new Task
                {
                    Title = NewTaskTitle,
                    Status = NewTaskStatus,
                    DateAssigned = NewTaskDateAssigned,
                    DueDate = NewTaskDueDate,
                    BackgroundColor = "#90EE90"
                });

                NewTaskTitle = string.Empty;
                NewTaskStatus = string.Empty;
                IsAddTaskVisible = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}