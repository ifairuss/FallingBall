using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static float _volumeMusic = 0.01f;
    public bool IsMenu;

    private AudioSource _audioSource => GetComponent<AudioSource>();

    private void Awake()
    {
        _audioSource.volume = _volumeMusic;
    }

    private void Update()
    {
        if(_volumeMusic != 0)
        {
            if (IsMenu == true)
            {
                _audioSource.volume = _volumeMusic + 0.05f;
            }
            else
            {
                _audioSource.volume = _volumeMusic;
            }
        }
        else
        {
            _audioSource.volume = _volumeMusic;
        }
    }

    public void MusicOn()
    {

    }

    public void MusicOff()
    {

    }
}
