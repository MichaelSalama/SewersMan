using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour {
    public void BtnQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

	
}
