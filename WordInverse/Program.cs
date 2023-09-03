// See https://aka.ms/new-console-template for more information
using System.Text;

string path = @"C:\FilesForInverse\FileBaseWithWords.txt"; // директория (папка) должна уже быть

try
{
    // файла нету => пишет; файл есть => переписывает;
    using (FileStream fileStreamForWrite = File.Create(path))
    {
        byte[] wordsForInverse = new UTF8Encoding(true).GetBytes("маша\r\nстол\r\nземля\r\nнебо\r\nрадуга\r\nБарни\r\nсолнышко\r\nФарида Сеид-заде");

        // Add some information to the file.
        fileStreamForWrite.Write(wordsForInverse, 0, wordsForInverse.Length);
    }

    // читает в консоли файл
    using (StreamReader streamReaderForRead = File.OpenText(path))
    {
        if (streamReaderForRead != null)
        {
            string streamTemps = "";
            while ((streamTemps = streamReaderForRead.ReadLine()) != null)
            {
                char[] stringArray = streamTemps.ToCharArray();
                Array.Reverse(stringArray);
                string reversedStr = new string(stringArray);
                Console.Write($"\n{streamTemps} => {reversedStr}");
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}