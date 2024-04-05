using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _countTextScoreGameOver;
    [SerializeField] private TextMeshProUGUI _countTextMoneyGameOver;

    private void Start()
    {
        Time.timeScale = 1f;

        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        GameOverPanel();
    }

    private void GameOverPanel()
    {
        if (Counter.CounterHealth <= 0)
        {
            PlayerPrefs.SetInt("MainGameScore", Counter.CounterScore);
            PlayerPrefs.SetInt("MainGameMoney", Counter.CounterMoney);
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        _countTextScoreGameOver.text = Counter.CounterScore.ToString();
        _countTextMoneyGameOver.text = Counter.CounterMoney.ToString();
    }

}
