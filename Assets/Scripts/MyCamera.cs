using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    Vector3 pos;
    public GameObject player;
    private void FixedUpdate()
    {
        pos = player.transform.position - gameObject.transform.position;
        pos.z = 0;
        gameObject.transform.position += pos / 20;
    }
}