using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManagerMenu : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _settingPanel;

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
}
