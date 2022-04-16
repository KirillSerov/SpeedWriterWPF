using System;
using System.IO;

namespace SpeedWriterWPF.Classes
{
    /*
     * Класс возвращает текст одного из трех текстовыйх файлов
     * */
    public static class Loader
    {
        public static string LoadText()
        {
            int indexTextFile = new Random().Next(1, 4);
            return (string)TextList.ResourceManager.GetObject("TextFile"+indexTextFile);
        }
    }
}
