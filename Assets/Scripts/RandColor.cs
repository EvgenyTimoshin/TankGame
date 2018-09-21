using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandColor : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();

        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);

        rend.material.color = newColor;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
