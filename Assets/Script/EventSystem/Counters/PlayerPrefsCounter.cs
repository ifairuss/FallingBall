using GooglePlayGames;
using TMPro;
using UnityEngine;

public class PlayerPrefsCounter : MonoBehaviour
{
    [SerializeField] private int _bestScore;
     
    public static int MoneyEarned;

    [SerializeField] private TextMeshProUGUI _bestScoreDisplayText;
    [SerializeField] private TextMeshProUGUI _moneyEarnedDisplayText;
    [SerializeField] private TextMeshProUGUI _moneyBonusDisplayText;
    [SerializeField] private TextMeshProUGUI _moneySkinsDisplayText;

    private void Start()
    {
        PlayerPrefsSave();
    }

    private void Update()
    {
        DisplayText();
    }

    public void PlayerPrefsSave()
    {
        int scoreSave = PlayerPrefs.GetInt("ScoreSave");
        int moneySave = PlayerPrefs.GetInt("MoneySave");
        _bestScore = PlayerPrefs.GetInt("BestScoreSave");
        MoneyEarned = PlayerPrefs.GetInt("MoneyEarnedSave");

        if (_bestScore < scoreSave)
        {
            _bestScore = scoreSave;

            Social.ReportScore(_bestScore, GPGSIds.leaderboard_fallingball, (bool success) => {
                Debug.Log($"Leaderboard score = {_bestScore}");
            });

            PlayGamesLeaderboard.ReferenceEquals(_bestScore, GPGSIds.leaderboard_fallingball);

            PlayerPrefs.SetInt("BestScoreSave", _bestScore);
            PlayerPrefs.SetInt("ScoreSave", 0);
        }

        if (moneySave != 0)
        {
            MoneyEarned += moneySave;

            PlayerPrefs.SetInt("MoneyEarnedSave", MoneyEarned);
            PlayerPrefs.SetInt("MoneySave", 0);
        }
    }

    private void DisplayText()
    {
        _bestScoreDisplayText.text = _bestScore.ToString();
        _moneyEarnedDisplayText.text = MoneyEarned.ToString();
        _moneyBonusDisplayText.text = MoneyEarned.ToString();
        _moneySkinsDisplayText.text = MoneyEarned.ToString();

        if(MoneyEarned < 0)
        {
            MoneyEarned = Mathf.Max(MoneyEarned, 0);
        }
    }
}
