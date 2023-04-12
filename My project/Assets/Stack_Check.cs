using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stack_Check : MonoBehaviour
{   [HideInInspector]
    public GameObject Cam;

    public
    GameObject LastObj;
    public
    GameObject CurrentObj;
    float level;

    float MaxDist = 2;
    bool MoveOpp;
    [SerializeField] GameObject Self;

    public float Y_pos;

    public
    bool X_Z_Axis;//false = x movement , true is Z turn to move. 


    Renderer rend;
    private void Start()
    {
        Cam = GameObject.Find("TheCam");
        CurrentObj = this.gameObject;
        if (!X_Z_Axis)
        {
            CurrentObj.transform.position = new Vector3(2, Y_pos, LastObj.transform.position.z);
        }
        else if(X_Z_Axis)
        {
            CurrentObj.transform.position = new Vector3(LastObj.transform.position.x, Y_pos, 2);
        }
        MoveOpp = true;
        Self = this.gameObject;

        rend = GetComponent<Renderer>();

        rend.material.color = Random.ColorHSV();

    }

    private void Update()
    {
      

        MoveTile();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CurrentObj.transform.Translate(0, 0, 0);


            if(!X_Z_Axis)
            {
                XAxisFunction();
            }
           else if(X_Z_Axis)
            {
                ZAxisFunction();
            }

            GameManager.Instance.Addscore();
         
        }
    }


    void XAxisFunction()
    {
        float distance;

        distance = transform.position.x - LastObj.transform.position.x;
        if (Mathf.Abs(distance) >= LastObj.transform.localScale.x)
        {
            SceneManager.LoadScene("MainMenu");
        }
        print(Mathf.Abs(distance));


        float XSize = LastObj.transform.localScale.x - Mathf.Abs(distance);
        float XPos = LastObj.transform.position.x + (distance / 2);

        transform.localScale = new Vector3(XSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(XPos, transform.position.y, transform.position.z);

        GameObject Clone = Instantiate(Self, CurrentObj.transform.position, CurrentObj.transform.rotation);

        Clone.GetComponent<Stack_Check>().Y_pos += 0.2f;
        Clone.GetComponent<Stack_Check>().LastObj = CurrentObj;

        Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y + 0.2f, Cam.transform.position.z);
        print(Y_pos);

        if (!X_Z_Axis) Clone.GetComponent<Stack_Check>().X_Z_Axis = true;
        else if (X_Z_Axis) Clone.GetComponent<Stack_Check>().X_Z_Axis = false;
       
        Destroy(this);
    }
    void ZAxisFunction()
    {

        float distance;

        distance = transform.position.z - LastObj.transform.position.z;
        if (Mathf.Abs(distance) >= LastObj.transform.localScale.z)
        {
            SceneManager.LoadScene("MainMenu");
        }



        float ZSize = LastObj.transform.localScale.z - Mathf.Abs(distance);
        float ZPos = LastObj.transform.position.z + (distance / 2);

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y,ZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, ZPos);

        GameObject Clone = Instantiate(Self, CurrentObj.transform.position, CurrentObj.transform.rotation);

        Clone.GetComponent<Stack_Check>().Y_pos += 0.2f;
        Clone.GetComponent<Stack_Check>().LastObj = CurrentObj;


        if (!X_Z_Axis) Clone.GetComponent<Stack_Check>().X_Z_Axis = true;
        else if (X_Z_Axis) Clone.GetComponent<Stack_Check>().X_Z_Axis = false;

        Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y + 0.2f, Cam.transform.position.z);
        print(Y_pos);
        Destroy(this);
    }



    void MoveTile()
    {
        if (!X_Z_Axis)
        {
            if (MoveOpp)
                CurrentObj.transform.Translate(-2f * Time.deltaTime, 0, 0);

            if (!MoveOpp)
                CurrentObj.transform.Translate(2f * Time.deltaTime, 0, 0);

            if (CurrentObj.transform.position.x >= MaxDist) MoveOpp = true;
            else if (CurrentObj.transform.position.x <= -MaxDist) MoveOpp = false;
        }
        else if(X_Z_Axis)
        {
            if (MoveOpp)
                CurrentObj.transform.Translate(0, 0, -2f * Time.deltaTime);

            if (!MoveOpp)
                CurrentObj.transform.Translate(0, 0, 2f * Time.deltaTime);

            if (CurrentObj.transform.position.z >= MaxDist) MoveOpp = true;
            else if (CurrentObj.transform.position.z <= -MaxDist) MoveOpp = false;
        }
    }

}
