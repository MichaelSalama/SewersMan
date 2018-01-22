using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
           // Debug.Log("da5al el zebala");
            Destroy(this.gameObject);


        }
    }
   
}
