using System; // Добавлено

namespace DateApp.Models
{
    public enum DayOfWeekEnum
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class Date
    {
        private int _day;
        private int _month;
        private int _year;

        public int Day 
        { 
            get => _day; 
            set 
            { 
                ValidateDate(value, _month, _year); 
                _day = value; 
            } 
        }
        public int Month 
        { 
            get => _month; 
            set 
            { 
                ValidateDate(_day, value, _year); 
                _month = value; 
            } 
        }
        public int Year 
        { 
            get => _year; 
            set 
            { 
                ValidateDate(_day, _month, value); 
                _year = value; 
            } 
        }
        public DayOfWeekEnum DayOfWeek => CalculateDayOfWeek();

        public Date(int day, int month, int year)
        {
            ValidateDate(day, month, year);
            _day = day;
            _month = month;
            _year = year;
        }

        public int GetDaysInMonth()
        {
            return DateTime.DaysInMonth(_year, _month);
        }

        private void ValidateDate(int day, int month, int year)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException("Месяц должен быть от 1 до 12");
            
            if (day < 1 || day > DateTime.DaysInMonth(year, month))
                throw new ArgumentException("Недопустимое количество дней для указанного месяца и года");
            
            if (year < 1 || year > 9999)
                throw new ArgumentException("Год должен быть от 1 до 9999");
        }

        private DayOfWeekEnum CalculateDayOfWeek()
        {
            DateTime date = new DateTime(_year, _month, _day);
            return (DayOfWeekEnum)((int)date.DayOfWeek == 0 ? 7 : (int)date.DayOfWeek);
        }
        
        
    }
}