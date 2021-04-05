using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform target;
    public float speed;

    public SpriteRenderer KafaGO; public SpriteRenderer GovdeGO; public SpriteRenderer Ayak1; public SpriteRenderer Ayak2;
    public Sprite OnKafa; public Sprite OnGovde;
    public Sprite SagKafa; public Sprite SagGovde;
    public Sprite ArkaKafa; public Sprite ArkaGovde;

    public GameObject BloodPrefab; public GameObject SoulPrefab;

    public int Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().WakeUp();
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        if(angle >= -135 && angle <= -45){
            //on
            //KafaGO.sprite = OnKafa;
            GovdeGO.sprite = OnGovde;
        }
        if(angle >= -45 && angle <= 45){
            //sag
            //KafaGO.sprite = SagKafa;
            GovdeGO.sprite = SagGovde;

            //KafaGO.flipX = false;
            GovdeGO.flipX = false;
        }
        if(angle >= 45 && angle <= 135){
            //yukarı
            //KafaGO.sprite = ArkaKafa;
            GovdeGO.sprite = ArkaGovde;
        }
        if(angle >= 135 && angle <= 180){
            //sol
            //KafaGO.sprite = SagKafa;
            GovdeGO.sprite = SagGovde;

            //KafaGO.flipX = true;
            GovdeGO.flipX = true;
        }
        if(Vector2.Distance(transform.position,target.position) > 1){
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
            animator.SetBool("Move",true);
        }else{
            animator.SetBool("Move",false);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Hell_Player2>().GetDamage(1);
        }
    }

    public void Damage(int dmg){
        KafaGO.color = Color.red;
        GovdeGO.color = Color.magenta;
        Ayak1.color = Color.red;
        Ayak2.color = Color.red;

        Health -= dmg;
        if(Health <= 0){
            //GameObject blood = Instantiate(BloodPrefab,this.transform.position,this.transform.rotation);
            GameObject soul = Instantiate(SoulPrefab,this.transform.position,this.transform.rotation);
            Hell_EnemySpawner.enemyCount--;
            Destroy(this.gameObject);
        }

        speed = speed / 3;

        Invoke("Sifirla",0.25f);
    }

    public void Sifirla(){
        KafaGO.color = Color.white;
        GovdeGO.color = Color.white;
        Ayak1.color = Color.white;
        Ayak2.color = Color.white;

        speed = speed * 3;
    }
}
