using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager M_Instance { get; private set; }


    GameObject child_bgm;

    public AudioClip sfxClip;

    private AudioSource audi;


     public bool sfx_o = true;
     public bool bgm_o = true;
    void Awake()
    {
        if (M_Instance == null)
        {
            M_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

       
    }

    void Start()
    {
        // Get a reference to the AudioSource on this GameObject
        audi = GetComponent<AudioSource>();
        child_bgm = transform.Find("BGM").gameObject;
   
    }

    void Update()
    {
        // Check for input to play the sound effect
        if (sfx_o)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Stop the current clip, if playing
                audi.Stop();

                // Set the new clip
                audi.clip = sfxClip;

                // Play the sound effect
                audi.Play();
            }
        }

        if(bgm_o)
        {
            child_bgm.SetActive(true);
        }
        else if(!bgm_o)
        {
            child_bgm.SetActive(false);
        }
    }


}
