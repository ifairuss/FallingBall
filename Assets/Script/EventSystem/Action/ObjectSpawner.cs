using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject[] _allSpawnPosition;
    [SerializeField] private GameObject[] _allBall;
    [SerializeField] private GameObject _spawnPosition;
    [SerializeField] private GameObject _ball;

    [Header("SettingSpawn")]
    [SerializeField] private float _delaySpawn;
    public float Delay = 3.5f;

    [Header("Timer")]
    [SerializeField] private float _cooldownTimer = 15f;
    [SerializeField] private float _timerTime = 15f;


    private void Update()
    {
        var spawnValue = Random.Range(0, _allSpawnPosition.Length);
        var ballValue = Random.Range(0, _allBall.Length);

        ComplicationOfSpawner();

        if (_delaySpawn <= 0f)
        {
            _ball = _allBall[ballValue];
            _spawnPosition = _allSpawnPosition[spawnValue];

            Instantiate(_ball, _spawnPosition.transform.position, Quaternion.identity);

            _delaySpawn = Delay;
        }
        else
        {
            _delaySpawn -= 1f * Time.deltaTime;
        }
    }

    private void ComplicationOfSpawner()
    {
        if (Delay > 1f)
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
            Delay = Mathf.Max(Delay, 1f);
        }
    }
}
