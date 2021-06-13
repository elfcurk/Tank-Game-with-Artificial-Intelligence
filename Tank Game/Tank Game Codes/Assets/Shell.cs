using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject,2);
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player"||other.gameObject.tag=="Enemy")
        {
            other.gameObject.GetComponent<TankHealth>().TakeDamage(20f);
        }
    }
}
