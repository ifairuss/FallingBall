using TMPro;
using UnityEngine;

public class SkinManagerBuy : SFXManager
{
    [Header("Stats")]
    [SerializeField] private int _price;
    [SerializeField] private string _nameSkinBuy;
    [SerializeField] private int _skinID;

    [Header("Button")]
    [SerializeField] private GameObject _buttonBuy;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _buttontTextDisplay;
    [SerializeField] private TextMeshProUGUI _priceTextDisplay;

    private string _selectText = "Select";
    private string _selectedText = "Selected";

    private void Update()
    {
        SkinCheck();
        SkinCheckSelected();
    }

    public void SkinBuy()
    {
        int _skinPurchased = PlayerPrefs.GetInt($"{_nameSkinBuy}");

        if (_skinPurchased != 1)
        {
            _buttonBuy.SetActive(true);

            if (PlayerPrefsCounter.MoneyEarned >= _price)
            {
                PlaySFX(_allClips[0], pinch: 1.1f, volume: 0.8f);
                PlayerPrefsCounter.MoneyEarned -= _price;
                PlayerPrefs.SetInt("MoneyEarnedSave", PlayerPrefsCounter.MoneyEarned);
                _buttonBuy.SetActive(false);
                PlayerPrefs.SetInt($"{_nameSkinBuy}", 1);
            }
            else
            {
                PlaySFX(_allClips[2], pinch: 0.8f, volume: 0.6f);
            }
        }
        else 
        {
            Debug.Log("Error");
        }
    }

    private void SkinCheck()
    {
         int _skinPurchased = PlayerPrefs.GetInt($"{_nameSkinBuy}");

        if(_price == 0)
        {
            _skinPurchased = 1;
        }

        if(_skinPurchased != 1)
        {
            _buttonBuy.SetActive(true);
        }
        else
        {
            _buttonBuy.SetActive(false);
        }

        _priceTextDisplay.text = _price.ToString();
    }

    private void SkinCheckSelected()
    {
        int _skinSelected = PlayerPrefs.GetInt("SkinSelected");

        if(_skinSelected != _skinID)
        {
            _buttontTextDisplay.text = _selectText;
            _buttontTextDisplay.color = new Color(0, 255, 0, 1);
        }
        else
        {
            _buttontTextDisplay.text = _selectedText;
            _buttontTextDisplay.color = new Color(255, 0, 0, 1);
        }
    }

    public void SkinSelect()
    {
        PlaySFX(_allClips[1], pinch: 0.8f, volume: 0.6f);
        PlayerPrefs.SetInt("SkinSelected", _skinID);
    }
}
