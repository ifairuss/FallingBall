using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _countTextScore;
    [SerializeField] private TextMeshProUGUI _countTextHealth;
    [SerializeField] private TextMeshProUGUI _countTextMoney;

    public int CounterScore;
    public int CoutnerMoney;
    public int CounterHealth;

    private void Awake()
    {
        PlayerPrefs.GetInt("MainGameScore", 0);
        PlayerPrefs.GetInt("MainGameMoney", 0);
    }

    private void Update()
    {
        TextDisplay();

        CoutnerMoney = Mathf.Max(CoutnerMoney, 0);
        CounterHealth = Mathf.Max(CounterHealth, 0);
    }

    private void TextDisplay()
    {
        _countTextScore.text = CounterScore.ToString();
        _countTextHealth.text = CounterHealth.ToString();
        _countTextMoney.text = CoutnerMoney.ToString();
    }
}
