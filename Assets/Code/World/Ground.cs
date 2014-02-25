using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour 
{
	private Vector3 position;
	private GameController gameControl;
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameControllerObject.GetComponent <GameController>();

		player = GameObject.Find("Player");

		// let's sync our default object position in our buffer
		position = transform.position;

		position.x = Random.Range(-5000, 5000);
		position.z = Random.Range(-1000, 3000);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// if we are ahead of player, check player distance...
		if (transform.position.z > 0.0f){
			// check if we're close to player and then draw
			if (Vector3.Distance(transform.position, player.transform.position) < 1000.0f) {
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
		if (position.z < -1000.0f)
		{
			position.x = Random.Range(-5000, 5000);
			position.z = 3500.0f;//Random.Range(1000, 2000);
		}

		transform.position = new Vector3(position.x, position.y, position.z);
	}
}
