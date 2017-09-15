using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    private Vector3 movement;
    public float speed;

	// Use this for initialization
	void Start () {
        movement = new Vector3(Random.Range(-6.0f, 6.0f), 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 5.5f || transform.position.x < -5.5f)
        {
            movement = -movement;
            GetComponent<Rigidbody>().velocity = -movement * speed;
        }
		
	}

    void ChangeSide()
    {
        if (Random.Range(0, 3)==3)
        {
            movement = new Vector3(Random.Range(-6.0f, 6.0f), 0.0f, 0.0f);
        }

    }
}
