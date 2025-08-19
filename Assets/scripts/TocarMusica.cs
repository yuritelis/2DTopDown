using UnityEngine;
using UnityEngine.Audio;

public class TocarMusica : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip musicaMenu;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
    }

    void Update()
    {
        
    }
}
