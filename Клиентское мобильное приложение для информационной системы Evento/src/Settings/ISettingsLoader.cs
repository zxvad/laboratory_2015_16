namespace Evento.Client.Settings
{
    public interface ISettingsLoader
    {
        bool LoadSettings();
        bool SaveSettings();
        bool ResetSettings();
    }
}