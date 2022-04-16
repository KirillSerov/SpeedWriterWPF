using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using SpeedWriterWPF.Classes;
using System.ComponentModel;
using SpeedWriterWPF.ViewModels;

namespace SpeedWriterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainViewModel;
        private int count = 0;                                    // счетчик символов
        private bool onOff = true;                                // true - процесс запущен, false - выключен
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainWindowViewModel();
            mainViewModel.Countdown.SetSeconds(60);
            mainViewModel.Countdown.PropertyChanged += Countdown_End;
            mainViewModel.RunningLine.SetText(Loader.LoadText()); // Загружает текст в label.
            DataContext = mainViewModel;

        }

        // Обработчик события изменения счетчика обратного отсчета. Нужен дял проверки того, что отсчет завершен.
        private void Countdown_End(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is Countdown countdown)
            {
                if (countdown.Count == 0)
                {
                    onOff = false;
                    MessageBox.Show($"Выш результат: {count} символов");
                    Retry.IsEnabled = true;
                }
            }
        }

        // Обработчик ввода с клавиатуры.
        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Если программа запущена (т.е. готова к вводу), начинаем обработку ввода.
            if (onOff)
            {
                if (e.Text == mainViewModel?.RunningLine?.NewText[0].ToString())
                {
                    if (!mainViewModel.Countdown.State)
                        mainViewModel?.Countdown?.StartCountdown();

                    mainViewModel?.RunningLine.MoveText(18);
                    count++;

                }
            }
        }

        // Обработчик повторного запуска.
        private void Retry_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.Countdown.ResetCountdown();
            count = 0;
            mainViewModel.RunningLine.SetText(Loader.LoadText());
            Retry.IsEnabled = false;
            onOff = true;
        }
    }
}

