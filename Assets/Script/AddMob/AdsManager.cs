using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public BonnyAds bonnyAds;
    public CatAds catAds;
    public PlanetAds planetAds;
    public AdsHeartRewarded heartBonus;

    public static AdsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        bonnyAds.LoadRewardedBonnyAd();
        catAds.LoadRewardedCatAd();
        planetAds.LoadRewardedPlanetAd();
        heartBonus.LoadRewardedHeartBonusAd();
    }
}
