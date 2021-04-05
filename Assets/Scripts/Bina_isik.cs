using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_isik : MonoBehaviour
{

    public UnityEngine.Experimental.Rendering.Universal.Light2D shapeLight;
    void Start()
    {
        shapeLight.pointLightOuterRadius = 12.5f + GunGec.gorus;
    }
}
