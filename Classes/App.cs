using Phonestore.Interfaces;

namespace Phonestore.Classes
{
    public class App : IInstallable, IAppInfo
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException(
                        "Поле 'Название приложения' не может быть пустым");
                }
                name = value;
            }
        }

        uint size;
        public uint Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException(
                        "Поле 'Размер приложения' не может быть пустым");
                }
                size = value;
            }
        }

        // конструктор со всеми параметрами
        public App(string name, uint size)
        {
            Name = name;
            Size = size;
        }

        // операторы вывода
        public string GetName()
        {
            return Name;
        }

        public uint GetSize()
        {
            return Size;
        }

        // оператор проверки на равенство
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            App otherApp = (App)obj;
            return name == otherApp.name && size == otherApp.size;
        }
    }
}
