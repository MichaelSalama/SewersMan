using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5fyElSalaka : MonoBehaviour {

    public GameObject weapon;
    SpriteRenderer[] sprites;
    Collider2D sallakaCol;

    void Start () {
		sprites = weapon.GetComponentsInChildren<SpriteRenderer>();
        sallakaCol = weapon.GetComponent<Collider2D>();
    }

    void DisableSalaka()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].enabled = false;
           // sallakaCol.enabled = false;
        }
        //weapon.GetComponentInChildren<BoxCollider2D>().enabled = false;
    }

    void EnableSalaka()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].enabled = true;
        }
        //sallakaCol.enabled = true;
        //weapon.GetComponentInChildren<BoxCollider2D>().enabled = true;
    }
}
