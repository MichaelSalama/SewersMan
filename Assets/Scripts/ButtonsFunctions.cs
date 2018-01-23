using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    public void Enable()
    {
        Debug.Log("Hiiiii");
        GameObject.Find("GameManager").GetComponent<GameManager>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().enabled = true;
        GameObject.FindWithTag("elset").GetComponent<ElWelia>().enabled = true;
        GameObject.FindWithTag("UI").GetComponent<Canvas>().enabled = false; 
    }
	
}
