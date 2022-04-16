using System;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SpeedWriterWPF.Classes
{
    /*
     * Класс реализует обратный отсчет.
     * С помощью метода SetSeconds можно установить начало отсчета. По-умолчанию это 60 секунд.
     * Текущее значение отсчета можно узнать через свойство Count.
     * Свойство State имеет занчение true, если отсчет запущен. false - если выключен.
     * Запуск отсчета производится вызовом метода StartCountdown. Сброс - ResetCountdown.
     * Данный класс может уведомлять об изменении свойств Count.
     */
    public class Countdown : INotifyPropertyChanged
    {
        private int _count = 60;
        private int _seconds = 60; // Начало отсчета. Переменная нужна, чтобы потом сбрасывать счетчик.
        public bool State { get; private set; } // Состояние счетчика: true - вкл, false - выкл.
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public async Task StartCountdown()
        {
            if (!State)
            {
                State = true;
                while (_count > 0)
                {
                    await Task.Delay(1000);
                    Count--;
                }
                State = false;
            }
        }
        public void SetSeconds(int seconds)
        {
            if (seconds >= 0)
            {
                _seconds = _count = seconds;
            }
        }
        public void ResetCountdown()
        {
            _count = _seconds;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
