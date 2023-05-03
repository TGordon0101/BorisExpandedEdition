using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILocation : MonoBehaviour
{
    public Transform[] Location;
    public Transform ReturnLocation;

    void Start()
    {
        Location = new Transform[9];

        for(int x = 0; x < Location.Length; x++)
        {
            Location[x] = gameObject.GetComponent<Transform>().Find("Location " + x);
        }
    }

    public Transform GetLocation()
    {
        ReturnLocation = Location[Random.Range(0, Location.Length)];

        return ReturnLocation;
    }
}
