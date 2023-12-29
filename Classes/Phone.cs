using Phonestore.Interfaces;

namespace Phonestore.Classes
{
    public class Phone : IAppInstaller
    {
        private const int default_app_size = 100;
        private string vendor { get; }
        private string model { get; }
        private float cpu_freq { get; }
        private ushort core_count { get; }
        private uint ram_size { get; }
        private RamType ram_type { get; }
        private uint total_storage { get; }
        private OsType os_type { get; }
        private string imei { get; }
        internal List<IInstallable> apps = new List<IInstallable>();

        public Phone(string vendor, string model, float cpu_freq, ushort core_count,
            uint ram_size, RamType ram_type, uint total_storage, OsType os_type, string imei)
        {
            if (string.IsNullOrWhiteSpace(vendor))
            {
                throw new ArgumentException("Поле 'Производитель' не может быть пустым");
            }
            if (vendor.Any(c => !char.IsLetterOrDigit(c) && c != ' '))
            {
                throw new ArgumentException("Поле 'Производитель' содержит недопустимый символ");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Поле 'Модель' не может быть пустым");
            }
            if (model.Any(c => !char.IsLetterOrDigit(c) && c != ' '))
            {
                throw new ArgumentException("Поле 'Модель' содержит недопустимый символ");
            }

            if (cpu_freq <= 0)
            {
                throw new ArgumentException("Поле 'частота ЦПУ' не может быть меньше либо равно нулю");
            }

            if (core_count < 1)
            {
                throw new ArgumentException("Поле 'количество ядер ЦПУ' не может быть меньше единицы");
            }

            if (ram_size <= 0)
            {
                throw new ArgumentException("Поле 'объём оперативной памяти (ОП)' не может быть меньше либо равно нулю");
            }

            if (total_storage <= 0)
            {
                throw new ArgumentException("Поле 'объём вторичной памяти (ВП)' не может быть меньше либо равно нулю");
            }

            foreach (char c in imei)
            {
                if (!char.IsDigit(c) && c != '-')
                {
                    throw new ArgumentException("Поле 'IMEI' может содержать только цифры и спец. разделитель '-'");
                }
            }

            this.vendor = vendor;
            this.model = model;
            this.cpu_freq = cpu_freq;
            this.core_count = core_count;
            this.ram_size = ram_size;
            this.ram_type = ram_type;
            this.total_storage = total_storage;
            this.os_type = os_type;
            this.imei = imei;
        }
        public Phone()
            : this("Unknown", "Unknown", 1, 1, 1, RamType.UNKNOWN, 1, OsType.UNKNOWN, "000000000000000")
        {
        }

        public override string ToString()
        {
            return $"Производитель: {vendor}\n" +
                   $"Модель: {model}\n" +
                   $"Частота ЦПУ: {cpu_freq:F1}\n" +
                   $"Количество ядер ЦПУ: {core_count}\n" +
                   $"Объём оперативной памяти (ОП): {ram_size}\n" +
                   $"Тип ОП: {RamTypeNames.Names[ram_type]}\n" +
                   $"Объём вторичной памяти (ВП): {total_storage}\n" +
                   $"Операционная система (ОС): {OsTypeNames.Names[os_type]}\n" +
                   $"Количество установленных приложений: {apps.Count}\n" +
                   $"Объём занимаемой приложениями ВП: {GetUsedStorage()}\n" +
                   $"IMEI: {imei}";
        }

        public long GetUsedStorage()
        {
            return apps.Sum(app => app.Size);
        }

        public long GetFreeStorage()
        {
            return total_storage - GetUsedStorage();
        }

        public int GetMeanInstallableAppCount()
        {
            if (apps.Count == 0)
            {
                return (int)(GetFreeStorage() / default_app_size);
            }

            double mean_app_size = GetUsedStorage() / apps.Count;
            return (int)(GetFreeStorage() / mean_app_size);
        }

        public void PerformFactoryReset()
        {
            apps.Clear();
        }

        public void InstallApp(IInstallable app)
        {
            if (IsInstalled(app))
            {
                throw new ArgumentException("На смартфоне не может быть два приложения с одинаковыми названиями");
            }

            if (GetFreeStorage() < app.Size)
            {
                throw new InvalidOperationException("На смартфоне нет свободной ВП для установки приложения");
            }

            apps.Add(app);
        }

        public void RemoveApp(IInstallable app)
        {
            apps.Remove(app);
        }

        public bool IsInstalled(IInstallable app)
        {
            return apps.Contains(app);
        }

        public string GetAppInfo(IInstallable app)
        {
            if (app is IAppInfo appInfo)
            {
                return $"Название: {appInfo.GetName()}, Размер: {appInfo.GetSize()}";
            }
            else
            {
                // Обрабатываем случай когда приложение не реализует класс IAppInfo
                return "Информация недоступна";
            }
        }
    }
}