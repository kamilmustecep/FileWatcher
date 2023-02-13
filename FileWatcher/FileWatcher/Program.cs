using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // FileSystemWatcher nesnesini oluştur
            FileSystemWatcher watcher = new FileSystemWatcher();

            // Hangi dizinde veya dosyada değişiklikleri takip edeceğimizi belirtiyoruz
            watcher.Path = @"C:\Example";

            // Değişiklikleri takip etmek için filtre belirtiyoruz
            watcher.Filter = "*.txt";

            // Değişiklikleri takip etmek için olayları abone oluyoruz
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;

            // FileSystemWatcher'ı etkinleştiriyoruz
            watcher.EnableRaisingEvents = true;

            // Uygulamayı bekletiyoruz
            Console.ReadLine();
        }


        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} dosyası oluşturuldu.");
        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} dosyası silindi.");
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} dosyası değiştirildi.");
        }

        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"{e.OldName} dosyasının adı {e.Name} olarak değiştirildi.");
        }

    }
}
