using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _countTextScoreGameOver;
    [SerializeField] private TextMeshProUGUI _countTextMoneyGameOver;

    private Counter _counter;

    private void Start()
    {
        _counter = GetComponent<Counter>();

        Time.timeScale = 1f;

        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        GameOverPanel(_counter);
    }

    private void GameOverPanel(Counter counter)
    {
        if (counter.CounterHealth <= 0)
        {
            PlayerPrefs.SetInt("MainGameScore", counter.CounterScore);
            PlayerPrefs.SetInt("MainGameMoney", counter.CoutnerMoney);
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        _countTextScoreGameOver.text = _counter.CounterScore.ToString();
        _countTextMoneyGameOver.text = _counter.CoutnerMoney.ToString();
    }

}
