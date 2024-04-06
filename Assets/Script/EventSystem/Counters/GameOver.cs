using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _doublingCoinsPanel;
    [SerializeField] private TextMeshProUGUI _countTextScoreGameOver;
    [SerializeField] private TextMeshProUGUI _countTextMoneyGameOver;
    [SerializeField] private Image _doublingCoinsImage;

    [Header("Timer")]
    [SerializeField] private float _timerBonusCoin = 1f;

    private bool _noMoney = true;

    private void Start()
    {
        ButtonManagerMainGame._isDoublingCoinsButton = false;
        FallingObjectScript.FallingObjectIsActive = false;
        ObjectSpawner.SpawnerIsActive = true;
        Shot.ShootIsActive = true;

        Time.timeScale = 1f;

        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        GameOverPanel();
    }

    private void GameOverPanel( )
    {
        if (Counter.CounterHealth <= 0)
        {
            DoublingCoinsPanel();

            _doublingCoinsImage.fillAmount = _timerBonusCoin;

            if (_doublingCoinsImage.fillAmount == 0 || ButtonManagerMainGame._isDoublingCoinsButton == true || _noMoney == true)
            {
                PlayerPrefs.SetInt("ScoreSave", Counter.CounterScore);
                PlayerPrefs.SetInt("MoneySave", Counter.CounterMoney);
                _doublingCoinsPanel.SetActive(false);
                _gameOverPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        _countTextScoreGameOver.text = Counter.CounterScore.ToString();
        _countTextMoneyGameOver.text = Counter.CounterMoney.ToString();
    }

    private void DoublingCoinsPanel()
    {
        if(Counter.CounterMoney != 0)
        {
            TimerBonusCoin();

            _noMoney = false;

            ObjectSpawner.SpawnerIsActive = false;
            FallingObjectScript.FallingObjectIsActive = true;
            Shot.ShootIsActive = false;

            _doublingCoinsPanel.SetActive(true);
        }
        else
        {
            _noMoney = true;
        }
    }

    private void TimerBonusCoin()
    {
        if(_timerBonusCoin > 0)
        {
            _timerBonusCoin -= 0.05f * Time.deltaTime;
        }
        else
        {
            _timerBonusCoin = 0f;
        }
    }

}
