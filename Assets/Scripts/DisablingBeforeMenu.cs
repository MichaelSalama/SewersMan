using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablingBeforeMenu : MonoBehaviour {

    public PlayerControl player;
    public ElWelia Welia;
    
	void LateUpdate() {
        player.enabled = false;
        Welia.enabled = false;
        this.GetComponent<GameManager>().enabled = false;
	}
	
}
