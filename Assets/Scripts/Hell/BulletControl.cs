using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Hell_Enemy>().Damage(10);
            Destroy(this.gameObject);
        }
    }
}
