using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankShooting : MonoBehaviour {

    public Transform shellSpawn;
    public GameObject shellPrefab;
    float moveSpeed=1500f;
    public bool isAI;

	// Use this for initialization
	void Start () {
    
    }

    
    private void FixedUpdate ()
    {
        if (isAI) return;
        if(Input.GetKey(KeyCode.Mouse0))
        Shoot();


   }
    float nextShoot = 0f;
    float frequency = 10f;

    public void Shoot()
    {
        if (Time.time > nextShoot)
        {
            GameObject shell = Instantiate(shellPrefab, shellSpawn.position, Quaternion.identity);
            shell.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed * Time.deltaTime;
            nextShoot = Time.time + 1f/frequency;
        }
    }
   
}

