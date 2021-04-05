using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uyu : MonoBehaviour
{

    public GameObject Mesaj;
    public Daktilo daktilo;
    public bool icerde = false;

    public bool uyudu = false;
    public GameObject UyuduGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && icerde == true && GunGec.gece == false){
            daktilo.fullText ="Sabah sabah uyuyamam,günü geçirmem lazım..";
            daktilo.delay = 0.05f;
            Mesaj.gameObject.GetComponent<Animator>().SetBool("MesajOpen",true);
        }
        if(Input.GetKeyDown(KeyCode.E) && icerde == true && GunGec.gece == true && uyudu == false){
            uyudu = true;
            UyuduGO.SetActive(true);
            Invoke("Uyuislem",1.25f);
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

    public void Uyuislem(){
        SceneManager.LoadScene(3);
    }
}
