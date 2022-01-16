using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script defines the movement of the fish (for the "Under the sea" game)

public class fishMovement : MonoBehaviour
{
	private float speed = 0.2f;
    void Update()
    {
        Vector3 position = this.transform.position;
		position.x = position.x + 0.01f; 
		this.transform.position = position;
    }
}
