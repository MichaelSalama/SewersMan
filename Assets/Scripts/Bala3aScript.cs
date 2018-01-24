using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala3aScript : MonoBehaviour {

    public float FlowRate = 5;
    public bool isOpened = false;
    public float cooldownTime = 10;

    float timeCounter;

    //aniamtion
    Animator anim;

    //for placeholders
    //SpriteRenderer sr;
    //Color c;

	void Start () {
        //sr = this.GetComponent<SpriteRenderer>();
        //c = sr.color;
        anim = this.GetComponentInChildren<Animator>();
	}
	
	void Update () {
		
        if(isOpened)
        {
            timeCounter += Time.deltaTime;
            if(timeCounter >= cooldownTime)
            {
                isOpened = false;
                Close();
            }
        }
	}

    public void Open()
    {
        if (!isOpened) { 
        //Debug.Log("hi");
        isOpened = true;
        timeCounter = 0;

        //sr.color = new Color(50,50,50);

        this.GetComponent<AudioSource>().Play();
        anim.SetTrigger("Cleaning");
        }
    }

    private void Close()
    {
        //sr.color = c;
        anim.SetTrigger("TimeUp");
    }

}
