using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Course.Managers.LocalizationManager.Utility
{
    [RequireComponent(typeof(Button))]
    public sealed class SetLanguageButton : MonoBehaviour
    {
        [Inject] ILocalizationManager locaManager = default;
        public Language language;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => locaManager.CurrentLanguage = language);
        }
    }
}
