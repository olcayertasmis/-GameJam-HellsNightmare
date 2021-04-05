using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina_Mesaj : MonoBehaviour
{

    public Animator animator;
    public static int gun = 0;

    public GameObject daktiloGO;
    public Daktilo daktilo;
    public string yazi;

    public GameObject Hile;

    public bool OyunuDondur = false;

    public bool ozel = false;

    public bool Hell = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!Hell){
            if(gun == 0){
                yazi = "Biktim artik hergun ayni ruyayi gormekten..";
                daktilo.fullText = yazi;

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 15;
            }
            if(gun == 1){
                yazi = "Her oldugumde aciyi iliklerime kadar hissediyorum....";
                daktilo.fullText = yazi;

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 15;
            }
            if(gun == 2){
                yazi = "Ruyada oldugumu biliyorum.Illegal yollara basvurmaliyim..";
                daktilo.fullText = yazi;

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 14;
            }
            if(gun == 3){
                yazi = "Birilerinin beni izledigini hissedebiliyorum..";
                daktilo.fullText = yazi;

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 14;
            }
            if(gun >= 4){
                yazi = "Orada oldugunu biliyorum.Bu kabusu yasamamak icin her turlu anlasmaya varim..";
                daktilo.fullText = yazi;

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 11;
                if(!ozel){
                    OyunuDondur = true;
                }
                Invoke("Gecikme",8f);
            }
            if(ozel){
                yazi = "Artık kabusuma bir son verebilirim..";
                daktilo.fullText = yazi;

                daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 15;
            }
            gun++;
            

            animator.SetBool("MesajOpen",true);
        }
        if(Hell){
            yazi = "Hemen iblise ulasmalıyım ve ondan yardim istemeliyim..";
            daktilo.fullText = yazi;

            daktiloGO.gameObject.GetComponent<TextMesh>().fontSize = 15;

            animator.SetBool("MesajOpen",true);
        }
    }

    public void Gecikme(){
        Hile.gameObject.SetActive(true);
        Cursor.visible = true;
    }
}
