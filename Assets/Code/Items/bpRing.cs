using UnityEngine;
using System.Collections;

public class bpRing : MonoBehaviour 
{
	private float newAlpha;
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
			if (gameControl.gameState == 2)
			{
				renderer.enabled = true;
			}
			else
			{
				renderer.enabled = false;
			}
		}

		transform.Rotate(transform.forward * 100.0f * Time.deltaTime);

		// color alpha change
		newAlpha = Mathf.Lerp(0.7f, 0.0f, Mathf.InverseLerp (1500.0f, 2000.0f, transform.position.z));
		renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
	}
}
