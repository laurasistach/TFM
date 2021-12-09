using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera4 : MonoBehaviour
{
	public Transform Camera;
    public Transform Player;
 
    void LateUpdate ()
    {
    	// Camera and player positioning
        Vector3 cam = Camera.position = new Vector3(Player.position.x, 0, -10f);
        Vector3 vec1 = Camera.position;
        Camera.position = Vector3.Lerp(vec1, cam, 10);


	}
}
