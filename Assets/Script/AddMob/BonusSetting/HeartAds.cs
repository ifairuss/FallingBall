using TMPro;
using UnityEngine;

public class HeartAds : MonoBehaviour
{
    [SerializeField] private string _nameBonus;
    [SerializeField] private string _textDone = "Done";
    [SerializeField] private int _bonusAds;

    [SerializeField] private TextMeshProUGUI _displayTextAdsStats;

    [SerializeField] private AdsHeartRewarded _ads;

    public static int BonusStatus;

    private void Awake()
    {
        BonusStatus = PlayerPrefs.GetInt("HeartAds");
    }

    private void Update()
    {
        BonusStats();
    }

    private void BonusStats()
    {
        string monitAdsStats = $"{BonusStatus}/{_bonusAds}";

        int adsSave = PlayerPrefs.GetInt($"{_nameBonus}");

        if (BonusStatus == _bonusAds || adsSave == 1)
        {
            _displayTextAdsStats.text = _textDone;
            PlayerPrefs.SetInt($"{_nameBonus}", 1);
        }
        else
        {
            _displayTextAdsStats.text = monitAdsStats;
        }
    }

    public void ButtonShowAds()
    {
        int adsSave = PlayerPrefs.GetInt($"{_nameBonus}");

        if (BonusStatus < _bonusAds && adsSave != 1)
        {
            _ads.ShowAd();
        }
    }
}
