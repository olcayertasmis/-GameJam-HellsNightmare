using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject Mesaj;
    public Daktilo daktilo;
    public GameObject daktiloGO;

    public bool Home = false;

    void Start()
    {
        if(Home){
            if(Bina_Mesaj.gun == 1){

            }
            if(Bina_Mesaj.gun == 2){
                daktilo.fullText ="Bu isi aci çekmeden cozmenin bir yolunu bulmalıyım..";
                daktilo.delay = 0.05f;
                Mesaj.gameObject.GetComponent<Animator>().SetBool("MesajOpen",true);

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 14;
            }
            if(Bina_Mesaj.gun == 3){
                daktilo.fullText ="Rüya yaratıcılarının haberi olmadan gizlice bir sey yapmam gerek..";
                daktilo.delay = 0.05f;
                Mesaj.gameObject.GetComponent<Animator>().SetBool("MesajOpen",true);

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 14;
            }
            if(Bina_Mesaj.gun == 4){
                daktilo.fullText ="Uyanmamalıyım ve bu kabusu bitirmeliyim..";
                daktilo.delay = 0.05f;
                Mesaj.gameObject.GetComponent<Animator>().SetBool("MesajOpen",true);

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 14;
            }
        }else{
            GunGec.dur = true;
            Invoke("Gecikme",3.5f);
        }
    }

    void Gecikme(){
        daktilo.fullText ="Çok yorucu bir gundu,dinlenmem gerek....";
        daktilo.delay = 0.05f;
        Mesaj.gameObject.GetComponent<Animator>().SetBool("MesajOpen",true);

        GunGec.gece = true;

        GunGec.dur = false;
    }

    private void Update() {
        if(GunGec.gece == false && !Home){
            GunGec.gece = true;
        }
    }
}
