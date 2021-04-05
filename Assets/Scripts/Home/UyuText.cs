using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UyuText : MonoBehaviour
{

    public Animator animator;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            animator.SetBool("UyuOpen",true);
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            animator.SetBool("UyuOpen",false);
        }
    }
}
