using Phonestore.Classes;
using Phonestore.Interfaces;

namespace Phonestore
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Тест: Ошибка в конструкторе 1");
                Phone phone1 = new Phone("Apple", "iPhone 7", 2.5f, 4, 2048, RamType.LPDDR4X, 0, OsType.ANDROID, "35-419002-389644-3");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Тест: Ошибка в конструкторе 2");
                Phone phone2 = new Phone("Apple", "iPhone 7", 2.5f, 4, 2048, RamType.LPDDR4X, 32768, OsType.ANDROID, "35-419002-389644-3");
                App app = new App("Facebook", 300);
                phone2.InstallApp(new App("Facebook", 300));
                phone2.InstallApp(new App("Facebook", 120)); // то же название, другой размер сделать!
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Тест: Ошибка при установке приложения");
                Phone phone3 = new Phone("Apple", "iPhone 7", 2.5f, 4, 2048, RamType.LPDDR4X, 32768, OsType.ANDROID, "35-419002-389644-3");
                phone3.InstallApp(new App("Minecraft", 0));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Тест: Вывод среднего количества приложений, для установки которых хватит свободного места");
                Phone phone4 = new Phone("Apple", "iPhone 7", 2.5f, 4, 2048, RamType.LPDDR4X, 32768, OsType.ANDROID, "35-419002-389644-3");
                phone4.InstallApp(new App("Facebook", 120));
                phone4.InstallApp(new App("Chrome", 999));
                phone4.InstallApp(new App("YouTube", 1999));
                Console.WriteLine("Места хватит на " + phone4.GetMeanInstallableAppCount() + " приложений");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Тест: Вывод информации о смартфоне");
                Phone phone5 = new Phone("Apple", "iPhone 7", 2.5f, 4, 2048, RamType.LPDDR4X, 32768, OsType.ANDROID, "35-419002-389644-3");
                Console.WriteLine(phone5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Тест: Вывод списка приложений");
                Phone phone6 = new Phone("Apple", "iPhone 11", 3.5f, 6, 2048, RamType.LPDDR4X, 32768, OsType.ANDROID, "35-419002-389644-3");
                App Facebook = new App("Facebook", 120);
                App Chrome = new App("Chrome", 999);
                App Youtube = new App("YouTube", 1999);
                phone6.InstallApp(Facebook);
                phone6.InstallApp(Chrome);
                phone6.InstallApp(Youtube);

                foreach (IInstallable app in phone6.apps)
                {
                    Console.WriteLine(phone6.GetAppInfo(app));
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Тест: Очистка списка приложений");
                Phone phone7 = new Phone("Apple", "iPhone 7", 2.5f, 4, 2048, RamType.LPDDR4X, 32768, OsType.ANDROID, "35-419002-389644-3");
                phone7.InstallApp(new App("Facebook", 120));
                phone7.InstallApp(new App("Chrome", 999));
                phone7.InstallApp(new App("YouTube", 1999));
                Console.WriteLine("Список приложений до сброса: ");
                foreach (var app in phone7.apps)
                {
                    Console.WriteLine(phone7.GetAppInfo(app));
                }
                Console.WriteLine();
                phone7.PerformFactoryReset();
                Console.WriteLine("Список приложений после сброса: ");
                foreach (var app in phone7.apps)
                {
                    Console.WriteLine(phone7.GetAppInfo(app));
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Тест: Проверка установлено ли приложение");
                App app = new App("Facebook", 120);
                Phone phone8 = new Phone("Apple", "iPhone 7", 2.5f, 4, 2048, RamType.LPDDR4X, 32768, OsType.ANDROID, "35-419002-389644-3");
                phone8.InstallApp(app);
                Console.WriteLine("Приложение '" + app.Name + "' установлено? - " + (phone8.IsInstalled(app) ? "да" : "нет"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}