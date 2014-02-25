using UnityEngine;
using System.Collections;

public class GameAir : MonoBehaviour
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
		if (Application.loadedLevel == 0){
			renderer.enabled = false;
		}
		else {
			renderer.enabled = true;
		}

		if (gameObject.name == "Air") 
		{
			GetComponent<TextMesh>().text = "air";
		}
		else 
		{
			transform.localScale = new Vector3(gameControl.gameAir, 0.25f, 1.0f);
		}
	}
}
