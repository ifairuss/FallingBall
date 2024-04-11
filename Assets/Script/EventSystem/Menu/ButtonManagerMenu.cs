using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManagerMenu : MonoBehaviour
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

    private void Start()
    {
        Time.timeScale = 1f;


        _settingPanel.SetActive(false);
        _shopPanel.SetActive(false);
        _countersPanel.SetActive(true);
        _buttonPanel.SetActive(true);
    }

    public void Play()
    {
        _animatorInterface.SetTrigger("InterfaceOff");

        Invoke("StartGame", 1);
    }

    private void StartGame()
    {
        PlayerPrefs.SetInt("MainGameSaveMoney", 0);
        SceneManager.LoadScene("MainGame");
    }

    public void YouTube() => Application.OpenURL("https://www.youtube.com/@ifairuss2");

    public void LeaderBord()
    {
        Debug.Log("To be continued..");
    }

    #region "Panel-Setting"
    public void SettingON()
    {
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
        _animatorInterface.SetTrigger("SettingOff");
        _animatorInterface.SetTrigger("Defaulth");

        Invoke("SettingClosePanel", 1f);
    }
    #endregion

    #region "Panel-Shop"
    public void ShopON()
    {
        _animatorInterface.SetTrigger("InterfaceOff");

        Invoke("ShopOnOpenPanel", 1f);
    }

    public void ShopOFF()
    {
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
        ShopSwitchCoins();

        _buttonPanel.SetActive(true);
        _countersPanel.SetActive(true);
        _shopPanel.SetActive(false);

        _animatorInterface.SetTrigger("InterfaceOn");
        _animatorInterface.SetTrigger("Defaulth");
    }

    public void ShopSwitchAdvertising()
    {
        _shopBonus.SetActive(false);
        _shopSkins.SetActive(false);
        _buttonBonus.color = new Color(0, 0, 0, 0.35f);
        _buttonSkins.color = new Color(0, 0, 0, 0.35f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.6f);
        _shopAdvertising.SetActive(true);
    }

    public void ShopSwitchCoins()
    {
        _shopAdvertising.SetActive(false);
        _shopSkins.SetActive(false);
        _buttonBonus.color = new Color(0, 0, 0, 0.6f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.35f);
        _buttonSkins.color = new Color(0, 0, 0, 0.35f);
        _shopBonus.SetActive(true);
    }

    public void ShopSwitchSkins()
    {
        _shopAdvertising.SetActive(false);
        _shopBonus.SetActive(false);
        _buttonSkins.color = new Color(0, 0, 0, 0.6f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.35f);
        _buttonBonus.color = new Color(0, 0, 0, 0.35f);
        _shopSkins.SetActive(true);
    }
    #endregion
}
