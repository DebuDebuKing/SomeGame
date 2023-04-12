using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu_Script : MonoBehaviour
{

    [SerializeField]
    GameObject Options;


    bool options = false;
    [SerializeField] GameObject sfx_marker;
    [SerializeField] GameObject bgm_marker;
   public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }


    private void Start()
    {
        if(AudioManager.M_Instance.bgm_o)
        {
            bgm_marker.SetActive(true);
        }
        else
        {
            bgm_marker.SetActive(false);
        }

        if (AudioManager.M_Instance.sfx_o)
        {
            sfx_marker.SetActive(true);
        }
        else
        {
            sfx_marker.SetActive(false);
        }

    }

    public void OptionsButtonEnabled()
    {
        if (!options)
        {
            options = true;
            Options.gameObject.SetActive(true);
        }
        else if (options)
        {
            options = false;
            Options.gameObject.SetActive(false);
        }
    }

    public void SFX()
    {
        if(AudioManager.M_Instance.sfx_o)
        {
     
            AudioManager.M_Instance.sfx_o = false;
            sfx_marker.SetActive(false);
        }
        else if (!AudioManager.M_Instance.sfx_o)
        {
       
            AudioManager.M_Instance.sfx_o = true;
            sfx_marker.SetActive(true);
        }
    }

    public void BGM()
    {
        if (AudioManager.M_Instance.bgm_o)
        {
            AudioManager.M_Instance.bgm_o = false;
            bgm_marker.SetActive(false);
        }
        else if (!AudioManager.M_Instance.bgm_o)
        {
       
            AudioManager.M_Instance.bgm_o = true;
            bgm_marker.SetActive(true);
        }
    }

}
