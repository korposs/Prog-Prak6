namespace Phonestore.Interfaces
{
    public interface IAppInstaller
    {
        void InstallApp(IInstallable app);
        void RemoveApp(IInstallable app);
        bool IsInstalled(IInstallable app);
    }
}
