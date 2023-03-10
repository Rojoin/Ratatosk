using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource musicSource, effectSource;
    [SerializeField] public AudioClip button;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
   
    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
    public void ToggleEffects()
    {
        effectSource.mute = !effectSource.mute;
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
}
