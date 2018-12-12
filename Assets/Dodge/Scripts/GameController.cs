using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;

    [HideInInspector]
    public static int playerScore = 0;

	// Use this for initialization
	void Start () {
        scoreText.text = playerScore.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        scoreText.text = playerScore.ToString();
    }


}
