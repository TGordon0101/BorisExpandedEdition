using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        for (int i = 0; i < m_lights.Length; i++)
    //        {
    //            m_lights[i].GetComponent<LightChange>().ToggleLightColor();
    //        }
    //    }
    //}

    public GameObject[] GetLights()
    {
        return m_lights;
    }
}
