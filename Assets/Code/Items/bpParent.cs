using UnityEngine;
using System.Collections;

public class bpParent : MonoBehaviour
{
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
		position.z -= gameControl.gameSpeed;
		if (position.z < -5500.0f)
		{
			position.x = Random.Range(-1300, 1300);
			position.z = Random.Range(5500.0f, 8500);
		}

		transform.position = new Vector3(position.x, position.y, position.z);
	}
}
