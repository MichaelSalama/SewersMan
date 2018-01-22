using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rubbish : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
<<<<<<< HEAD
            GameManager gameManager =GameObject.FindObjectOfType<GameManager>();
            gameManager.Rubbishcount++;
=======
           // Debug.Log("da5al el zebala");
            Destroy(this.gameObject);

>>>>>>> 6cca3f9295d9f4c205c56b239605761b7be3bbeb

            //Debug.Log("da5al el zebala");
            Destroy(this.gameObject);
        }
    }
   


}
