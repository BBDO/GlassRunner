using UnityEngine;
using System.Collections;

public class FallingBomb : MonoBehaviour 
{
	public AudioClip dropSound;

	private bool groundOn = false;
	private float scaler;
	private Vector3 position;
	private float newAlpha;
	private bool soundOn = false;

	private GameController gameControl;
	
	// Use this for initialization
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameControllerObject.GetComponent <GameController>();

		// let's sync our default object position in our buffer
		position = transform.position;

		position.y = 3000;
		position.x = Random.Range(-2600, 2600);
		position.z = 2500;

		scaler = 20.0f;
		newAlpha = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// don't draw if at max explosion size...
		if (newAlpha > 0.1f) renderer.enabled = true;
		else renderer.enabled = false;

		if ((int)gameControl.gameTime > 20) 
		{
			// scale size of object
			transform.localScale = new Vector3(scaler, scaler, scaler);

			if (groundOn)
			{
				position.z -= gameControl.gameSpeed;
				scaler+=2.0f;
				scaler = Mathf.Clamp(scaler, 20.0f, 200.0f);
				transform.position = new Vector3(position.x, 20.0f, position.z);
				newAlpha = Mathf.Lerp(1.0f, 0.0f, Mathf.InverseLerp (20.0f, 200.0f, scaler));
				
				if (soundOn) 
				{
					audio.PlayOneShot(dropSound);
					soundOn = false;
				}
			}
			else 
			{
				Physics.gravity = new Vector3(0.0f,-600.0f,0.0f);
				transform.position = new Vector3(position.x, transform.position.y, position.z);
			}

			if (transform.position.y < 20.0f) 
			{
				groundOn = true;
				soundOn = true;
			}
		
			if (transform.position.z < -4000.0f)
			{
				groundOn = false;
				scaler = 20.0f;
				position.y = 3000;
				position.x = Random.Range(-2600, 2600);
				position.z = 2500;
				newAlpha = 1.0f;

				transform.position = position;
			}

			// color alpha change
			renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, newAlpha);
		}
		else 
		{
			transform.position = new Vector3(position.x, 3000.0f, position.z);
		}
	}

	void OnTriggerEnter(Collider collisions)
	{
		if (newAlpha > 0.1f) 
		{
			if(collisions.gameObject.tag == "Player")
			{
				if (gameObject.name == "cloneBomb") Destroy(gameObject);
				gameControl.killScreen = true;
			}
		}
	}
}
