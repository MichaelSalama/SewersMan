using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEmitter : MonoBehaviour
{

    //public Transform powerEmitter;
    public GameObject powerUp;
    public float P_speed = 0.5f;
    //private PlayerControl pl;

    public float minTime = 18.0f;
    public float maxTime = 22.0f;

    private void Start()
    {
        StartCoroutine(DropPower());
        //pl = GameObject.FindObjectOfType<PlayerControl>();
    }

    void DropPowerUp()
    {
        //GameObject PowerThrown = Instantiate(powerUp, powerEmitter.position, powerEmitter.rotation);
        GameObject PowerThrown = Instantiate(powerUp, this.transform.position, this.transform.rotation);
        PowerThrown.GetComponent<Rigidbody2D>().velocity = -transform.up * P_speed;
    }

    IEnumerator DropPower()
    {
        while (true)
        {
            DropPowerUp();
            var time = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(time);

        }
    }


}
