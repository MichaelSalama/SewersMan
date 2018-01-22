using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Childstate
{
    InNneed,
    Saved
}

public class Child : MonoBehaviour
{
    public Childstate state;

    void Start()
    {
        state = Childstate.InNneed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            state = Childstate.Saved;
            this.GetComponent<AudioSource>().Play();
            this.GetComponentInChildren<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            //this.gameObject.SetActive(false);
        }
    }
}
