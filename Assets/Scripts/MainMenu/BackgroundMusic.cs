using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuClip; public AudioClip OdaClip; public AudioClip BinaClip; public AudioClip HellClip;
    public static string sahne;

    public bool sesAc = false;

    void Start()
    {
        sahne = "menu";
        audioSource.volume = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update() {
        if(sahne == "menu" && audioSource.volume != 1f){
            if(audioSource.clip != menuClip){
                audioSource.clip = menuClip;
            }
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
            audioSource.volume += Time.deltaTime;
        }
        /*
        if(audioSource.clip == menuClip && sahne == "oda"){
            audioSource.volume -= Time.deltaTime / 2;
        }

        if(sahne == "oda" && audioSource.volume == 0f){
            if(audioSource.clip != OdaClip){
                audioSource.clip = OdaClip;
            }
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
            audioSource.volume += Time.deltaTime / 2;
        }
        if(audioSource.clip == OdaClip && sahne == "bina"){
            audioSource.volume -= Time.deltaTime / 2;
        }
        */

        if(audioSource.clip == menuClip && sahne == "bina"){
            audioSource.volume -= Time.deltaTime;
        }
        if(sahne == "bina" && audioSource.volume == 0f){
            if(audioSource.clip != BinaClip){
                audioSource.clip = BinaClip;
            }
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
            sesAc = true;
        }
        if(sesAc && audioSource.volume != 1){
            audioSource.volume += Time.deltaTime;
        }else if(sesAc){
            sesAc = false;
        }

        if(audioSource.clip == BinaClip && sahne == "oda"){
            audioSource.volume -= Time.deltaTime;
        }
        if(sahne == "oda" && audioSource.volume == 0f){
            if(audioSource.clip != OdaClip){
                audioSource.clip = OdaClip;
            }
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
            sesAc = true;
        }

        if(audioSource.clip == BinaClip && sahne == "hell"){
            audioSource.volume -= Time.deltaTime;
        }
        if(sahne == "hell" && audioSource.volume == 0f){
            if(audioSource.clip != HellClip){
                audioSource.clip = HellClip;
            }
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
            sesAc = true;
        }

        if(audioSource.clip == HellClip && sahne == "oda"){
            audioSource.volume -= Time.deltaTime;
        }
    }

}
