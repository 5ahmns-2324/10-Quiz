using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clickSounds;
    [SerializeField] AudioSource sfxSource;
    public void PlayClick()
    {
        sfxSource = gameObject.GetComponent<AudioSource>();
        sfxSource.clip = clickSounds[Random.Range(0, 2)];
        sfxSource.Play();
    }
}