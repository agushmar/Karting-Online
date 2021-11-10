using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruirAudio : MonoBehaviour
{
    bool autodestruir=false;
    public AudioSource audioS;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        Invoke("ActivarAutoDestruir",0.2f);
    }

    void ActivarAutoDestruir()
    {
        autodestruir = true;

    }
    void Update()
    {
        if (autodestruir)
        {
            if (!audioS.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
