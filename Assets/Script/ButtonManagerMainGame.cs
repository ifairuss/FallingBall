using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerMainGame : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject _pausePanel;

    private void Start()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
    }

    public void Menu()
    {      
        int _saveSceneManey = PlayerPrefs.GetInt("MainGameSaveMoney");
        int _sceneMoney = Counter.CounterMoney;

        if (_saveSceneManey != 0)
        {           
            if(_sceneMoney != 0)
            {
                _saveSceneManey += _sceneMoney;
            }

            PlayerPrefs.SetInt("MainGameMoney", _saveSceneManey);
        }
        else
        {
            PlayerPrefs.SetInt("MainGameMoney", Counter.CounterMoney);
        }

        PlayerPrefs.SetInt("MainGameScore", Counter.CounterScore);

        SceneManager.LoadScene("Menu");
    }

    public void ResetGame()
    {
        int _sceneMoney = PlayerPrefs.GetInt("MainGameMoney");
        int _saveSceneManey = PlayerPrefs.GetInt("MainGameSaveMoney");


        if(_sceneMoney != 0)
        {
            _saveSceneManey += _sceneMoney;
        }

        PlayerPrefs.SetInt("MainGameMoney", 0);
        PlayerPrefs.SetInt("MainGameSaveMoney", _saveSceneManey);

        SceneManager.LoadScene("MainGame");
    }

    public void ResumeGame() => Debug.Log("Перепрошую вашу рекламу не вдалося загрузити..");
    public void BonusHealth() => Counter.CounterHealth++;

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


}
