using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour 
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
		if (Application.loadedLevel == 0)
		{
			renderer.enabled = false;
		}
		else {

			renderer.enabled = true;
		}

		GetComponent<TextMesh>().text = (int)gameControl.gameTime + " TIME";
	}
}
