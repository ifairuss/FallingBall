using UnityEngine;
using UnityEngine.Advertisements;

public class BonnyAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
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

    public void LoadRewardedBonnyAd()
    {
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
        LoadRewardedBonnyAd();
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            SkinBonny.SkinStatus++;
            PlayerPrefs.SetInt("BonnyAds", SkinBonny.SkinStatus);
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
