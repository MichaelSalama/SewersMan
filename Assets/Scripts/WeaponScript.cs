using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState
{
    IDLE,
    DOWN,
    UP,
    END
}

public class WeaponScript : MonoBehaviour {

    public float lengthRate = 0.34f;

    public GameObject weaponExtendable;
    public GameObject weaponEnd;
    SpriteRenderer sr;

    Rigidbody2D rbOfWeaponEnd;

    public PlayerControl player;
    Animator playerAnimator;

    float originalY;

    public WeaponState wState = WeaponState.END;

    private void Start()
    {
        rbOfWeaponEnd = weaponEnd.GetComponent<Rigidbody2D>();
        sr = weaponExtendable.GetComponent<SpriteRenderer>();

        playerAnimator = player.GetComponentInChildren<Animator>();
        originalY = rbOfWeaponEnd.transform.localScale.y;
    }

    private void Update()
    {
        switch (wState)
        {
            case WeaponState.DOWN:
                Extend();
                break;
            case WeaponState.UP:
                DeExtend();
                break;
            case WeaponState.END:
                playerAnimator.SetBool("SuckActive", false);
                player.suckAnimationPlayed = false;
                break;
        }
    }

    public void Suck()
    {
        wState = WeaponState.DOWN;
    }

    private void Extend()
    {
        weaponExtendable.transform.localScale = new Vector2(weaponExtendable.transform.localScale.x,
            weaponExtendable.transform.localScale.y + lengthRate);

        rbOfWeaponEnd.transform.position = new Vector2(rbOfWeaponEnd.transform.position.x,
            sr.bounds.min.y);
    }

    private void DeExtend()
    {
        //Debug.Log("de extending");

        weaponExtendable.transform.localScale = new Vector2(weaponExtendable.transform.localScale.x,
            weaponExtendable.transform.localScale.y - (lengthRate*1.2f));

        rbOfWeaponEnd.transform.position = new Vector2(rbOfWeaponEnd.transform.position.x,
            sr.bounds.min.y);

        if (weaponExtendable.transform.localScale.y <= originalY)
            wState = WeaponState.END;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.transform.tag == "Water")
        {
            //do nothing
        }
        if (collision.transform.tag == "Ground")
        {
            wState = WeaponState.UP;
        }
        else
        {
            if (collision.transform.tag == "Bala3a")
            {
                collision.transform.GetComponent<Bala3aScript>().Open();
            }
            else if (collision.transform.tag == "Bala3aBalakona")
            {
                collision.transform.GetComponent<Bala3etBalakonaScript>().Open();
            }
            wState = WeaponState.UP;
        }
    }
}
