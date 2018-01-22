using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScript : MonoBehaviour {

    int direction = -1;
    public float speed = 3f;
    Rigidbody2D rb;
    public float powerOfPush = 100f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update () {

        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag != "Water")
        {
            direction *= (-1);
            this.transform.localScale = new Vector2(-direction, 1);
            this.GetComponent<AudioSource>().Play();
            if(collision.transform.tag == "Player")
            { 
                //to add force while hitting player ??
                rb.AddForce(-collision.contacts[0].normal*200); 
                collision.transform.GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal);
                //Debug.Log(-(collision.contacts[0].normal* powerOfPush));
            }
        }
    }
}
