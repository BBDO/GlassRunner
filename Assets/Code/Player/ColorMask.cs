using UnityEngine;
using System.Collections;

public class ColorMask : MonoBehaviour 
{
	public HSBColor col;

	// Use this for initialization
	void Start () 
	{
		col.h = 0.35f;
		col.a = 1.0f;
		col.s = 0.76f;
		col.b = 0.82f;
	}

	
	// Update is called once per frame
	void Update ()
	{
		col.h+=0.00075f;
		if (col.h > 1.0f)
		{
			col.h = 0.0f;
		}

		if (col.a < 1.0f)
		{
			col.a+=0.075f;
		}

		renderer.material.color = col.ToColor();
	}
}
