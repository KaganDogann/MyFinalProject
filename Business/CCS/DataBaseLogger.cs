using System;

namespace Business.CCS
{
    public class DataBaseLogger : ILogger //Logları dosyaya alıyorum.
    {
        public void Log()
        {
            Console.WriteLine("Veritabanına Loglandı");
        }
    }
}
