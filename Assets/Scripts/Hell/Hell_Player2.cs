using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hell_Player2 : MonoBehaviour
{
    public Animator animator; public Animator Gunanimator; public Animator Bacakanimator;

    public Transform Fireposition; public Transform Shellposition;
    public GameObject BulletPrefab; public GameObject ShellPrefab; public GameObject GunPrefab;
    public float bulletForce = 20f;

    public SpriteRenderer KafaGO; public SpriteRenderer GovdeGO; public SpriteRenderer GovdeGO2; public SpriteRenderer GovdeGO3;
    public Sprite OnKafa; public Sprite OnGovde;
    public Sprite SagKafa; public Sprite SagGovde;
    public Sprite ArkaKafa; public Sprite ArkaGovde;

    public SpriteRenderer SagBacak;

    public int BulletCount = 13;
    public int MaxHealth = 1000;
    public int Health; public int HealthBefore;
    public HealthBar healthBar; 
    public TextMesh text;

    public bool sol = false; public bool assa = false;

    public Animator Healthanim;
    public bool Hasar = false;
    public float timeforHealthBar = 3f;

    public Mouse mouseScript;

    public bool oldun = false;

    public GameObject oldungo;     public GameObject gameover;

    public GameObject kameramiz;
    public GameObject kamera;

    public AudioSource ass;
    public AudioClip impact;

    public GameObject o1;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        HealthBefore = Health;
        healthBar.SetMaxHealth(MaxHealth);

        SagBacak.gameObject.GetComponent<Transform>().localPosition = new Vector3(-0.09f,SagBacak.gameObject.GetComponent<Transform>().localPosition.y,SagBacak.gameObject.GetComponent<Transform>().localPosition.z);

        BackgroundMusic.sahne = "hell";
    }

    // Update is called once per frame
    void Update()
    {
        if(oldun == false){
            text.text = BulletCount+"/13";
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0.0f);

            transform.position = transform.position + movement * 3f * Time.deltaTime;

            if(Health <= 0){
                oldun = true;
                oldungo.SetActive(true);
            }

            if(Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.A)){
                Bacakanimator.SetBool("Sag",true);
                if(Input.GetKey(KeyCode.D)){
                    SagBacak.flipX = false;
                    if(SagBacak.gameObject.GetComponent<Transform>().localPosition.x == 0.09f){
                        SagBacak.gameObject.GetComponent<Transform>().localPosition = new Vector3(-0.09f,SagBacak.gameObject.GetComponent<Transform>().localPosition.y,SagBacak.gameObject.GetComponent<Transform>().localPosition.z);
                    }         
                }else{
                    SagBacak.flipX = true;
                    if(SagBacak.gameObject.GetComponent<Transform>().localPosition.x == -0.09f){
                        SagBacak.gameObject.GetComponent<Transform>().localPosition = new Vector3(0.09f,SagBacak.gameObject.GetComponent<Transform>().localPosition.y,SagBacak.gameObject.GetComponent<Transform>().localPosition.z);
                    }  
                }
            }else{
                Bacakanimator.SetBool("Sag",false);
            }

            if(Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.S)){
                Bacakanimator.SetBool("Yukari",true);
                if(Input.GetKey(KeyCode.A)){
                    SagBacak.flipX = false;
                    if(SagBacak.gameObject.GetComponent<Transform>().localPosition.x == 0.09f){
                        SagBacak.gameObject.GetComponent<Transform>().localPosition = new Vector3(-0.09f,SagBacak.gameObject.GetComponent<Transform>().localPosition.y,SagBacak.gameObject.GetComponent<Transform>().localPosition.z);
                    }         
                }else{
                    SagBacak.flipX = true;
                    if(SagBacak.gameObject.GetComponent<Transform>().localPosition.x == -0.09f){
                        SagBacak.gameObject.GetComponent<Transform>().localPosition = new Vector3(0.09f,SagBacak.gameObject.GetComponent<Transform>().localPosition.y,SagBacak.gameObject.GetComponent<Transform>().localPosition.z);
                    }  
                }
            }else{
                Bacakanimator.SetBool("Yukari",false);
            }

            if(BulletCount == 0){
                Gunanimator.SetTrigger("Reload");
                BulletCount = 13;
                Invoke("Firlat",0.25f);
            }

            if(Input.GetKeyDown(KeyCode.R) && Gunanimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && BulletCount != 13){
                BulletCount = 0;
            }

            if(Input.GetMouseButtonDown(0) && BulletCount != 0 && Gunanimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
                Gunanimator.SetTrigger("Shoot");
                ass.PlayOneShot(impact, 0.1f);
                Hell_Camera.shakeDuration = 0.15f;
                BulletCount -= 1;

                GameObject bullet = Instantiate(BulletPrefab,Fireposition.position,Fireposition.rotation);
                GameObject shell = Instantiate(ShellPrefab,Shellposition.position,Shellposition.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = shell.GetComponent<Rigidbody2D>();
                rb.AddForce(Fireposition.right * bulletForce,ForceMode2D.Impulse);
                if(sol || assa){
                    rb2.AddForce(-Fireposition.up * bulletForce / 4,ForceMode2D.Impulse);
                    rb2.AddForce(-Fireposition.right * bulletForce / 4,ForceMode2D.Impulse);
                }else{
                    rb2.AddForce(Fireposition.up * bulletForce / 4,ForceMode2D.Impulse);
                    rb2.AddForce(-Fireposition.right * bulletForce / 4,ForceMode2D.Impulse);
                }
            }

            if(HealthBefore != Health){
                healthBar.SetHealth(Health);
                HealthBefore = Health;
                Hasar = true;
            }
            if(Hasar == true && timeforHealthBar >= 0){
                timeforHealthBar -= Time.deltaTime;
                Healthanim.SetBool("Open",true);
                Healthanim.SetBool("Close",false);

            }else if(Hasar == true){
                Healthanim.SetBool("Close",true);
                Healthanim.SetBool("Open",false);

                Hasar = false;
                timeforHealthBar = 3f;
            }

            if(Hell_Gun.angle >= -135 && Hell_Gun.angle <= -45){
                //on
                //KafaGO.sprite = OnKafa;
                GovdeGO.sprite = OnGovde;

                GovdeGO.transform.localPosition = new Vector3(GovdeGO.transform.localPosition.x,-0.78f,GovdeGO.transform.localPosition.z);

                GovdeGO.gameObject.SetActive(true);
                GovdeGO2.gameObject.SetActive(false);
                GovdeGO3.gameObject.SetActive(false);

                GovdeGO.transform.localScale = new Vector3(GovdeGO.transform.localScale.x,1f,GovdeGO.transform.localScale.z);

                GovdeGO.flipX = false;

                sol = false;
                assa = true;
            }
            if(Hell_Gun.angle >= -45 && Hell_Gun.angle <= 45){
                //sag
                //KafaGO.sprite = SagKafa;
                GovdeGO.sprite = SagGovde;

                GovdeGO.transform.localScale = new Vector3(GovdeGO.transform.localScale.x,0.82f,GovdeGO.transform.localScale.z);

                GovdeGO.transform.localPosition = new Vector3(GovdeGO.transform.localPosition.x,-0.640f,GovdeGO.transform.localPosition.z);
                GovdeGO2.transform.localPosition = new Vector3(0.0608f,-0.5616f,GovdeGO2.transform.localPosition.z);

                GovdeGO.gameObject.SetActive(false);
                GovdeGO2.gameObject.SetActive(true);
                GovdeGO3.gameObject.SetActive(false);

                if(GovdeGO.transform.localPosition.x == -0.06f){
                    GovdeGO.transform.localPosition = new Vector3(GovdeGO.transform.localPosition.x + 0.12f,GovdeGO.transform.localPosition.y,GovdeGO.transform.localPosition.z);
                }

                //KafaGO.flipX = false;
                GovdeGO.flipX = false;
                GovdeGO2.flipX = false;

                sol = false;
                assa = false;
            }
            if(Hell_Gun.angle >= 45 && Hell_Gun.angle <= 135){
                //yukarı
                //KafaGO.sprite = ArkaKafa;
                GovdeGO.sprite = ArkaGovde;

                GovdeGO.transform.localPosition = new Vector3(GovdeGO.transform.localPosition.x,-0.665f,GovdeGO.transform.localPosition.z);

                GovdeGO.transform.localScale = new Vector3(GovdeGO.transform.localScale.x,1f,GovdeGO.transform.localScale.z);

                GovdeGO.gameObject.SetActive(false);
                GovdeGO2.gameObject.SetActive(false);
                GovdeGO3.gameObject.SetActive(true);

                sol = false;
                assa = false;
            }
            if(Hell_Gun.angle >= 135 && Hell_Gun.angle <= 180){
                //sol
                //KafaGO.sprite = SagKafa;
                GovdeGO.sprite = SagGovde;

                GovdeGO.transform.localScale = new Vector3(GovdeGO.transform.localScale.x,0.82f,GovdeGO.transform.localScale.z);

                GovdeGO.gameObject.SetActive(false);
                GovdeGO2.gameObject.SetActive(true);
                GovdeGO3.gameObject.SetActive(false);

                GovdeGO.transform.localPosition = new Vector3(GovdeGO.transform.localPosition.x,-0.640f,GovdeGO.transform.localPosition.z);
                GovdeGO2.transform.localPosition = new Vector3(-0.065f,-0.563f,GovdeGO2.transform.localPosition.z);
            
                if(GovdeGO.transform.localPosition.x == 0.06f){
                    GovdeGO.transform.localPosition = new Vector3(GovdeGO.transform.localPosition.x - 0.12f,GovdeGO.transform.localPosition.y,GovdeGO.transform.localPosition.z);
                }

                KafaGO.flipX = true;
                GovdeGO.flipX = true;
                GovdeGO2.flipX = true;

                sol = true;
                assa = false;
            }
            Time.timeScale = 1f;
        }else{
            Time.timeScale = 0.00001f;
        }
    }
    public void Firlat(){
        GameObject gun = Instantiate(GunPrefab,Shellposition.position,Shellposition.rotation);
        Rigidbody2D rb = gun.GetComponent<Rigidbody2D>();
        if(sol || assa){
            rb.AddForce(-Fireposition.up * bulletForce / 8,ForceMode2D.Impulse);
        }else{
            rb.AddForce(Fireposition.up * bulletForce / 8,ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="Seytan"){
            kameramiz.gameObject.SetActive(false);
            kamera.gameObject.SetActive(true);

            o1.gameObject.SetActive(false);

            gameover.gameObject.SetActive(true);
            Invoke("BitirArtik",8f);
        }
    }
    public void BitirArtik(){
        SceneManager.LoadScene(5);
    }

    public void GetDamage(int dmg){
        Health -= dmg;
        Hell_Camera.shakeDuration = 0.1f;
    }
}
