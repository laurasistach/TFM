using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
