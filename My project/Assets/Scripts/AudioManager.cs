using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager M_Instance { get; private set; }


    GameObject child_bgm;

    public AudioClip sfx_hit,sfx_clip_Perfect;

    private AudioSource audi;


     public bool sfx_o = true;
     public bool bgm_o = true;
    void Awake()
    {
        if (M_Instance == null)
        {
            M_Instance = this;
            DontDestroyOnLoad(gameObject);//I decided on dontdestroyonload , so i can have constant bgm throughout the scene
        }
        else
        {
            Destroy(gameObject);
        } 
    }
    void Start()
    {
        audi = GetComponent<AudioSource>();
        child_bgm = transform.Find("BGM").gameObject;
   
    }
    void Update()
    {

        if (sfx_o)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               //if there an audio going on it will stop and play the current one
                audi.Stop();

            
                audi.clip = sfx_hit;

                
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

    public void Perfect_Sound()
    {
        if(sfx_o)
        {
            audi.clip = sfx_clip_Perfect;


            audi.Play();
        }
    }


}
