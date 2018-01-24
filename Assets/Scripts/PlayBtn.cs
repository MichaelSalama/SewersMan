using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    
    //private void Start()
    //{
    //    DisEnable();
    //}
    //public void DisEnable()
    //{
    //    GameObject.Find("GameManager").GetComponent<GameManager>().enabled = false;
    //    GameObject.FindWithTag("Player").GetComponent<PlayerControl>().enabled = false;
    //    GameObject.FindWithTag("elset").GetComponent<ElWelia>().enabled = false;
    //}

        public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Enable()
    {
        //Debug.Log("Hiiiii");
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().enabled = true;
        Debug.Log("game manager");
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 1;
        Debug.Log("player");

        GameObject.FindWithTag("elset").GetComponent<ElWelia>().enabled = true;
        Debug.Log("woman");
        GameObject.FindWithTag("UI").GetComponent<Canvas>().enabled = false; 
        Debug.Log("UI");
    }



}
