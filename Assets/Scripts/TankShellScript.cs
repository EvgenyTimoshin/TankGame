using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShellScript : MonoBehaviour {

    Rigidbody rb;
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Explosion Occured");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);

        foreach(Collider col in hitColliders) {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(500,transform.position, 10, 3.0F);
            }

        }
    }
}
