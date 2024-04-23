using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }

    public void LoadInterstitialAd()
    {
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
        LoadInterstitialAd();
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

    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) {
        SceneManager.LoadScene("MainGame");
        LoadInterstitialAd();
    }
}
