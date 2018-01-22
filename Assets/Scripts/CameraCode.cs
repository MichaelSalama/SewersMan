using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCode : MonoBehaviour
{
    public Transform min;
    public Transform max;
    public GameObject toFollow;

    private void Update()
    {
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(toFollow.transform.position.x, transform.position.y, -10), 2);
        if (this.GetComponent<Transform>().position.x > max.position.x )
        {
            transform.position = new Vector3( max.position.x, transform.position.y , -10);

        }
        else if (this.GetComponent<Transform>().position.x < min.position.x)
        {
            transform.position = new Vector3(min.position.x, transform.position.y, -10);
        }
    }

}

