using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ButtonManagerMainGame : SFXManager
{
    [Header("Panel")]
    [SerializeField] private GameObject _pausePanel;

    [Header("Properti")]
    public static bool _isDoublingCoinsButton = false;
    public static bool _isAddHeart = false;
    public static int AdsInterstitital;

    [Header("GameComponent")]
    [SerializeField] private Animator _interfaceAnomator;
    [SerializeField] private PostProcessVolume _settingPost;

    [Header("ADS")]
    [SerializeField] private InterstitialAd _interstitial;
    [SerializeField] private RewardedAdReset _rewardedReset;
    [SerializeField] private RewardedAdCoin _rewardedCoin;
    [SerializeField] private RewardedAdHeart _rewardedHeart;

    private  bool _limitedResume = false;
    public static bool _resume = false;

    private void Start()
    {
        Time.timeScale = 1f;
        _limitedResume = false;
        _resume = false;
        _isAddHeart = false;
        _pausePanel.SetActive(false);
        FallingObjectScript._speedFalling = 2;
    }

    private void Update()
    {
        int postProces = PlayerPrefs.GetInt("QualityIndex");

        if (postProces >= 3)
        {
            _settingPost.enabled = false;
        }
        else
        {
            _settingPost.enabled = true;
        }
    }

    public void Menu()
    {
        SoundSFX();
        PlayerPrefs.SetInt("MoneySave", Counter.CounterMoney);
        PlayerPrefs.SetInt("ScoreSave", Counter.CounterScore);

        SceneManager.LoadScene("Menu");
    }

    public void ResetGame()
    {
        SoundSFX();
        ResetdGameSave();

        if(AdsInterstitital < 3)
        {
            AdsInterstitital++;
            SceneManager.LoadScene("MainGame");
        }
        else
        {
            _interstitial.ShowAd();
        }
    }

    public void ResumeGame()
    {
        SoundSFX();
        if (_limitedResume == false)
        {
            _rewardedReset.ShowAd();
            Invoke("Resume", 0.5f);

            _limitedResume = true;
        }
    }

    private void Resume()
    {
        ButtonManagerMainGame._resume = false;
    }

    public void BonusHealth()
    {
        SoundSFX();

        if (_isAddHeart == false)
        {
            _rewardedHeart.ShowAd();
        }
    }

    public void DoublingCoins()
    {
        SoundSFX();
        _rewardedCoin.ShowAd();
    }

    #region "Pause-Panel"
    public void PauseON()
    {
        SoundSFX();
        _interfaceAnomator.SetTrigger("InterfaceOff");

        Invoke("PausePanelOpen", 1);
    }

    public void PauseOFF()
    {
        SoundSFX();
        TimeScaleOne();

        _interfaceAnomator.SetTrigger("PauseOff");
        
        Invoke("PausePanelClose", 1);
    }
    #endregion

    private void ResetdGameSave()
    {
        int _sceneMoney = PlayerPrefs.GetInt("MoneySave");
        int _menuMoney = PlayerPrefs.GetInt("MoneyEarnedSave");

        int _sceneScore = PlayerPrefs.GetInt("ScoreSave");
        int _menuScore = PlayerPrefs.GetInt("BestScoreSave");

        if (_sceneMoney != 0)
        {
            _menuMoney += _sceneMoney;
            PlayerPrefs.SetInt("MoneySave", 0);
        }

        if (_menuScore < _sceneScore)
        {
            _menuScore = _sceneScore;
            PlayerPrefs.SetInt("ScoreSave", 0);
        }

        PlayerPrefs.SetInt("BestScoreSave", _menuScore);
        PlayerPrefs.SetInt("MoneyEarnedSave", _menuMoney);
    }

    private void PausePanelClose()
    {
        _pausePanel.SetActive(false);

        _interfaceAnomator.SetTrigger("InterfaceOn");
    }

    private void PausePanelOpen()
    {
        _pausePanel.SetActive(true);
        _interfaceAnomator.SetTrigger("PauseOn");

        Invoke("TimeScaleZero", 1.5f);

    }

    private void TimeScaleOne()
    {
        Time.timeScale = 1f;
    }

    private void TimeScaleZero()
    {
        Time.timeScale = 0f;
    }

    private void SoundSFX()
    {
        PlaySFX(_allClips[Random.Range(0, 3)], pinch: 0.8f, volume: 0.6f);
    }

}
