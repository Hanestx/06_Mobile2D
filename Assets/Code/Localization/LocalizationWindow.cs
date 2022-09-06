using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;


public class LocalizationWindow : MonoBehaviour
{
    [SerializeField] private Button _ruButton;
    [SerializeField] private Button _engButton;
    
    private void Start()
    {
        _ruButton.onClick.AddListener(() => ChangeLanguage(0));
        _engButton.onClick.AddListener(() => ChangeLanguage(1));
    }

    private void OnDestroy()
    {
        _ruButton.onClick.RemoveAllListeners();
        _engButton.onClick.RemoveAllListeners();
    }

    private void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
