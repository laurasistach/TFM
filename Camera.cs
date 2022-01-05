using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public Transform Camera1;
    public Transform Player;
 
    void LateUpdate ()
    {
    	// Camera and player positioning
        Vector3 cam = Camera1.position = new Vector3(Player.position.x, -3, -9.7f);
        Vector3 vec1 = Camera1.position;
        Camera1.position = Vector3.Lerp(vec1, cam, 10);
	}
}
