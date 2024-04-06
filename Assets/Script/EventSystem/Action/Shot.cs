using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject _bullet;

    [Header("Characteristics")]
    [SerializeField] private float _force;

    [Header("Timers")]
    [SerializeField] private float _timerReloadGun;
    [SerializeField] private float _timeReload = 1.2f;

    [Header("Text")]
    [SerializeField] private Text _reloadTimerText;

    [Header("Timer")]
    [SerializeField] private float _cooldownTimer = 25f;
    [SerializeField] private float _timerTime = 25f;

    public static bool ShootIsActive = true;

    private void Update()
    {
        BulletSpawnProces();
        Simplification();
    }

    private void BulletSpawnProces()
    {
        if(ShootIsActive == true)
        {
            if (_timerReloadGun <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var mousePos = Input.mousePosition;

                    var ray = Camera.main.ScreenPointToRay(mousePos);

                    var worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                    var bulletInstantiate = Instantiate(_bullet, worldPos, Quaternion.identity);

                    var bulletRB = bulletInstantiate.GetComponent<Rigidbody>();

                    if (bulletRB != null)
                    {
                        bulletRB.AddForce(ray.direction * _force);
                    }

                    _timerReloadGun = _timeReload;
                }
            }
            else
            {
                _timerReloadGun -= Time.deltaTime;
                _timerReloadGun = Mathf.Max(_timerReloadGun, 0f);
            }
        }

        _reloadTimerText.text = _timerReloadGun.ToString();
    }

    private void Simplification()
    {
        if (_timeReload > 0.2f)
        {
            if (_timerTime <= 0)
            {
                _timeReload -= 0.3f;
                _timerTime = _cooldownTimer;
            }
            else
            {
                _timerTime -= 1f * Time.deltaTime;
            }
        }
        else
        {
            _timeReload = 0.5f;
        }
    }

}
