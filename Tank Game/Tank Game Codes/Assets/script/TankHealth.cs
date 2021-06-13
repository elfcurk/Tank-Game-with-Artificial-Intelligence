using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour {
    public Text healthText;
    float health = 100f;

	// Use this for initialization
	void Start () {
        healthText.text = health.ToString();		
	}

	public void TakeDamage(float amount)
    {
        health -= (health*20)/100;
            if(health<=1)
        {
            health = 0;
            Die();
        }
        healthText.text = health.ToString();


    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
