﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grabable : MonoBehaviour {

	public Rigidbody rigidbody;
	public string description;
	List<Color> startColors;
	List<Renderer> renderers;
	bool skip = false;
    //Shader startShader;
	Color endColor;
	float timer = .20f;
	int mod = 1;

	// Use this for initialization
	void Start () 
    {
		if (rigidbody == null)
			rigidbody = GetComponent<Rigidbody> ();
		renderers = new List<Renderer>();
		startColors = new List<Color> ();
		endColor = new Color (0, 1f, 0);


		// Retrieves all renderers and material tints from all children and self
		if(GetComponent<MeshRenderer>() != null){
			renderers.Add (GetComponent<MeshRenderer> ());
			startColors.Add (GetComponent<MeshRenderer>().material.color);
		}
		GetRenderers (transform);
	}

	void GetRenderers(Transform t)
	{
		foreach(Transform child in t) {
			GetRenderers(child); // This will repeat the process on the child.
			if(child.GetComponent<MeshRenderer>() != null){
				renderers.Add (child.GetComponent<MeshRenderer> ());
				startColors.Add (child.GetComponent<MeshRenderer>().material.color);
			}
		}
	}

	void Update(){

		if (!skip) {
			for(int i=0; i<renderers.Count; i++)
				renderers[i].material.color = startColors[i];
			timer = .20f;
			mod = 1;
		}
		else
			skip = !skip;
	}


	public void Hover () {
		timer += Time.deltaTime * mod;
		if (timer >= .85f || timer <= .15f)
			mod *= -1;
		
		for(int i=0; i<renderers.Count; i++)
			renderers[i].material.color = Color.Lerp (startColors[i], endColor, timer);
		skip = true;
	}
	
	public string GetDiscription()
	{
		return description;
	}

	public void SetColor(Color c){
		for (int i=0; i<renderers.Count; i++) {
			startColors[i] = c;
			renderers[i].material.color = c;
		}
	}
}
