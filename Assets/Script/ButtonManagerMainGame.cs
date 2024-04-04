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

    public void Menu(Counter counter)
    {
        PlayerPrefs.SetInt("MainGameScore", counter.CounterScore);
        PlayerPrefs.SetInt("MainGameMoney", counter.CoutnerMoney);
        SceneManager.LoadScene("Menu");
    }

    public void MainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ResumeGame()
    {
        Debug.Log("Перепрошую вашу рекламу не вдалося загрузити..");
    }

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
