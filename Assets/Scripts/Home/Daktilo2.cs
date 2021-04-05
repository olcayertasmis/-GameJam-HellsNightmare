using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daktilo2 : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowText());

        if(fullText == "(+JUMP))" && GunGec.jump == 2){
            fullText = "(-))";
        }
        if(fullText == "(+GORUS))" && GunGec.gorus == 18){
            fullText = "(-))";
        }
        if(fullText == "(+HIZ))" && GunGec.hiz == 3){
            fullText = "(-))";
        }
    }

    IEnumerator ShowText(){
        for(int i = 0; i < fullText.Length; i++){
            currentText = fullText.Substring(0,i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
