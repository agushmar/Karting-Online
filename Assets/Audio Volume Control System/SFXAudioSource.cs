using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXAudioSource : MonoBehaviour
{
    AudioSource audioSource;
    Agus.ValoresAudio audioSettings;

    void Start()
    {
        audioSettings = Agus.ValoresAudio.audioSettings;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSettings.GetSFXVolume();
        audioSettings.AddMeToSFXAudioSources(audioSource);
    }

    void OnDestroy()
    {
        audioSettings.RemoveMeFromSFXAudioSources(audioSource);
    }
}
