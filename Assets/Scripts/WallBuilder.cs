using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BuildWall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BuildWall() {

        Vector3 pos = transform.position;

        for (int x = 0; x < 20; x++) {
            for (int y = 0; y < 20; y++) {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.parent = transform.parent;
                cube.transform.Translate(pos.z ,pos.y + y, pos.x + x);
                cube.AddComponent<Rigidbody>();
                cube.AddComponent<BoxCollider>();
                cube.AddComponent<RandColor>();

            }
        }
    }
}
