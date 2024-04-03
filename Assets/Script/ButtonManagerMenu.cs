using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManagerMenu : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _settingPanel;

    [Header("PanelShop")]
    [SerializeField] private GameObject _shopPanelCoins;
    [SerializeField] private GameObject _shopAdvertising;

    [SerializeField] private Image _buttonCoins;
    [SerializeField] private Image _buttonAdvertising;

    private void Start()
    {
        Time.timeScale = 1f;
        _settingPanel.SetActive(false);
        _shopPanel.SetActive(false);
    }

    public void MainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void YouTube()
    {
        Application.OpenURL("https://www.youtube.com/@ifairuss2");
    }

    public void LeaderBord()
    {
        Debug.Log("To be continued..");
    }

    public void SettingON()
    {
        _settingPanel.SetActive(true);
    }

    public void SettingOFF()
    {
        _settingPanel.SetActive(false);
    }

    public void ShopON()
    {
        _shopPanel.SetActive(true);
    }

    public void ShopOFF()
    {
        ShopSwitchCoins();
        _shopPanel.SetActive(false);
    }

    public void ShopSwitchAdvertising()
    {
        _shopPanelCoins.SetActive(false);
        _buttonCoins.color = new Color(0, 0, 0, 0.35f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.6f);
        _shopAdvertising.SetActive(true);
    }

    public void ShopSwitchCoins()
    {
        _shopAdvertising.SetActive(false);
        _buttonCoins.color = new Color(0, 0, 0, 0.6f);
        _buttonAdvertising.color = new Color(0, 0, 0, 0.35f);
        _shopPanelCoins.SetActive(true);
    }
}
