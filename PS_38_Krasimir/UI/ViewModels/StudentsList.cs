using DataLayer.Database;
using DataLayer.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using UI.Command;

namespace UI.ViewModels
{
    public class StudentsList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<DatabaseUser> _students;
        public ObservableCollection<DatabaseUser> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        private DatabaseUser? _selectedStudent;
        public DatabaseUser? SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public ICommand ShowDetailsCommand { get; }

        public StudentsList()
        {
            _students = new ObservableCollection<DatabaseUser>();
            ShowDetailsCommand = new RelayCommand(ShowDetails, CanShowDetails);
            LoadStudents();
        }

        private void LoadStudents()
        {
            using var context = new DatabaseContext();
            var records = context.Users.ToList();
            Students = new ObservableCollection<DatabaseUser>(records);
        }

        private void ShowDetails(object? parameter)
        {
            if (SelectedStudent == null) return;

            string message = $"Id:       {SelectedStudent.Id}\n" +
                             $"Name:     {SelectedStudent.Name}\n" +
                             $"Role:     {SelectedStudent.Role}\n" +
                             $"Expires:  {SelectedStudent.Expires:yyyy-MM-dd}";

            MessageBox.Show(message, "Student Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanShowDetails(object? parameter) => SelectedStudent != null;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
