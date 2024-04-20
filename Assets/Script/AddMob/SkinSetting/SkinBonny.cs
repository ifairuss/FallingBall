using TMPro;
using UnityEngine;

public class SkinBonny : MonoBehaviour
{
    [SerializeField] private string _nameSkin;
    [SerializeField] private string _textDone = "Done";
    [SerializeField] private int _skinAds;

    [SerializeField] private TextMeshProUGUI _displayTextAdsStats;

    [SerializeField] private BonnyAds _bonnyAds;

    public static int SkinStatus;

    private void Awake()
    {
        SkinStatus = PlayerPrefs.GetInt("BonnyAds");
    }

    private void Update()
    {
        SkinStats();
    }

    private void SkinStats()
    {
        string monitAdsStats = $"{SkinStatus}/{_skinAds}";

        int adsSave = PlayerPrefs.GetInt($"{_nameSkin}");

        if (SkinStatus == _skinAds || adsSave == 1)
        {
            _displayTextAdsStats.text = _textDone;
            PlayerPrefs.SetInt($"{_nameSkin}", 1);
        }
        else
        {
            _displayTextAdsStats.text = monitAdsStats;
        }
    }

    public void ButtonShowAds()
    {
        int adsSave = PlayerPrefs.GetInt($"{_nameSkin}");

        if (SkinStatus < _skinAds && adsSave != 1)
        {
            _bonnyAds.ShowAd();
        }
    }
}
