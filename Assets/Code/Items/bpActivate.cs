using UnityEngine;
using System.Collections;

public class bpActivate : MonoBehaviour
{	
	public AudioClip coinSound;

	private bool scored = false;
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
		if (!gameControl.killScreen)
		{
			if (scored) 
			{
				gameControl.gameScore+=250;

				// if our air is 18 or below, add 10 air points
				if (gameControl.gameAir < 19) 
				{
					gameControl.gameAir+=10;
				}
				else 
				{
					// otherwise, just add the difference
					int addAir = 28 - gameControl.gameAir;
					gameControl.gameAir += addAir;
				}

				audio.PlayOneShot(coinSound);
				scored = false;
			}
		}
	}

	void OnTriggerExit(Collider collisions)
	{
		if (collisions.gameObject.tag == "Player")
		{
			if (!scored) scored = true;
		}
	}
}
