using Course.Observers;

namespace Course.Managers.LocalizationManager
{
    public interface ILocalizationManager
    {
        ObserverList<IOnLanguageChanged> OnLanguageChanged { get; }

        Language CurrentLanguage { get; set; }

        string GetString(LocalizedString str);
    }
}
