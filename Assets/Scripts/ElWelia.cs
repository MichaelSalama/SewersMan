using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direct
{
    left,
    down
}
public class ElWelia : MonoBehaviour
{

    public Transform Trashmitter;
    public GameObject[] WhatToThrow;

    public float speed = 10f;
    float t = 0;
    public direct dir;
    private bool active = true;
    private void Start()
    {
        StartCoroutine(ThrowGarbage());
    }

    void Update()
    {
        if (!active)
        {
            t += Time.deltaTime;
            if (t >= 10)
                active = true;
        }
    }

    void ThrowTrash()
    {
        //GameObject TrashThrwon = Instantiate(WhatToThrow, Trashmitter.position, Trashmitter.rotation);

        int r = Random.Range(0,WhatToThrow.Length);

        GameObject TrashThrwon = Instantiate(WhatToThrow[r], Trashmitter);
        this.GetComponent<AudioSource>().Play();

        switch (dir)
        {
            case direct.left:
                TrashThrwon.GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
                break;
            case direct.down:
                TrashThrwon.GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
                break;

        }
    }

    public void Ropeoisout()
    {
        t = 0;
        // Debug.Log("el 7abl etshad");
        active = false;
    }

    IEnumerator ThrowGarbage()
    {
        while (true)
        {
            while (active)
            {
                //Debug.Log("El welia ramit el kis of rubbish");
                ThrowTrash();
                var time = Random.Range(10f, 12f);
                yield return new WaitForSeconds(time);
            }
            yield return new WaitForSeconds(10);
        }

    }
}
