using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public float gameTime;
	public float gameSpeed;
	public int gameState;
	public int gameScore;
	public int gameAir;
	public bool killScreen;

	private float timeSeconds = 0.0f;
	private int deathCounter = 0;

	// Use this for initialization
	void Start ()
	{
		// Disable Google Glass from dimming
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		if (Application.loadedLevel == 0)
		{
			killScreen = true;	// gameplay not active
		}
		else 
		{
			killScreen = false;	// gameplay is active
		}
		
		deathCounter = (int)Time.deltaTime;
		timeSeconds = 0.0f;
		gameScore = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// update our timeSeconds
		timeSeconds += Time.deltaTime;
		
		if (killScreen) 
		{
			if (Application.loadedLevel == 0)
			{
				if ((int)timeSeconds - deathCounter < 3)
				{
					gameState = 0;
				}
				else if ((int)timeSeconds - deathCounter > 2 && (int)timeSeconds - deathCounter < 5) 
				{
					gameState = 1;
				}
				else if ((int)timeSeconds - deathCounter > 4 && (int)timeSeconds - deathCounter < 7) 
				{
					gameState = 2;
				}
				else if ((int)timeSeconds - deathCounter > 6 && (int)timeSeconds - deathCounter < 9)
				{
					gameState = 3;
				}
				else if ((int)timeSeconds - deathCounter > 8 && (int)timeSeconds - deathCounter < 11)
				{
					gameState = 4;
				}
				else if ((int)timeSeconds - deathCounter > 10)
				{
					Application.LoadLevel(1);
				}
			}
			else 
			{
				// player is dead, stop moving
				gameSpeed = 0.0f;

				// count to 5 seconds then restart the level
				if ((int)timeSeconds - deathCounter > 5)
				{
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
		else
		{
			// keeps our air between 0 & 28
			gameAir = Mathf.Clamp(gameAir, 0, 28);

			// decrease our air every 2 seconds
			if ((int)timeSeconds - deathCounter > 2) 
			{
				gameAir -= 4;
				deathCounter = (int)timeSeconds;
			}

			// if air reaches 0, kill player
			if (gameAir < 1) {
				killScreen = true;
			}

			// 50 max speed for google glass; goes from 0 to 50 in 5 seconds
			gameSpeed = Mathf.Lerp(0.0f, 50.0f, Mathf.InverseLerp (0.0f, 5.0f, gameTime));
			gameSpeed = Mathf.Clamp (gameSpeed, 0, 50);

			// update our game time during play
			gameTime += Time.deltaTime;
		}
	}

	void OnGUI()
	{
		// quit the game when the player presses the escape key
		if (Event.current.Equals(Event.KeyboardEvent("escape"))) 
		{
			Application.Quit();
		}
	}
}
