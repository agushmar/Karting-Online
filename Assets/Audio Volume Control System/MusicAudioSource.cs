using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicAudioSource : MonoBehaviour
{
    AudioSource audioSource;
    Agus.ValoresAudio audioSettings;

    void Start()
    {
        audioSettings = Agus.ValoresAudio.audioSettings;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSettings.GetMusicVolume();
        audioSettings.AddMeToMusicAudioSources(audioSource);
    }

    void OnDestroy()
    {
        audioSettings.RemoveMeFromMusicAudioSources(audioSource);
    }
}
