using UnityEngine;
using UnityEngine.UI;

public class MusicSetting : SFXManager
{
    [SerializeField] private Image _musicImage;
    [SerializeField] private Sprite[] _musicSprite;

    private int musicStatus;

    private void Awake()
    {
        musicStatus = PlayerPrefs.GetInt("MusicOn/Off");
        Music();
    }

    private void Update()
    {
        Music();
    }

    public void AudioSetting()
    {
        Sound();
        if (musicStatus != 0)
        {
            PlayerPrefs.SetInt("MusicOn/Off", 0);
        }
        else
        {
            PlayerPrefs.SetInt("MusicOn/Off", 1);
        }
    }

    private void Music()
    {
        if (musicStatus != 0)
        {
            _musicImage.sprite = _musicSprite[1];
            MusicManager._volumeMusic = 0f;
        }
        else
        {
            _musicImage.sprite = _musicSprite[0];
            MusicManager._volumeMusic = 0.01f;
        }

        musicStatus = PlayerPrefs.GetInt("MusicOn/Off");
    }

    private void Sound()
    {
        PlaySFX(_allClips[Random.Range(0, 3)], destroy: false, volume: 0.5f);
    }
}
