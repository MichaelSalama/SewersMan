using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScriptKilling : MonoBehaviour {

    private ParticleSystem ps;

    // Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>(); //this one
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isPlaying)
            return;

        Destroy(gameObject);
    }
}
