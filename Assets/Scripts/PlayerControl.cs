﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    //Raycast_To_Bala3a taslik;

    //movement
    public float speed = 1f;
    public float jumpForce = 8f;
    public float jumpHeight = 10f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    public float maxRunSpeed = 8f;
    float extraSpeed = 0;

    //boost power up
    bool boosted = false;
    float timeelapsed = 0;

   
    //animator
    public Animator anim;
    [HideInInspector]
    public bool suckAnimationPlayed = false;

    //particle System
    public Transform particleSource;
    public ParticleSystem splashParticles;
    public ParticleSystem motorParticles;
    ParticleSystem motorBoost;

    //tools
    WeaponScript suckingWeapon;
    GameObject suckingWeaponParent;
    SpriteRenderer[] arr;
    GameObject elwelia;

    void Start () {
        //taslik = this.GetComponent<Raycast_To_Bala3a>();
        rb = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<BoxCollider2D>();
        anim = this.GetComponentInChildren<Animator>();
        
        suckingWeapon = GetComponentInChildren<WeaponScript>();
        suckingWeaponParent = GameObject.FindGameObjectWithTag("Weapon");
        suckingWeaponParent.gameObject.SetActive(false);
        elwelia = GameObject.FindGameObjectWithTag("elset");
        
        arr = suckingWeaponParent.gameObject.GetComponentsInChildren<SpriteRenderer>();
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    arr[i].enabled = false;
        //}
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            if (!suckAnimationPlayed)
            {
                anim.SetBool("SuckActive", true);
                suckAnimationPlayed = true;
                suckingWeaponParent.SetActive(true);
                //for (int i = 0; i < arr.Length; i++)
                //{
                //    arr[i].enabled = true;
                //}
            }
            //anim.SetBool("SuckActive", false);
            suckingWeapon.Suck();
            suckingWeaponParent.SetActive(true);
        }
        
        else {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                rb.velocity += new Vector2(Input.GetAxisRaw("Horizontal") * (speed + extraSpeed), 0);
                //this.transform.localScale = new Vector2(Mathf.Sign(Input.GetAxisRaw("Horizontal")) *1, 1);

                if(motorBoost)
                {
                    if (rb.velocity.x >= 0)
                    {
                        motorBoost.transform.localRotation = new Quaternion(0, 0, 0, 0);
                    }
                    else
                    {
                        motorBoost.transform.localRotation = new Quaternion(0, 180, 0, 0);
                    }
                }
                
            }

            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && (isGrounded))
            {
                rb.velocity += new Vector2(0, jumpForce);
                isGrounded = false;
            }


            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                col.size = new Vector2(col.size.x, .83f);
                col.offset = new Vector2(col.offset.x, -0.55f);
                anim.SetBool("Crouch", true);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                col.size = new Vector2(col.size.x, 1.834229f);
                col.offset = new Vector2(col.offset.x, 0);
                anim.SetBool("Crouch", false);
            }


            if (rb.velocity.x >= 0f)
            {
                this.transform.localScale = new Vector2(1, 1);
            }
            else
            {
                this.transform.localScale = new Vector2(-1, 1);
            }

        }

        if (boosted)
        {
           

            timeelapsed += Time.deltaTime;

            if (timeelapsed >= 3.4f)
            {
                boosted = false;
                extraSpeed = 0;
                Destroy(motorBoost);
            }

        }
    }

    private void FixedUpdate()
    {
        //gravity manipulation
        if(rb.velocity.y < -1.2f)
        {
            rb.gravityScale = 3.8f;
        }
        else
        {
            rb.gravityScale = 1f;
        }

        //maximum speed
        if(Mathf.Abs(rb.velocity.x) > maxRunSpeed+extraSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * (maxRunSpeed+extraSpeed), rb.velocity.y);
        }

        

        //maximum jump height
        if (rb.velocity.y > jumpHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Water")
        {
            this.GetComponent<AudioSource>().Play();
            SplashParticles();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water" || collision.transform.tag == "Bala3a")
        {
            isGrounded = true;
            anim.SetBool("IsGrounded",true);
        }
        if (collision.transform.tag == "elset" && Input.GetKeyDown(KeyCode.X) )
        {
            elwelia.GetComponent<ElWelia>().Ropeoisout();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water" ||  collision.transform.tag == "Bala3a")
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }

    }
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("IsGrounded", true);
        }
    }

    public void Boost()
    {
        motorBoost = Instantiate(motorParticles, particleSource);
        timeelapsed = 0;
        boosted = true;
        extraSpeed = 6.5f;
    }

    private void SplashParticles()
    {
        ParticleSystem ps = GameObject.Instantiate<ParticleSystem>(splashParticles,particleSource);
        ps.Play();
    }

}
