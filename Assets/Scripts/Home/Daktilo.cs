using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daktilo : MonoBehaviour
{
    public GameObject mesaj;
    public AudioSource audioSource; public AudioClip konusma;
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    public bool bitti = false;
    public bool bitti2 = false;

    private void OnEnable() {
        StartCoroutine(ShowText());
        bitti = false;

        audioSource.clip = konusma;
        audioSource.Play();
    }
    private void Update() {
        if(bitti == true){
            mesaj.GetComponent<Animator>().SetBool("MesajOpen",false);
            bitti = false;
        }
        print(bitti);
    }
    IEnumerator ShowText(){
        for(int i = 0; i < fullText.Length; i++){
            currentText = fullText.Substring(0,i);
            this.GetComponent<TextMesh>().text = currentText;
            if(i == fullText.Length -1){
                Invoke("Bitti",1f);
                bitti2 = true;
            }
            yield return new WaitForSeconds(delay);
        }
    }
    public void Bitti(){
        bitti = true;
    }
}
