using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _countTextScoreGameOver;
    [SerializeField] private TextMeshProUGUI _countTextMoneyGameOver;
    [SerializeField] private Image _bonusCoinsImage;

    public bool _isGameOver = false;

    private ButtonManagerMainGame _buttonMainGame;

    private void Start()
    {
        _buttonMainGame = FindObjectOfType<ButtonManagerMainGame>();

        Time.timeScale = 1f;

        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        TimerBonusCoin();
        GameOverPanel();
    }

    private void GameOverPanel( )
    {
        if (Counter.CounterHealth <= 0)
        {
            _isGameOver=true;
            _buttonMainGame._bonusCoinsPanel.SetActive(true);
            _bonusCoinsImage.fillAmount = TimerBonusCoin();

            if (_buttonMainGame._bonusCoinsPanel == false)
            {
                PlayerPrefs.SetInt("ScoreSave", Counter.CounterScore);
                PlayerPrefs.SetInt("MoneySave", Counter.CounterMoney);
                _gameOverPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        _countTextScoreGameOver.text = Counter.CounterScore.ToString();
        _countTextMoneyGameOver.text = Counter.CounterMoney.ToString();
    }

    private float TimerBonusCoin()
    {
        float _timer = 1f;

        if(_timer > 0)
        {
            _timer -= 0.05f;
        }
        else
        {
            _timer = 0f;
        }

        return _timer;
    }

}
