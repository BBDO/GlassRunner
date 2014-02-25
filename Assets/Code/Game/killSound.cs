using UnityEngine;
using System.Collections;

public class killSound : MonoBehaviour 
{	
	public AudioClip sound;
	private GameController gameControl;
	bool hasPlayed = false;

	// Use this for initialization
	void Start () 
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameControl = gameControllerObject.GetComponent <GameController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameControl.killScreen) 
		{
			if (Application.loadedLevel == 1)
			{
				if (!hasPlayed)
				{
					audio.PlayOneShot(sound);
					audio.loop = false;

					hasPlayed = true;
				}
			}
		}
	}
}
