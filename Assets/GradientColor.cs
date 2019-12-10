using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientColor : MonoBehaviour
{
	// Use this for initialization
	Gradient g;
	private Color col;

	void Start ()
	{
		
//		color =...
//		this.gameObject.GetComponent<MeshRenderer> ().material.color = g.Evaluate(0.5F);
	}

	// Update is called once per frame
	void Update ()
	{
//		this.gameObject.GetComponent<MeshRenderer> ().material.color = g.Evaluate (Mathf.PingPong (Time.time, 1));
	}
	
//for color's filter
	public void SetWhite()
	{
		Renderer[] renderers = this.gameObject.GetComponentsInChildren<Renderer> ();
		if (col.Equals(null))
		{
			col = renderers[0].material.color;
		}

		foreach (Renderer rend in renderers) 
		{
			rend.material.color = Color.white;
		}
	}

	public void RestoreColor()
	{
		Renderer[] renderers = this.gameObject.GetComponentsInChildren<Renderer> ();
		foreach (Renderer rend in renderers) {
			rend.material.color = col;
		}
	}
//	
	public void SetGradient (string min_c, string max_c, float value)
	{	
		Component[] renderers;
//		print (min_c);
		float color = 0F;
		GradientColorKey[] gck;
		GradientAlphaKey[] gak;
		g = new Gradient ();
		gck = new GradientColorKey[2];

		switch (min_c) {
		case "red":
			gck [0].color = Color.red;
			gck [0].time = 0.0F;
			break;
		case "blue":
			gck [0].color = Color.blue;
			gck [0].time = 0.0F;
			break;
		case "green":
			gck [0].color = Color.green;
			gck [0].time = 0.0F;
			break;
		}

		switch (max_c) {
		case "red":
			gck [1].color = Color.red;
			gck [1].time = 1.0F;
			break;
		case "blue":
			gck [1].color = Color.blue;
			gck [1].time = 1.0F;
			break;
		case "green":
			gck [1].color = Color.green;
			gck [1].time = 1.0F;
			break;
		}

		gak = new GradientAlphaKey[2];
		gak [0].alpha = 1.0F;
		gak [0].time = 0.0F;
		gak [1].alpha = 1.0F;
		gak [1].time = 1.0F;
		g.SetKeys (gck, gak);

		renderers = this.gameObject.GetComponentsInChildren<Renderer> ();
		foreach (Renderer rend in renderers) {
				rend.material.color = g.Evaluate (value);
		}
	}
}
