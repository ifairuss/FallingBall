using UnityEngine;
using UnityEngine.UI;

public class QualitySetting : SFXManager
{
    [SerializeField] private Dropdown _dropdawnValue;

    private void Start()
    {

        int PerfomancSave = PlayerPrefs.GetInt("QualityIndex");

        _dropdawnValue.value = PerfomancSave;

        QualitySettings.SetQualityLevel(PerfomancSave);
    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);

        _dropdawnValue.value = qualityIndex;

        PlayerPrefs.SetInt("QualityIndex", qualityIndex);

        Sound();
    }

    private void Sound()
    {
        PlaySFX(_allClips[Random.Range(0, 3)], destroy: false, volume: 0.5f);
    }
}
