using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{

    public GameObject isikGO;
    public UnityEngine.Experimental.Rendering.Universal.Light2D shapeLight;
    private void Start() {
        Invoke("Sil",1.5f);
    }
    private void Update() {
        shapeLight.intensity -= Time.deltaTime;
    }
    public void Sil(){
        Destroy(this.gameObject);
    }
}
