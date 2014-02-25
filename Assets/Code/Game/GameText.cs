using UnityEngine;
using System.Collections;

public class GameText : MonoBehaviour 
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
					GetComponent<TextMesh>().text = "GLASS RUNNER";
				}
				else if (gameControl.gameState == 1) 
				{
					GetComponent<TextMesh>().text = "COLLECT\nPYRAMIDS";
				}
				else if (gameControl.gameState == 2) 
				{
					GetComponent<TextMesh>().text = "GO THROUGH\nCIRCLES";
				}
				else if (gameControl.gameState == 3)
				{
					GetComponent<TextMesh>().text = "AVOID\nROCKS";
				}
				else if (gameControl.gameState == 4)
				{
					GetComponent<TextMesh>().text = "GET READY!";
				}
			}
			else 
			{
				GetComponent<TextMesh>().text = "GAME OVER";
			}
		}
		else
		{
			renderer.enabled = false;
		}
	}
}
