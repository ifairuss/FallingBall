
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _countTextScore;
    [SerializeField] private TextMeshProUGUI _countTextScoreGameOver;
    [SerializeField] private TextMeshProUGUI _countTextHealth;

    public int CounterScore;
    public int CounterHealth;

    private void Start()
    {
        Time.timeScale = 1f;
        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        TextDisplay();
        GameOver();
    }

    private void TextDisplay()
    {
        _countTextScore.text = CounterScore.ToString();
        _countTextHealth.text = CounterHealth.ToString();
        _countTextScoreGameOver.text = _countTextScore.text;
    }

    private void GameOver()
    {
        if (CounterHealth <= 0)
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
