using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirSonido : MonoBehaviour
{
    public AudioClip clip;
    public GameObject sonidoGenerico;
    AudioSource audioc;
    bool reproduciendo = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReproducirClip()
    {
        GameObject g = Instantiate(sonidoGenerico);
        audioc = g.GetComponent<AudioSource>();

        audioc.PlayOneShot(clip);
        reproduciendo = true;
        DontDestroyOnLoad(g);

    }


}