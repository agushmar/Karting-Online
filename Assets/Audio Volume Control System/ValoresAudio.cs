using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

using KartGame.KartSystems;

namespace Agus
{
    public class ValoresAudio : MonoBehaviour
    {
        public static ValoresAudio audioSettings;

        [Header("Information - Read Only from inspector")]
        [SerializeField]
        private float musicVolume;
        [SerializeField]
        private float sfxVolume;

        float musicDefaultVolume = 0.7f;
        float sfxDefaultVolume = 0.9f;

        string musicAudioSourcesTag = "Music-AudioSource";
        string sfxAudioSourcesTag = "SFX-AudioSource";

        string musicVolumeDataName = "music-volume";
        string sfxVolumeDataName = "sfx-volume";

        List<AudioSource> musicAudioSources;
        List<AudioSource> sfxAudioSources;
        
        [SerializeField]
        private int musicAudioSourcesCount = 0;
        [SerializeField]
        private int sfxAudioSourcesCount = 0;

        public bool chequearPlayer = false;
        public bool sonidosKartingConfigurados = false;

        public AudioMixerGroup mixerChoque;

        public AudioSource countdown;

        private void Awake()
        {
            audioSettings = this;
            musicAudioSources = new List<AudioSource>();
            sfxAudioSources = new List<AudioSource>();
            LoadSavedSettings();
            Invoke("AjustarVolumenes", 0.05f);
            Invoke("ActivarChequeo", 0.05f);
            countdown.volume = musicVolume;
            chequearPlayer = false;
            sonidosKartingConfigurados = false;
        }
        void ActivarChequeo()
        {
            chequearPlayer = true;

        }
        void AjustarVolumenes()
        {
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            GameFlowManager gameFlow = FindObjectOfType<GameFlowManager>();
            gameFlow.volumenGeneral = musicVolume;

            foreach (AudioSource a in audios)
            {
                a.volume = musicVolume;
            }

        }

        void Update()
        {
            if (chequearPlayer)
            {
                if (!sonidosKartingConfigurados)
                {
                    ArcadeEngineAudio[] audiosKarting = FindObjectsOfType<ArcadeEngineAudio>();
                    if (audiosKarting != null)
                    {
                        KartBounce bounce = FindObjectOfType<KartBounce>();
                        bounce.volumenGeneral = musicVolume;
                        sonidosKartingConfigurados = true;
                        foreach (ArcadeEngineAudio a in audiosKarting)
                        {
                            a.AjustarVolumen(musicVolume);
                        }
                    }
                }
            }

        }

        void LoadSavedSettings()
        {
            musicVolume = PlayerPrefs.GetFloat(musicVolumeDataName, musicDefaultVolume);
            sfxVolume = PlayerPrefs.GetFloat(sfxVolumeDataName, sfxDefaultVolume);

        }



        public void ChangeMusicVolume(float newVolume)
        {
            musicVolume = newVolume;
            PlayerPrefs.SetFloat(musicVolumeDataName, musicVolume);
            SetVolumeToAudioSources(musicAudioSources, musicVolume);
        }


        public void ChangSFXVolume(float newVolume)
        {
            sfxVolume = newVolume;
            PlayerPrefs.SetFloat(sfxVolumeDataName, sfxVolume);
            SetVolumeToAudioSources(sfxAudioSources, sfxVolume);
        }

        void SetVolumeToAudioSources(List<AudioSource> audioSources, float volume)
        {
            foreach (AudioSource a in audioSources)
            {
                a.volume = volume;
            }
        }


        public float GetMusicVolume()
        {
            return musicVolume;
        }
        public float GetSFXVolume()
        {
            return sfxVolume;
        }

        public void AddMeToMusicAudioSources(AudioSource a)
        {
            musicAudioSources.Add(a);
            musicAudioSourcesCount = musicAudioSources.Count;
        }

        public void RemoveMeFromMusicAudioSources(AudioSource a)
        {
            musicAudioSources.Remove(a);
            musicAudioSourcesCount = musicAudioSources.Count;
        }
        public void AddMeToSFXAudioSources(AudioSource a)
        {
            sfxAudioSources.Add(a);
            sfxAudioSourcesCount = sfxAudioSources.Count;
        }

        public void RemoveMeFromSFXAudioSources(AudioSource a)
        {
            sfxAudioSources.Remove(a);
            sfxAudioSourcesCount = sfxAudioSources.Count;
        }


    }
}
