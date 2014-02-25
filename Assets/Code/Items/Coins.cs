using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour 
{
	public AudioClip coinSound;

	private Vector3 position;
	private bool scored = false;
	private ColorMask colMask;
	private GameController gameControl;

	// Use this for initialization
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameControllerObject.GetComponent <GameController>();

		GameObject gocolMask = GameObject.Find ("ColorMask");
		colMask = gocolMask.GetComponent<ColorMask>();

		// let's sync our default object position in our buffer
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Application.loadedLevel == 0)
		{
			if (gameControl.gameState == 1) 
			{
				renderer.enabled = true;
			}
			else 
			{
				renderer.enabled = false;
			}

		}
		else 
		{
			if (position.z < 0) 
			{
				renderer.enabled = false;
			}
			else 
			{
				renderer.enabled = true;
			}
		}

		position.z-=gameControl.gameSpeed;
		if (position.z < -1000.0f)
		{
			position.x = Random.Range(-1300, 1300);
			position.z = 5500.0f;
		}

		transform.position = new Vector3(position.x, position.y, position.z);
		transform.Rotate(transform.up * 100.0f * Time.deltaTime);

		if (!gameControl.killScreen)
		{
			if (scored)
			{
				gameControl.gameScore += 100;
				audio.PlayOneShot(coinSound);
				scored = false;
			}
		}
	}

	void OnTriggerExit(Collider collisions)
	{
		if (collisions.gameObject.tag == "Player")
		{
			colMask.col.a = 0.0f;
			if (!scored) scored = true;
		}
	}
}
