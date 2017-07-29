using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusLight : MonoBehaviour {

    public Sprite OnLight;
    public Sprite OffLight;
    public Subsystem System;
    public SpriteRenderer Renderer;

	// Use this for initialization
	void Start () {
	    Renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (System.IsEnabled) {
	        Renderer.sprite = OnLight;
	    }
	    else {
	        Renderer.sprite = OffLight;
	    }
	}
}
