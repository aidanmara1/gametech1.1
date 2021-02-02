using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float movespeed = 1f;
    public Vector2 jumpheight;
    public int jumpCount = 1;
    private Rigidbody2D rb;


    public Sprite modelHead;
    public Sprite modelTorso;

    private SpriteRenderer modelCurr;



    public int bodyStage = 0; //BASIC STAGES [0.Head 1.body 2.legs 3.arms]
    public void setBodyStage(int x) { bodyStage = x; }


    private float dir_h;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        modelCurr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        modelConverter();
    }

    /// PLAYER FUNCTIONS
    //ABSTRACT TOP FUNCTION
    void playerMovement()
    {
        if (bodyStage == 0) //HEAD MOVEMENT, basically just rolling/horiztonal control
        {
            horizontalMove();
        }
        else if (bodyStage == 1) //HEAD AND BODY MOVEMENT, hopping eventually @@!, horizontal and vertical movement
        {
            jumpheight.y = 10;
            horizontalMove();
            jump();
        }


    }

    ///PRECISE MOVEMENT FUNCTIONS

    void horizontalMove() //HORIZONTAL MOVEMENT
    {
        dir_h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dir_h * movespeed, rb.velocity.y);
    }

    void jump() //VERTICAL MOVEMENT
    {
        if (Input.GetKeyDown("space") && jumpCount >= 1)
        {
            StartCoroutine(waitTimer(1f));
            jumpCount--;
        }

    }

    IEnumerator waitTimer(float a)
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(a);
        rb.AddForce(jumpheight, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumpCount = 1;
        }
    }

    void modelConverter(){
        if (bodyStage == 0) 
        {
            if (modelCurr.sprite != modelHead)
            { modelCurr.sprite = modelHead; }
        }
        else if (bodyStage == 1)
        {
            if (modelCurr.sprite != modelTorso)
            { modelCurr.sprite = modelTorso; }
        }

            }



}
