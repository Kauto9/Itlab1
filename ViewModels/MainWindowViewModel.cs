using System;
using System.Reactive;
using Avalonia.Threading;
using DateApp.Models;
using ReactiveUI;

namespace DateApp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private Date _date;
        private string _result;

        public int Day
        {
            get => _date.Day;
            set
            {
                _date.Day = value;
                this.RaisePropertyChanged(nameof(Day));
                UpdateResult();
            }
        }

        public int Month
        {
            get => _date.Month;
            set
            {
                _date.Month = value;
                this.RaisePropertyChanged(nameof(Month));
                UpdateResult();
            }
        }

        public int Year
        {
            get => _date.Year;
            set
            {
                _date.Year = value;
                this.RaisePropertyChanged(nameof(Year));
                UpdateResult();
            }
        }

        public string Result
        {
            get => _result;
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }

        public ReactiveCommand<Unit, Unit> AddDaysCommand { get; }

        public MainWindowViewModel()
        {
            _date = new Date(1, 1, 2025);
            _result = string.Empty;
            UpdateResult();
            AddDaysCommand = ReactiveCommand.Create(() =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        Result = $"Ошибка: {ex.Message}";
                    }
                });
            });
        }
        

        private void UpdateResult()
        {
            Result = $"Дата: {_date.Day:00}.{_date.Month:00}.{_date.Year} " +
                    $"День недели: {_date.DayOfWeek} " +
                    $"Дней в месяце: {_date.GetDaysInMonth()}";
        }
    }
}