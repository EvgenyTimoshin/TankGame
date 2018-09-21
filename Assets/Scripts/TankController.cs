using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    //Rigidbody rb;
    public Transform shellSpawnLoc;

	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fired");
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.Translate(shellSpawnLoc.position);
            Rigidbody rb = cube.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddForce(shellSpawnLoc.forward * 1000);
            cube.AddComponent<TankShellScript>();
            cube.transform.localScale -= new Vector3(0.5F, 0.5f, 0.5f);
            cube.GetComponent<BoxCollider>().isTrigger = true;
        }

    }

    void FixedUpdate() {
        Inputs();
    }

    void Inputs() {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * Time.deltaTime * 10,0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1 * Time.deltaTime * 10,0);
        }

        
    }

    void MoveForward() {

    }
}
