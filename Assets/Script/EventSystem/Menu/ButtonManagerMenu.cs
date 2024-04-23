using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManagerMenu : SFXManager
{
    [Header("Panel")]
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _buttonPanel;
    [SerializeField] private GameObject _countersPanel;

    [Header("PanelShop")]
    [SerializeField] private GameObject _shopBonus;
    [SerializeField] private GameObject _shopAdvertising;
    [SerializeField] private GameObject _shopSkins;

    [SerializeField] private Image _buttonBonus;
    [SerializeField] private Image _buttonAdvertising;
    [SerializeField] private Image _buttonSkins;

    [Header("GameComponent")]
    [SerializeField] private Animator _animatorInterface;
    [SerializeField] private PostProcessVolume _settingPost;

    public bool ConnectedToGooglePlay;

    private void Awake()
    {
        Time.timeScale = 1f;

        _settingPanel.SetActive(false);
        _shopPanel.SetActive(false);
        _countersPanel.SetActive(true);
        _buttonPanel.SetActive(true);

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    private void Start()
    {
        LogInGooglePlay();

        if (ConnectedToGooglePlay)
        {
            int _bestScore = PlayerPrefs.GetInt("BestScoreSave");

            Social.ReportScore(_bestScore, GPGSIds.leaderboard_fallingball, LeaderboardUpdate);
        }
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

    private void LeaderboardUpdate(bool success)
    {
        if (success) Debug.Log("Update Leaderboard");
        else Debug.Log("Unable to update Leaderboard");
    }

    private void LogInGooglePlay()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    private void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            ConnectedToGooglePlay = true;
        }
        else
        {
            ConnectedToGooglePlay = false;
        }    
    }

    public void Play()
    {
        SoundSFX();
        _animatorInterface.SetTrigger("InterfaceOff");

        Invoke("StartGame", 1);
    }

    private void StartGame()
    {
        PlayerPrefs.SetInt("MainGameSaveMoney", 0);
        SceneManager.LoadScene("MainGame");
    }

    public void YouTube()
    {
        SoundSFX();
        Application.OpenURL("https://www.youtube.com/@ifairuss2");
    }

    public void LeaderBord()
    {
        SoundSFX();

        if (!ConnectedToGooglePlay)
        {
            LogInGooglePlay();
        }
        Social.ShowLeaderboardUI();
    }

    #region "Panel-Setting"
    public void SettingON()
    {
        SoundSFX();
        _animatorInterface.SetTrigger("InterfaceOff");

        Invoke("SettingOpenPanel", 1f);
    }

    private void SettingOpenPanel()
    {
        _settingPanel.SetActive(true);
        _buttonPanel.SetActive(false);
        _countersPanel.SetActive(false);

        _animatorInterface.SetTrigger("SettingOn");
    }

    private void SettingClosePanel()
    {
        _settingPanel.SetActive(false);
        _buttonPanel.SetActive(true);
        _countersPanel.SetActive(true);

        _animatorInterface.SetTrigger("InterfaceOn");
        _animatorInterface.SetTrigger("Defaulth");
    }

    public void SettingOFF()
    {
        SoundSFX();
        _animatorInterface.SetTrigger("SettingOff");
        _animatorInterface.SetTrigger("Defaulth");

        Invoke("SettingClosePanel", 1f);
    }
    #endregion

    #region "Panel-Shop"
    public void ShopON()
    {
        SoundSFX();
        _animatorInterface.SetTrigger("InterfaceOff");

        Invoke("ShopOnOpenPanel", 1f);
    }

    public void ShopOFF()
    {
        SoundSFX();
        _animatorInterface.SetTrigger("ShopOff");
        _animatorInterface.SetTrigger("Defaulth");

        Invoke("ShopOffClosePanel", 1f);
    } 

    private void ShopOnOpenPanel()
    {
        _shopPanel.SetActive(true);
        _buttonPanel.SetActive(false);
        _countersPanel.SetActive(false);

        _animatorInterface.SetTrigger("ShopOn");
    }

    private void ShopOffClosePanel()
    {
        ShopSwitchBonus();

        _buttonPanel.SetActive(true);
        _countersPanel.SetActive(true);
        _shopPanel.SetActive(false);

        _animatorInterface.SetTrigger("InterfaceOn");
        _animatorInterface.SetTrigger("Defaulth");
    }

    public void ShopSwitchAdvertising()
    {
        SoundSFX();
        _shopBonus.SetActive(false);
        _shopSkins.SetActive(false);
        _buttonBonus.color = new Color(0, 0, 0, 0.35f);
        _buttonSkins.color = new Color(0, 0, 0, 0.35f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.6f);
        _shopAdvertising.SetActive(true);
    }

    private void ShopSwitchBonus()
    {
        _shopAdvertising.SetActive(false);
        _shopSkins.SetActive(false);
        _buttonBonus.color = new Color(0, 0, 0, 0.6f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.35f);
        _buttonSkins.color = new Color(0, 0, 0, 0.35f);
        _shopBonus.SetActive(true);
    }

    public void ShopSwitchCoins()
    {
        SoundSFX();
        _shopAdvertising.SetActive(false);
        _shopSkins.SetActive(false);
        _buttonBonus.color = new Color(0, 0, 0, 0.6f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.35f);
        _buttonSkins.color = new Color(0, 0, 0, 0.35f);
        _shopBonus.SetActive(true);
    }

    public void ShopSwitchSkins()
    {
        SoundSFX();
        _shopAdvertising.SetActive(false);
        _shopBonus.SetActive(false);
        _buttonSkins.color = new Color(0, 0, 0, 0.6f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.35f);
        _buttonBonus.color = new Color(0, 0, 0, 0.35f);
        _shopSkins.SetActive(true);
    }
    #endregion

    private void SoundSFX()
    {
        PlaySFX(_allClips[Random.Range(0, 3)], pinch: 0.8f, volume: 0.6f);
    }
}
