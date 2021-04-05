using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer GovdeGO;
    public Sprite OnGovde, SagGovde, ArkaGovde;
    public float speed = 5f;

    Animator animator;

    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().WakeUp();
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle >= -135 && angle <= -45)
        {
            //on
            //KafaGO.sprite = OnKafa;
            GovdeGO.sprite = OnGovde;
        }
        if (angle >= -45 && angle <= 45)
        {
            //sag
            //KafaGO.sprite = SagKafa;
            GovdeGO.sprite = SagGovde;

            //KafaGO.flipX = false;
            GovdeGO.flipX = false;
        }
        if (angle >= 45 && angle <= 135)
        {
            //yukarı
            //KafaGO.sprite = ArkaKafa;
            GovdeGO.sprite = ArkaGovde;
        }
        if (angle >= 135 && angle <= 180)
        {
            //sol
            //KafaGO.sprite = SagKafa;
            GovdeGO.sprite = SagGovde;

            //KafaGO.flipX = true;
            GovdeGO.flipX = true;
        }
        if (Vector2.Distance(transform.position, target.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //animator.SetBool("Move", true);
        }
        else
        {
            //animator.SetBool("Move", false);
        }
    }
}
