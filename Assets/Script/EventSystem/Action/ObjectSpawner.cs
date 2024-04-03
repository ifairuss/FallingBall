using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject[] _allVariableSpawn;
    [SerializeField] private GameObject _spawnPosition;

    [Header("SettingSpawn")]
    [SerializeField] private float _delaySpawn;
    public float Delay = 3.5f;

    [Header("Timer")]
    [SerializeField] private float _cooldownTimer = 15f;
    [SerializeField] private float _timerTime = 15f;


    private void Update()
    {
        var spawnValue = Random.Range(0, _allVariableSpawn.Length);

        ComplicationOfSpawner();

        if (_delaySpawn <= 0f)
        {
            _spawnPosition = _allVariableSpawn[spawnValue];

            Instantiate(_spawnPosition, _spawnPosition.transform.position, Quaternion.identity);

            _delaySpawn = Delay;
        }
        else
        {
            _delaySpawn -= 1f * Time.deltaTime;
        }
    }

    private void ComplicationOfSpawner()
    {
        if (Delay > 0.8f)
        {
            if (_timerTime <= 0)
            {
                Delay -= 0.5f;
                _timerTime = _cooldownTimer;
            }
            else
            {
                _timerTime -= 1f * Time.deltaTime;
            }
        }
        else
        {
            Delay = Mathf.Max(Delay, 0.8f);
        }
    }
}
