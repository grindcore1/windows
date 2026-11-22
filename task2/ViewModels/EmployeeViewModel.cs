
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using EmployeeApp.Models;
using EmployeeApp.Commands;

namespace EmployeeApp.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees { get; set; }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged();

                if (selectedEmployee != null)
                {
                    NewName = selectedEmployee.Name;
                    NewSalary = selectedEmployee.Salary.ToString();
                    NewPosition = selectedEmployee.Position;
                }

                CommandManager.InvalidateRequerySuggested();
            }
        }

        private string newName;

        public string NewName
        {
            get => newName;
            set
            {
                newName = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private string newSalary;

        public string NewSalary
        {
            get => newSalary;
            set
            {
                newSalary = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private string newPosition;

        public string NewPosition
        {
            get => newPosition;
            set
            {
                newPosition = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public EmployeeViewModel()
        {
            Employees = new ObservableCollection<Employee>();

            Employees.Add(new Employee(
                "Иван Иванов", 50000, "Программист"));

            Employees.Add(new Employee(
                "Петр Петров", 65000, "Менеджер"));

            Employees.Add(new Employee(
                "Анна Смирнова", 70000, "Дизайнер"));

            AddCommand = new RelayCommand(
                AddEmployee,
                CanAddEmployee);

            DeleteCommand = new RelayCommand(
                DeleteEmployee,
                CanDeleteEmployee);
        }

        // Проверка добавления
        private bool CanAddEmployee(object parameter)
        {
            return !string.IsNullOrWhiteSpace(NewName)
                && double.TryParse(NewSalary, out double salary)
                && salary >= 0;
        }

        // Добавление сотрудника
        private void AddEmployee(object parameter)
        {
            if (!CanAddEmployee(parameter))
                return;

            double salary = double.Parse(NewSalary);

            Employee employee = new Employee(
                NewName,
                salary,
                NewPosition ?? "");

            Employees.Add(employee);

            NewName = "";
            NewSalary = "";
            NewPosition = "";

            SelectedEmployee = null;
        }

        // Проверка удаления
        private bool CanDeleteEmployee(object parameter)
        {
            return SelectedEmployee != null;
        }

        // Удаление сотрудника
        private void DeleteEmployee(object parameter)
        {
            if (SelectedEmployee != null)
            {
                Employees.Remove(SelectedEmployee);

                SelectedEmployee = null;

                NewName = "";
                NewSalary = "";
                NewPosition = "";
            }
        }

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
