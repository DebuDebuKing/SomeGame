using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    int Score;
    [SerializeField]
    Text ScoreText;
    public static GameManager Instance { get; private set; }

    void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
          
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ScoreText.GetComponent<Text>();
    }
    public void Addscore()
    {
        Score += 1;
        ScoreText.text = "Score: " + Score;
        if(PlayerPrefs.GetInt("SCORE") < Score)
        {
            PlayerPrefs.SetInt("SCORE", Score);
        }
    }


}
