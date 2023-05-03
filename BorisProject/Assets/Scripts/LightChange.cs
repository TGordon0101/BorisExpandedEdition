using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightChange : MonoBehaviour
{
    [SerializeField] private Light2D m_sepiaLight;
    [SerializeField] private Light2D m_blueLight;

    // Start is called before the first frame update
    void Start()
    {
        m_blueLight.enabled = false;
    }

    //Change from Sepia to Blue
    public void ToggleLightColor()
    {
        if (m_sepiaLight.enabled)
        {
            m_sepiaLight.enabled = false;
            m_blueLight.enabled = true;
        }
        else
        {
            m_sepiaLight.enabled = true;
            m_blueLight.enabled = false;
        }
    }
}
