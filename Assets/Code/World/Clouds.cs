using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour 
{
	private Vector3 position;
	private GameController gameControl;

	// Use this for initialization
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameControllerObject.GetComponent <GameController>();

		position.x = Random.Range(-5000, 5000);
		position.y = Random.Range(800, 1000);
		position.z = Random.Range(1500, 6000);

		transform.localScale = new Vector3(200, 20, 200);
	}
	
	// Update is called once per frame
	void Update ()
	{
		position.z -= gameControl.gameSpeed;
		if (position.z < -200.0f)
		{
			position.x = Random.Range(-5000, 5000);
			position.y = Random.Range(800, 1000);
			position.z = 6000.0f;
			transform.localScale = new Vector3(200, 20, 200);
		}

		transform.position = new Vector3(position.x, position.y, position.z);
	}
}
