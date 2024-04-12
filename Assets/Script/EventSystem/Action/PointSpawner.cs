using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [Header("Bonus")]
    [SerializeField] private List<GameObject> _allObject = new List<GameObject>();
    [SerializeField] private List<GameObject> _bonusObject = new List<GameObject>();

    private GameObject _ball;

    [SerializeField, Header("StateBonus")]
    private int _bonusFallingHeart;
    private int _bonusFallingBomb;
    private int _bonusFallingMagnificationScore;
    private int _bonusFallingClock;

    private void Start()
    {
        ActiveBonus();
        AddBonusForList();

        var ballValue = Random.Range(0, _allObject.Count);

        _ball = _allObject[ballValue];

        Instantiate(_ball, this.transform.position, Quaternion.Euler(-15, 0, 0));
    }

    public void ActiveBonus()
    {
        _bonusFallingHeart = PlayerPrefs.GetInt("BonusHeart");
        _bonusFallingBomb = PlayerPrefs.GetInt("BonusBomb");
        _bonusFallingMagnificationScore = PlayerPrefs.GetInt("BonusMagnificationScore");
        _bonusFallingClock = PlayerPrefs.GetInt("BonusClock");
    }

    private void AddBonusForList()
    {
        if(_bonusFallingHeart == 1)
        {
            GameObject _heart = _bonusObject[0];

            _allObject.Add(_heart);
        }
        if(_bonusFallingBomb == 1)
        {
            GameObject _bomb = _bonusObject[1];

            _allObject.Add(_bomb);
        }
        if(_bonusFallingMagnificationScore == 1)
        {
            GameObject _magnifaction = _bonusObject[2];

            _allObject.Add(_magnifaction);
        }
        if (_bonusFallingClock == 1)
        {
            GameObject _clock = _bonusObject[3];

            _allObject.Add(_clock);
        }
    }
}
