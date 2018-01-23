using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    ONGOING,
    LOSE,
    WIN
}

public class GameManager : MonoBehaviour {

    public GameState gameState = GameState.ONGOING;

    public Bala3aScript[] Sewers;
    public Child[] ChildrenToSave;

    Camera mainCamera;
    Water w;
    BoxCollider2D boxBounds;
    Vector2 pointHeightOfWater;

    //water interaction
    float totalHeight;
    float waterHeight;
    public float waterPercentage;
    Rigidbody2D rbOfWater;
    public float waterSpeed = 0.1f;
    //bool waterActive = true;

    //Flowrate
    // how much change the water will do in deltaTime   //float deltat = 0.02f;
    public float deltah;
    public float InFlowRat = 50;
    float OutFlowRat_total = 0;

    //sewer Counter
    public Text sewerCountText;
    int sewerCount;
    // timer
    public Text TimerText;
    float totalTime = 0.0f;
    //Children Coutner
    public Text childrenCountText;
    int childrenCount;

    //UI win Lose screens
    public Image WinScreen;
    public Image LoseScreen;
    bool playedSound = false;

    void Start () {
        //fill in objects
        Sewers = GameObject.FindObjectsOfType<Bala3aScript>();
        ChildrenToSave = GameObject.FindObjectsOfType<Child>();
        mainCamera = GameObject.FindObjectOfType<Camera>();

        //water control
        w = GameObject.FindObjectOfType<Water>();
        boxBounds = w.GetComponent<BoxCollider2D>();
        totalHeight = Screen.height;
        rbOfWater = w.GetComponent<Rigidbody2D>();
        waterHeight = CalculateHeightOfWater();
        waterPercentage = CalculateWaterPercentage();

        childrenCount = ChildrenToSave.Length;
    }

    private void Update ()
    {
        if(gameState == GameState.ONGOING)
        {
            //water control
            if (deltah >= 1)
            {
                rbOfWater.velocity = new Vector2(0, waterSpeed * 2);
            }
            else if (deltah < 1)
            {
                var difference = (1f - deltah) + 1f;
                rbOfWater.velocity = new Vector2(0, -(waterSpeed * difference));
                Debug.Log("speed: " + (-(waterSpeed * difference)));
            }

            waterPercentage = CalculateWaterPercentage();

            //winning and losing
            if (waterPercentage <= 0.08f)
            {
                //you win
                rbOfWater.velocity = new Vector2();
                w.enabled = false;
                gameState = GameState.WIN;
            }
            else if (waterPercentage >= 1.05f)
            {
                //you lose
                rbOfWater.velocity = new Vector2();
                w.enabled = false;
                gameState = GameState.LOSE;
            }

            //time
            sewerCount = 0;
            sewerCount = SewerCounter();
            totalTime += Time.deltaTime;
            UpdateLevelTimer(totalTime);

            ChildrenCounter();
        }
        else if(gameState == GameState.WIN)
        {
            //you win
            WinScreen.gameObject.SetActive(true);

            if(!playedSound)
            {
                WinScreen.GetComponent<AudioSource>().Play();
                playedSound = !playedSound;
            }
        }
        else
        {
            //youlose
            LoseScreen.gameObject.SetActive(true);
        }

        //debug key
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(waterPercentage);
        }
	}

    private void FixedUpdate()
    {
        WaterFlowRate();
    }

    float CalculateHeightOfWater()
    {
        pointHeightOfWater = mainCamera.WorldToScreenPoint(boxBounds.bounds.max);
        pointHeightOfWater = new Vector2(pointHeightOfWater.x, (w.transform.localScale.y * 2f) + pointHeightOfWater.y);

        return pointHeightOfWater.y;
    }

    void WaterFlowRate()
    {
        OutFlowRat_total = 0;
        for (int i = 0; i < Sewers.Length; i++)
        {
            if (Sewers[i].isOpened)
            {
                OutFlowRat_total += Sewers[i].FlowRate;
                
            }
           
        }
        deltah = Time.deltaTime * (InFlowRat - OutFlowRat_total);
        //Debug.Log(Time.deltaTime);
        //Debug.Log(InFlowRat);
      //Debug.Log(deltah);
    }

    float CalculateWaterPercentage()
    {
        waterHeight = CalculateHeightOfWater();
        return waterHeight / totalHeight;
    }

    int SewerCounter()
    {
        for (int i = 0; i < Sewers.Length; i++)
        {
            if (Sewers[i].isOpened)
            {
                sewerCount++;
            }
        }
        sewerCountText.text = "Fixed Sewers: " + sewerCount + "/" + Sewers.Length;
        //Debug.Log(count);

        return sewerCount;
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);
        int milisec = Mathf.RoundToInt((totalSeconds - (int)totalSeconds) * 100f);

        //string formatedSeconds = seconds.ToString();
        //string formatedmilisec = milisec.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
            //Debug.Log("da5al el condition sec");
        }

        if (milisec % 100 == 1)
        {
            milisec = 0;
            seconds += 1;
            //Debug.Log("da5al el condition mili");
        }


        // TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") ;

        TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milisec.ToString("00");
    }

    private void ChildrenCounter()
    {
        childrenCount = 0;
        for (int i = 0; i < ChildrenToSave.Length; i++)
        {
            if(ChildrenToSave[i].state == Childstate.Saved)
            {
                childrenCount++;
            }
        }

        childrenCountText.text = "Children Saved: " + childrenCount;
    }
}
