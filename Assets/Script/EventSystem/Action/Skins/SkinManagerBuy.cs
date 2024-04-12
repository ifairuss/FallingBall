using TMPro;
using UnityEngine;

public class SkinManagerBuy : MonoBehaviour
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
                PlayerPrefsCounter.MoneyEarned -= _price;
                _buttonBuy.SetActive(false);
                PlayerPrefs.SetInt($"{_nameSkinBuy}", 1);
            }
            else
            {
                Debug.Log("No money");
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
        PlayerPrefs.SetInt("SkinSelected", _skinID);
    }
}
