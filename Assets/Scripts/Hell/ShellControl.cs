using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellControl : MonoBehaviour
{

    public float random;
    public bool sil = false;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(sil == false){
            sil = true;
            Invoke("Sil",random);
        }
    }
    public void Sil(){
        Destroy(this.gameObject.GetComponent<Rigidbody2D>());
    }
}
