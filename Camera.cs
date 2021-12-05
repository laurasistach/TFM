using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public Transform Followplatform;
    public Transform Player;
    public Transform Score; 
 
    void LateUpdate ()
    {
    	// Camera and player positioning
        Vector3 cam = Followplatform.position = new Vector3(Player.position.x, -3, -9.7f);
        Vector3 vec1 = Followplatform.position;
        Followplatform.position = Vector3.Lerp(vec1, cam, 10);

        // Score square position
        Vector3 score_pos = Score.position = new Vector3(Player.position.x + 10f,2.7f,0);

	}
}
