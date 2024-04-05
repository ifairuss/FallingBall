using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _countTextScore;
    [SerializeField] private TextMeshProUGUI _countTextHealth;
    [SerializeField] private TextMeshProUGUI _countTextMoney;

    public static int CounterScore = 0;
    public static int CounterMoney = 0;
    public static int CounterHealth = 1;

    [Header("Characteristics")]
    [SerializeField] private int _maxHealth;

    private void Awake()
    {
        PlayerPrefs.GetInt("MainGameScore", 0);
        PlayerPrefs.GetInt("MainGameMoney", 0);

        CounterScore = 0;
        CounterMoney = 0;

        CounterHealth = _maxHealth;
    }

    private void Update()
    {
        TextDisplay();

        CounterMoney = Mathf.Max(CounterMoney, 0);
        CounterHealth = Mathf.Max(CounterHealth, 0);
    }

    private void TextDisplay()
    {
        _countTextScore.text = CounterScore.ToString();
        _countTextHealth.text = CounterHealth.ToString();
        _countTextMoney.text = CounterMoney.ToString();
    }
}
