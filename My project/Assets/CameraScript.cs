using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    int k = 0;
    float y_axis;

    private void Start()
    {
        y_axis = transform.position.y;
    }
    private void Update()
    {
        if (GameManager.Instance.Score > k)
        {
            k = GameManager.Instance.Score;//this is to check if theres difference in score 
            y_axis += 0.2f;

        }


        if (transform.position.y < y_axis)
        {
            CamUP();
        }
    }

    void CamUP()
    {

            transform.position = new Vector3(transform.position.x, transform.position.y + 1 * Time.deltaTime, transform.position.z);
        
        
    }
}
