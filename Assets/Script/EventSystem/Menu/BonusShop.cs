using TMPro;
using UnityEngine;

public class BonusShop : SFXManager
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
        _productCondition = PlayerPrefs.GetInt($"{_product}");
        DisplayText();
    }

    public void ClickButtonBuy()
    {
        if (PlayerPrefsCounter.MoneyEarned >= _price && _productCondition != 1)
        {
            PlaySFX(_allClips[0], pinch: 1.1f, volume: 0.8f);
            PlayerPrefsCounter.MoneyEarned -= _price;
            PlayerPrefs.SetInt("MoneyEarnedSave", PlayerPrefsCounter.MoneyEarned);
            PlayerPrefs.SetInt($"{_product}", 1);
            _conditionGoods = "Purchased";
        }
        else
        {
            PlaySFX(_allClips[1], pinch: 0.8f, volume: 0.6f);
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
