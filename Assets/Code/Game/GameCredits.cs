using UnityEngine;
using System.Collections;

public class GameCredits : MonoBehaviour 
{
	private GameController gameControl;

	// Use this for initialization
	void Start () 
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameControllerObject.GetComponent <GameController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameControl.killScreen) 
		{
			renderer.enabled = true;
			
			if (Application.loadedLevel == 0)
			{
				if (gameControl.gameState == 0)
				{
					GetComponent<TextMesh>().text = "Created by Jason Walters @ BBDO 2013";
				}
				else if (gameControl.gameState >= 1) 
				{
					GetComponent<TextMesh>().text = "";
				}
			}
		}
		else
		{
			renderer.enabled = false;
		}
	}
}
