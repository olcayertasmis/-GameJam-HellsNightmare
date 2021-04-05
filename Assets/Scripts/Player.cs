using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool sagabak;
    private Rigidbody2D myrb;
    private Animator anim;
    public int kalp = 1;
    public bool deadcheck = false;
    public GameObject gameover, stop;
    public bool onFloor = false;
    public float jumpPower;
    public int doublejump = 0;
    public float hiz;

    public GameObject Playerisik; public GameObject Camisik;

    public Daktilo daktilo;
    public Bina_Mesaj binago;


    public GameObject Biiiiiitttt;


    void Start()
    {
        Cursor.visible = false;

        sagabak = true;
        myrb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        hiz += GunGec.hiz;

        BackgroundMusic.sahne = "bina";
    }

    void Update()
    {
        if(daktilo.bitti2 && !binago.OyunuDondur){
            if (kalp == 0)
            {
                anim.SetBool("dead", true);
                gameover.SetActive(true);

            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (deadcheck == false)
                {
                    if (onFloor)
                    {
                        myrb.velocity = new Vector2(myrb.velocity.x, jumpPower);
                        anim.SetBool("jump", true);
                        if(GunGec.jump == 1){
                            doublejump++;
                        }
                        if(GunGec.jump == 2){
                            doublejump++;
                            doublejump++;
                        }
                    }
                }
            }
            else
            {
                anim.SetBool("jump", false);
            }
            if (!onFloor && doublejump != 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
                {
                    myrb.velocity = new Vector2(myrb.velocity.x, jumpPower);
                    anim.SetBool("jump", true);
                    doublejump--;
                }
            }
            float yatay = Input.GetAxis("Horizontal");
            if (deadcheck == false)
            {
                yoncevir(yatay);
                TH(yatay);
            }
        }
    }
    private void TH(float yatay)
    {
        myrb.velocity = new Vector2(yatay * hiz, myrb.velocity.y);
        anim.SetFloat("PlayerSpeed", Mathf.Abs(yatay));
    }
    private void yoncevir(float yatay)
    {
        if (yatay > 0 && !sagabak || yatay < 0 && sagabak)
        {
            sagabak = !sagabak;
            Vector3 yon = transform.localScale;
            yon.x *= -1;
            transform.localScale = yon;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Zemin")
        {
            onFloor = true;
            this.transform.parent = col.transform;
        }
        if (col.gameObject.tag == "Kill")
        {
            olme();
            Cursor.visible = true;
            Playerisik.SetActive(false);
            Camisik.SetActive(true);
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Zemin")
        {
            onFloor = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Zemin")
        {
            onFloor = false;
            this.transform.parent = null;

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Finish"){
            Biiiiiitttt.gameObject.SetActive(true);
        }
    }
    public void olme()
    {
        kalp -= 1;
        if (kalp == 0)
        {
            anim.SetBool("dead", true);
            deadcheck = true;
            gameover.SetActive(true);
            Time.timeScale = 0.00000001f;
        }
    }
}
