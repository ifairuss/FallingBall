using UnityEngine;
using UnityEngine.UIElements;

public class SFXManager : MonoBehaviour
{
    public AudioClip[] _allClips;
    private AudioSource _audioSource => GetComponent<AudioSource>();

    private Vector3 _transform = new Vector3(0, -5, -21);

    private void Start()
    {
        _audioSource.transform.position = _transform;
    }


    public void PlaySFX(AudioClip clixSFX, bool destroy = false, float pinch = 0.7f, float pinchTwo = 1.5f ,float volume = 1f)
    {
        _audioSource.pitch = Random.Range(pinch, pinchTwo);

        if (destroy) 
        {
            AudioSource.PlayClipAtPoint(clixSFX, _transform, volume);
        }
        else
        {
            _audioSource.PlayOneShot(clixSFX, volume);
        }
    }
}
