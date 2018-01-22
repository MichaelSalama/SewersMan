using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_To_Bala3a : MonoBehaviour {

    public Transform rayCastEmitter;
    public LayerMask layerMasktoHit;

	public void ShootRay()
    {
        //Debug.Log("Shooting," + Camera.main.scaledPixelHeight + ", " + Screen.height);
        //Debug.DrawRay(rayCastEmitter.position, -Vector2.up* (Camera.main.scaledPixelHeight + this.transform.position.y), Color.yellow, 2f);

        var hit = Physics2D.Raycast(rayCastEmitter.position, Vector2.down, Screen.height, layerMasktoHit);
        Debug.DrawRay(rayCastEmitter.position, -Vector2.up* (Camera.main.scaledPixelHeight), Color.yellow, 2f);

        if (hit)
        {
            //Debug.Log(hit.transform.tag);
            if(!hit.transform.GetComponent<Bala3aScript>().isOpened)
                hit.transform.GetComponent<Bala3aScript>().Open();
        }
        else
        {
            
        }
    }
}
