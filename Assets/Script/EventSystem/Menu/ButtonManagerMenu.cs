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
        _settingPanel.SetActive(true);
        _buttonPanel.SetActive(false);
        _countersPanel.SetActive(false);
    }

    public void SettingOFF()
    {
        _settingPanel.SetActive(false);
        _buttonPanel.SetActive(true);
        _countersPanel.SetActive(true);
    }
    #endregion

    #region "Panel-Shop"
    public void ShopON()
    {
        _shopPanel.SetActive(true);
        _buttonPanel.SetActive(false);
        _countersPanel.SetActive(false);
    }

    public void ShopOFF()
    {
        ShopSwitchCoins();
        _buttonPanel.SetActive(true);
        _countersPanel.SetActive(true);
        _shopPanel.SetActive(false);
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
