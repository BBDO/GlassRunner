using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public float bounce;
	public float bounceSpeed;
	public Done_Boundary boundary;

	private Vector3 position;

	void Start ()
	{
		// sync our default position
		position = transform.position;
	}

	void FixedUpdate ()
	{
//		float moveHorizontal = Input.GetAxis ("Horizontal");	// keyboard control
		float moveHorizontal = Input.acceleration.x * 5.0f;	// Google Glass accelerometer control
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		// create a "hover" affect using a sin wave
		float bounceY = position.y + bounce * Mathf.Sin (bounceSpeed * Time.time);

		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				bounceY, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
