using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer Player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        BackgroundMusic.sahne = "oda";
    }

    // Update is called once per frame
    void Update()
    {
        if(GunGec.yemeksecim == false && GunGec.dur == false){
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0.0f);

            transform.position = transform.position + movement * 4f * Time.deltaTime;
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){
                if(Input.GetKey(KeyCode.A)){
                    Player.flipX = true;
                }else{
                    Player.flipX = false;
                }
                animator.SetBool("Run",true);

            }else{
                animator.SetBool("Run",false);
            }
        }
    }
}

