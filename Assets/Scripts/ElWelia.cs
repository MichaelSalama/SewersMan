using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direct
{
    left,
    down
}
public enum elWeliaState
{
    trash,
    water,
    trapped
}
public class ElWelia : MonoBehaviour
{

    public Transform Trashmitter;
    public GameObject[] WhatToThrow;
    public GameObject DumpedWater;

    public float speed = 10f;
    float t = 0;
    private direct dir = direct.down;
    public elWeliaState state = elWeliaState.water;
    //private bool active = true;

    private void Start()
    {
        StartCoroutine(ThrowGarbage());
    }

    void Update()
    {
        if (state == elWeliaState.trapped)
        {
            t += Time.deltaTime;
            if (t >= 7)
                state = elWeliaState.water;
        }
        Debug.Log(state);
    }

    void ThrowTrash()
    {
        //GameObject TrashThrwon = Instantiate(WhatToThrow, Trashmitter.position, Trashmitter.rotation);
        if (state == elWeliaState.trash)
        {
            dir = direct.left;
            int r = Random.Range(0, WhatToThrow.Length);

            GameObject TrashThrwon = Instantiate(WhatToThrow[r], Trashmitter);
            this.GetComponent<AudioSource>().Play();
            TrashThrwon.GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
        }
    }


    void DumpWater()
    {
        if (state == elWeliaState.water)
        {
            dir = direct.down;
            Instantiate(DumpedWater, Trashmitter);
            //Water.GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
        }
    }

    public void Ropeoisout()
    {
        t = 0;
        // Debug.Log("el 7abl etshad");
        state = elWeliaState.trapped;
    }

    IEnumerator ThrowGarbage()
    {
        while (true)
        {
            while (state != elWeliaState.trapped)
            {
                // Debug.Log("not trapped");
                var stateRan = Random.Range(0, 2);
                if (stateRan == 1)
                {
                    //Debug.Log("trash");
                    state = elWeliaState.trash;
                    //Debug.Log("El welia ramit el kis of rubbish");
                    ThrowTrash();
                    var time = Random.Range(10f, 12f);
                    yield return new WaitForSeconds(time);
                }
                else if (stateRan == 0)
                {
                    //Debug.Log("water");
                    state = elWeliaState.water;
                    DumpWater();
                    var time = Random.Range(10f, 12f);
                    yield return new WaitForSeconds(time);
                }
                //Debug.Log(stateRan);
            }
            yield return new WaitForSeconds(10);

        }

    }
}
