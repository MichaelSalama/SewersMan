using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala3etBalakonaScript : MonoBehaviour {
    public float FlowRate = 5;
    public bool isOpened = false;
    public float cooldownTime = 10;

    //aniamtion
   public ParticleSystem particle;

    void Update()
    {
    }

    public void Open()
    {
        isOpened = true;
        var p = Instantiate(particle, this.transform);

        this.GetComponent<AudioSource>().Play();
        p.Play();
        this.enabled = false;
    }

}