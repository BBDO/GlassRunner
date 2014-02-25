using UnityEngine;
using System.Collections;

public class Mountain : MonoBehaviour 
{
	public float speed;

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
		position.x = Random.Range(-2800, 2800);

		speed = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// if we are ahead of player, check player distance...
		if (transform.position.z > 0.0f)
		{
			// check if we're close to player and then draw
			if (Vector3.Distance(transform.position, player.transform.position) < 10000.0f) {
				renderer.enabled = true;
			}
			else 
			{
				// if we are far away, don't draw
				renderer.enabled = false;
			}
		}
		else
		{
			// if we are past player, don't draw
			renderer.enabled = false;
		}

		position.z-=gameControl.gameSpeed;

		if (position.z < -2400.0f)
		{
			position.x = Random.Range(-2800, 2800);
			position.z = Random.Range(5500.0f, 8500);
		}

		transform.position = new Vector3(position.x, position.y, position.z);
	}

	void OnTriggerEnter(Collider collisions)
	{	
		if(collisions.gameObject.tag == "Player") gameControl.killScreen = true;
	}
}
