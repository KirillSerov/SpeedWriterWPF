using System;
using System.ComponentModel;
using System.IO;

namespace SpeedWriterWPF.Classes
{
    /*
     Класс реализует перенос строки из одного текстового контейнера в другой (похоже на бегущую строку).
    */
    public class RunningLine : INotifyPropertyChanged
    {
        private string newText; // Текст, который будет переноситься.
        private string oldText; // Куда будет переноситься текст из newText.
        public RunningLine()
        {
            newText = "";
            oldText = "";
        }
        public string NewText
        {
            get => newText;
            set
            {
                newText = value;
                OnPropertyChanged(nameof(this.NewText));
            }
        }
        public string OldText
        {
            get => oldText;
            set
            {
                oldText = value;
                OnPropertyChanged(nameof(OldText));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


       /* Метод, двигающий текст.
        * Параметр count - количество символов, которые могут поместиться в контейнере, привязанном к OldText.
        * Если символов больше, чем count, строка обрезается вначале.
        */
        public void MoveText(int count)
        {
            if (!string.IsNullOrEmpty(newText))
            {
                if (OldText.Length > count)
                    OldText = OldText.Substring(1);
                OldText += NewText[0];
                NewText = NewText.Substring(1);
            }
        }

        public void SetText(string text)
        { 
            if(string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            NewText = text;
            OldText = "";
        }
    }
}
