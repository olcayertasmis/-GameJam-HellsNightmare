using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_Gun : MonoBehaviour
{
    public static float angle;
    public Transform aimTransform;
    public Transform BulletCount;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0,angle);

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90) {
            aimLocalScale.y = -1f;
            if(BulletCount.transform.localScale.x > 0){
                BulletCount.transform.localScale = new Vector3(BulletCount.transform.localScale.x * -1, BulletCount.transform.localScale.y, BulletCount.transform.localScale.z);
            }
        } else {
            aimLocalScale.y = +1f;
            if(BulletCount.transform.localScale.x < 0){
                BulletCount.transform.localScale = new Vector3(BulletCount.transform.localScale.x * -1, BulletCount.transform.localScale.y, BulletCount.transform.localScale.z);
            }
        }
        aimTransform.localScale = aimLocalScale;
    }
}
