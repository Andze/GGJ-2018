using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject[] Players;
    public CameraFollow CameraFocus;
    private int CurrentPlayer = 0;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Tab))
        {
            Players[CurrentPlayer].GetComponent<Player>().currentlySelected = false;

            CurrentPlayer++;         

            if (CurrentPlayer == Players.Length)
                CurrentPlayer = 0;

            Players[CurrentPlayer].GetComponent<Player>().currentlySelected = true;
        }

        CameraFocus.target = Players[CurrentPlayer];
    }
}
