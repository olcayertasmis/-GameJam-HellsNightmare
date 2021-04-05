using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kus : MonoBehaviour
{
    public Animator anim;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("if");
            anim.SetBool("kus", true);
        }
    }
}
