using TMPro;
using UnityEngine;

public class PlayerPrefsCounter : MonoBehaviour
{
    [SerializeField] private int _bestScore;
    [SerializeField] private int _moneyEarned;

    [SerializeField] private TextMeshProUGUI _bestScoreDisplayText;
    [SerializeField] private TextMeshProUGUI _moneyEarnedDisplayText;

    private void Awake()
    {     
        PlayerPrefsSave();
    }

    private void Update()
    {
        DisplayText();
    }

    public void PlayerPrefsSave()
    {
        int scoreSave = PlayerPrefs.GetInt("MainGameScore");
        int moneySave = PlayerPrefs.GetInt("MainGameMoney");
        _bestScore = PlayerPrefs.GetInt("BestScoreSave");
        _moneyEarned = PlayerPrefs.GetInt("MoneyEarnedSave");

        if (_bestScore < scoreSave)
        {
            _bestScore = scoreSave;

            PlayerPrefs.SetInt("BestScoreSave", _bestScore);
            PlayerPrefs.SetInt("MainGameScore", 0);
        }

        if (moneySave != 0)
        {
            _moneyEarned += moneySave;

            PlayerPrefs.SetInt("MoneyEarnedSave", _moneyEarned);
            PlayerPrefs.SetInt("MainGameMoney", 0);
        }
    }

    private void DisplayText()
    {
        _bestScoreDisplayText.text = _bestScore.ToString();
        _moneyEarnedDisplayText.text = _moneyEarned.ToString();
    }
}
