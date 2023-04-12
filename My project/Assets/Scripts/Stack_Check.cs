using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stack_Check : MonoBehaviour {
    
    [HideInInspector]
    public GameObject Cam;

    public
    GameObject LastObj;
    public
    GameObject CurrentObj;
    float level;

    float MaxDist = 2;
    bool MoveOpp;

    [SerializeField] GameObject Part_eff;

    public float Y_pos;

    public
    bool X_Z_Axis;//false = x movement , true is Z turn to move. 


    Renderer rend;
    private void Start()
    {
        Cam = GameObject.Find("TheCam");//Why i didn't place directly from editor is once i insantiate new obj the cam obj will be lost.
        CurrentObj = this.gameObject;
        if (!X_Z_Axis)
        {
            CurrentObj.transform.position = new Vector3(2, Y_pos, LastObj.transform.position.z);
        }
        else if (X_Z_Axis)
        {
            CurrentObj.transform.position = new Vector3(LastObj.transform.position.x, Y_pos, 2);
        }
        MoveOpp = true;


        rend = GetComponent<Renderer>();

        rend.material.color = Random.ColorHSV();//Change random color of the tile

    }

    private void Update()
    {
        MoveTile();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!X_Z_Axis)//Alternating for the func
            {
                XAxisFunction();
            }
            else if (X_Z_Axis)
            {
                ZAxisFunction();
            }
            //Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y + 0.2f, Cam.transform.position.z);//Increasing the position for the y axis

        }
    }
    void ZAxisFunction()
    {

        float distance;

        distance = transform.position.z - LastObj.transform.position.z;//Find the distance between the lastobj with the current.

        if (Mathf.Abs(distance) >= LastObj.transform.localScale.z)//Ahhh this is to find the absolute distance if its greater then object its being checked with.
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {


            float ZSize = LastObj.transform.localScale.z - Mathf.Abs(distance);//This is to find the excess and cutting it out!
            float ZPos = LastObj.transform.position.z + (distance / 2);//this is to find the middle point between 2 section , and the + is to push the position of where the origin was to what it needs to be.

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, ZSize);//applying both scale and postion
            transform.position = new Vector3(transform.position.x, transform.position.y, ZPos);

            if (Mathf.Abs(distance) <= 0.05f) {
                print("Nice!");
                GameObject clone = Instantiate(Part_eff, transform.position, transform.rotation);
                AudioManager.M_Instance.Perfect_Sound();
            }


            GameObject Clone = Instantiate(CurrentObj, CurrentObj.transform.position, CurrentObj.transform.rotation);//this is to make the object ontop after success of placing points

            Clone.GetComponent<Stack_Check>().Y_pos += 0.2f;//increase the hieght
            Clone.GetComponent<Stack_Check>().LastObj = CurrentObj;//setting the lastobj 


            if (!X_Z_Axis) Clone.GetComponent<Stack_Check>().X_Z_Axis = true;//This is just to alternate between the Z and X movement
            else if (X_Z_Axis) Clone.GetComponent<Stack_Check>().X_Z_Axis = false;

   
            GameManager.Instance.Addscore();
            Destroy(this);
        }
    }


    void XAxisFunction()
    {
        float distance;
        //most explanation is in the Z axis
        distance = transform.position.x - LastObj.transform.position.x;
        if (Mathf.Abs(distance) >= LastObj.transform.localScale.x)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            print(Mathf.Abs(distance));


            float XSize = LastObj.transform.localScale.x - Mathf.Abs(distance);
            float XPos = LastObj.transform.position.x + (distance / 2);

            transform.localScale = new Vector3(XSize, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(XPos, transform.position.y, transform.position.z);

            if (Mathf.Abs(distance) <= 0.05f)
            {
                print("Nice!");
                GameObject clone = Instantiate(Part_eff, transform.position, transform.rotation);
                AudioManager.M_Instance.Perfect_Sound();
            }

            GameObject Clone = Instantiate(CurrentObj, CurrentObj.transform.position, CurrentObj.transform.rotation);

            Clone.GetComponent<Stack_Check>().Y_pos += 0.2f;
            Clone.GetComponent<Stack_Check>().LastObj = CurrentObj;


     

            if (!X_Z_Axis) Clone.GetComponent<Stack_Check>().X_Z_Axis = true;
            else if (X_Z_Axis) Clone.GetComponent<Stack_Check>().X_Z_Axis = false;
            GameManager.Instance.Addscore();
            Destroy(this);
        }
    }



    void MoveTile()
    {
        //Moves in X Axis 
        if (!X_Z_Axis)
        {
            if (MoveOpp)
                CurrentObj.transform.Translate(-2f * Time.deltaTime, 0, 0);

            if (!MoveOpp)
                CurrentObj.transform.Translate(2f * Time.deltaTime, 0, 0);

            if (CurrentObj.transform.position.x >= MaxDist) MoveOpp = true;
            else if (CurrentObj.transform.position.x <= -MaxDist) MoveOpp = false;
        }
        else if (X_Z_Axis)//Moves in Z Axis
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
