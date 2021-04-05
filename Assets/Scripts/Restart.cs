using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{

    public GameObject sahnedegisGO;
    public GameObject Soru;
    public Bina_Mesaj bina;

    public void yenidenbaslama()
    {
        Time.timeScale = 1f;
        sahnedegisGO.SetActive(true);
        Invoke("Gecikme",1.25f);
    }

    public void Gecikme(){
        SceneManager.LoadScene(2);
    }


    public void Cehennem()
    {
        Time.timeScale = 1f;
        sahnedegisGO.SetActive(true);
        Invoke("Gecikme2",1.25f);
    }

    public void Gecikme2(){
        SceneManager.LoadScene(4);
    }


    public void Hayir(){
        Soru.SetActive(false);
        bina.OyunuDondur = false;
    }
}
