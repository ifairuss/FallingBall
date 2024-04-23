using UnityEngine;

public class AdsManagerGame : MonoBehaviour
{
    public RewardedAdCoin RewardedAdCoin;
    public RewardedAdHeart RewardedAdHeart;
    public RewardedAdReset RewardedAdReset;

    public static AdsManagerGame instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        RewardedAdCoin.LoadRewardedCoinAd();
        RewardedAdHeart.LoadRewardedHeartAd();
        RewardedAdReset.LoadRewardedResetAd();
    }
}
