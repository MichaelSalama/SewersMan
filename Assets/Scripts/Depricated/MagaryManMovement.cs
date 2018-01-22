using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagaryManMovement : MonoBehaviour {
 
    public int speed= 1;
    public int height = 4;
    private bool isGrounded;
    private Rigidbody2D rb;

    void Start () {

        rb = this.GetComponent<Rigidbody2D>();

    }
	
	void Update () {
     
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                this.GetComponentInChildren<SpriteRenderer>().flipX = false;
                rb.velocity += new Vector2(speed, 0);
                //Debug.Log("right");
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                this.GetComponentInChildren<SpriteRenderer>().flipX = true;
                rb.velocity -= new Vector2(speed, 0);
                //Debug.Log("left");
            }

            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && (isGrounded)){
                rb.velocity += new Vector2(0, height);
                isGrounded = false;
                //Debug.Log("up");
            }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        //Debug.Log("coll");
    }

}
