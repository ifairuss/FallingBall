using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAdReset : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOsAdUnitId = "Rewarded_IOS";
    string _adUnitId;

    void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }

    public void LoadRewardedResetAd()
    {
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
        LoadRewardedResetAd();
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            ButtonManagerMainGame.AdsInterstitital = 0;
            Counter.CounterHealth = 1;
            Time.timeScale = 1f;
            ButtonManagerMainGame._resume = true;
            LoadRewardedResetAd();
        }
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Interstitial Ad Loaded...");
    }

    #region callBack
    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message) { }
    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    #endregion
}
