using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] float timer;
    private void Start()
    {
        if (timer != 0)
        {
            Destroy(gameObject, timer);//If needed for future uses
        }
    }


    public void DestroyObj()
    {
        Destroy(gameObject);
    }

}
