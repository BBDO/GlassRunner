using UnityEngine;
using System.Collections;

public class MountainHelp : MonoBehaviour
{
	public float speed;

	private Vector3 position;
	private GameController gameControl;

	// Use this for initialization
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameControllerObject.GetComponent <GameController>();

		// let's sync our default object position in our buffer
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Application.loadedLevel == 0) 
		{	
			if (gameControl.gameState == 3) renderer.enabled = true;
			else renderer.enabled = false;
		}

		transform.position = new Vector3(position.x, position.y, position.z);
		transform.Rotate(transform.up * 100.0f * Time.deltaTime);
	}
}
