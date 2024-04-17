using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip[] _allClips;
    private AudioSource _audioSource => GetComponent<AudioSource>();


    public void PlaySFX(AudioClip clixSFX, bool destroy = false, float pinch = 1f ,float volume = 1f)
    {
        _audioSource.pitch = pinch;

        if (destroy) 
        {
            AudioSource.PlayClipAtPoint(clixSFX, transform.position, volume);
        }
        else
        {
            _audioSource.PlayOneShot(clixSFX, volume);
        }
    }
}
