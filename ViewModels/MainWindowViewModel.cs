using SpeedWriterWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedWriterWPF.ViewModels
{
    /*
     Класс, связывающий обратный отсчет и бегущую строку с главным окном*/
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            RunningLine = new RunningLine();
            Countdown = new Countdown();
        }
        public RunningLine RunningLine { get;}
       
        public Countdown Countdown { get;}
    }
}

