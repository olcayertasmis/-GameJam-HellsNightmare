using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oyna : MonoBehaviour
{
    public GameObject sahnedegisGO;
    public void OynaButon(){
        sahnedegisGO.SetActive(true);
        Invoke("Gecikme",1.25f);
    }
    public void Gecikme(){
        SceneManager.LoadScene(1);
    }
}
