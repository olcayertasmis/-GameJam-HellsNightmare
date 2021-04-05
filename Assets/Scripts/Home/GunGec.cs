using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGec : MonoBehaviour
{
    public Animator animator; public Animator gungecanimator;
    public GameObject YemekSec;

    public GameObject Mesaj;
    public Daktilo daktilo;

    public GameObject sabahGO;
    public GameObject geceGO;

    public static bool yemeksecim = false;
    public bool icerde = false;
    public static bool gece = false;

    public static float hiz;
    public static float gorus;
    public static int jump;

    public bool yemekYedi = false;

    public static bool dur = false;

    // Start is called before the first frame update
    void Start()
    {
        yemeksecim = false;
        gece = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(gece);
        if(Input.GetKeyDown(KeyCode.E) && icerde == true && gece == false){
            YemekSec.SetActive(true);
            yemeksecim = true;
            gungecanimator.SetBool("UyuOpen",false);

            Cursor.visible = true;
        }
        if(Input.GetKeyDown(KeyCode.E) && icerde == true && gece == true){
            daktilo.fullText ="Sokaga cikma yasagi var,artik çikamam..";
            daktilo.delay = 0.05f;
            Mesaj.gameObject.GetComponent<Animator>().SetBool("MesajOpen",true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            icerde = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            icerde = false;
        }
    }

    public void iskender(){
        if(yemekYedi == false){
            yemekYedi = true;

            animator.SetBool("Close",true);
            Invoke("GunBitir",2f);
            if(hiz != 3){
                hiz += 0.75f;
            }          
        }
    }
    public void lahmacun(){
        if(yemekYedi == false){
            yemekYedi = true;

            animator.SetBool("Close",true);
            Invoke("GunBitir",2f);
            if(gorus != 18){
                gorus += 3f;
            }          
        }
    }
    public void pizza(){
        if(yemekYedi == false){
            yemekYedi = true;

            animator.SetBool("Close",true);
            Invoke("GunBitir",2f);
            if(jump != 2){
                jump += 1;
            }
        }
    }

    public void GunBitir(){
        animator.SetBool("Close",false);
        gece = true;

        sabahGO.SetActive(false);
        geceGO.SetActive(true);

        yemeksecim = false;

        daktilo.fullText ="Çok yorucu bir gundu,dinlenmem gerek....";
        daktilo.delay = 0.05f;
        Mesaj.gameObject.GetComponent<Animator>().SetBool("MesajOpen",true);
    }
}
