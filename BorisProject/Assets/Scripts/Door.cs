using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Door_Obj;
    public Quaternion Start_Quaternion;
    public HingeJoint2D Door_HingeJoint2D;

    private void Start()
    {
        Start_Quaternion = Door_Obj.transform.rotation;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("Player Hit Door");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("Player Exit Door");
        }

    }
}