using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerMainGame : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject _pausePanel;

    [Header("Button")]
    public static bool _isDoublingCoinsButton = false;

    private bool _limitedResume = false;

    private void Start()
    {
        Time.timeScale = 1f;
        _limitedResume = false;
        _pausePanel.SetActive(false);
    }

    public void Menu()
    {
        PlayerPrefs.SetInt("MoneySave", Counter.CounterMoney);
        PlayerPrefs.SetInt("ScoreSave", Counter.CounterScore);

        SceneManager.LoadScene("Menu");
    }

    public void ResetGame()
    {
        ResetdGameSave();
        SceneManager.LoadScene("MainGame");
    }

    public void ResumeGame()
    {
        if (_limitedResume == false)
        {
            Counter.CounterHealth = 1;
            _limitedResume = true;
            Time.timeScale = 1f;
        }
    }

    public void BonusHealth() => Counter.CounterHealth++;
    public void DoublingCoins()
    {
        Counter.CounterMoney = Counter.CounterMoney * 2;
        _isDoublingCoinsButton = true;
    }

    #region "Pause-Panel"
    public void PauseON()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    public void PauseOFF()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
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


}
