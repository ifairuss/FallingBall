using TMPro;
using UnityEngine;

public class BonusShop : MonoBehaviour
{
    [Header("Setting goods")]
    [SerializeField] private string _product;
    [SerializeField] private int _price;

    private string _conditionGoods;
    private int _productCondition;

    [SerializeField, Header("DisplayText")]
    private TextMeshProUGUI _priceText;

    private void Start()
    {
        _conditionGoods = _price.ToString();
        _productCondition = PlayerPrefs.GetInt($"{_product}");
    }

    private void Update()
    {
        DisplayText();
    }

    public void ClickButtonBuy()
    {
        if (PlayerPrefsCounter.MoneyEarned >= _price && _productCondition != 1)
        {
            PlayerPrefsCounter.MoneyEarned -= _price;
            PlayerPrefs.SetInt("MoneyEarnedSave", PlayerPrefsCounter.MoneyEarned);
            PlayerPrefs.SetInt($"{_product}", 1);
            _conditionGoods = "Purchased";
        }
    }

    private void DisplayText()
    { 
        _priceText.text = _conditionGoods;

        if(_productCondition == 1)
        {
            _conditionGoods = "Purchased";
        }
    }

}
