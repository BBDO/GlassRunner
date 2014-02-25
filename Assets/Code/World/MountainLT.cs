using UnityEngine;
using System.Collections;

public class MountainLT : MonoBehaviour 
{	
	private Vector3 position;
	private GameController gameControl;
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find("Player");

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameControllerObject.GetComponent <GameController>();

		// let's sync our default object position in our buffer
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// if we are ahead of player, check player distance...
		if (transform.position.z > 0.0f){
			// check if we're close to player and then draw
			if (Vector3.Distance(transform.position, player.transform.position) < 10000.0f) {
				renderer.enabled = true;
			}
			else {
				// if we are far away, don't draw
				renderer.enabled = false;
			}
		}
		else {
			// if we are past player, don't draw
			renderer.enabled = false;
		}

		position.z -= gameControl.gameSpeed;

		if (position.z < -1800.0f)
		{
			position.x = -4000;
			position.z = 7800;
		}

		transform.position = new Vector3(position.x, position.y, position.z);
	}
}
