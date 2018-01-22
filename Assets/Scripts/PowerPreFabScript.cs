using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPreFabScript : MonoBehaviour
{
    private PlayerControl pl;

    private void Start()
    {
        pl = GameObject.FindObjectOfType<PlayerControl>();
        Destroy(this.gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pl.Boost();
            Destroy(this.gameObject);

        }

    }
}
