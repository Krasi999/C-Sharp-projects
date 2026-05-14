using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UI.Command;

namespace UI.ViewModels
{
    public class LogList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LoggerFile.txt");

        private ObservableCollection<DatabaseLog> _logs = new ObservableCollection<DatabaseLog>();
        public ObservableCollection<DatabaseLog> Logs
        {
            get => _logs;
            set { _logs = value; OnPropertyChanged(nameof(Logs)); }
        }

        private DatabaseLog? _selectedLog;
        public DatabaseLog? SelectedLog
        {
            get => _selectedLog;
            set { _selectedLog = value; OnPropertyChanged(nameof(SelectedLog)); }
        }

        public ICommand ShowDetailsCommand { get; }
        public ICommand SaveToFileCommand { get; }

        public LogList()
        {
            ShowDetailsCommand = new RelayCommand(ShowDetails, _ => SelectedLog != null);
            SaveToFileCommand = new RelayCommand(SaveLogToFile, _ => SelectedLog != null);
            LoadLogs();
        }

        private void LoadLogs()
        {
            using var context = new DatabaseContext();
            var records = context.Logs.OrderByDescending(x => x.Timestamp).ToList();
            Logs = new ObservableCollection<DatabaseLog>(records);
        }

        private void ShowDetails(object? parameter)
        {
            if (SelectedLog == null) return;
            var detailsWin = new UI.Windows.LogDetailsWindow();
            detailsWin.DataContext = this;
            detailsWin.ShowDialog();
        }

        private void SaveLogToFile(object? parameter)
        {
            if (SelectedLog == null) return;

            try
            {
                string logEntry = $"--- Log Entry ---{Environment.NewLine}" +
                                 $"ID: {SelectedLog.Id}{Environment.NewLine}" +
                                 $"Timestamp: {SelectedLog.Timestamp}{Environment.NewLine}" +
                                 $"Message: {SelectedLog.Message}{Environment.NewLine}" +
                                 $"-----------------{Environment.NewLine}{Environment.NewLine}";

                File.AppendAllText(_logFilePath, logEntry);

                MessageBox.Show($"The log is successfully added to the file!:{Environment.NewLine}{_logFilePath}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error! The log is not added to the file!: {ex.Message}");
            }
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}