using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3 : MonoBehaviour
{
	public Transform Followplatform;
    public Transform Player;
    public Transform Score; 
 
    void LateUpdate ()
    {
    	// Camera and player positioning
        Vector3 cam = Followplatform.position = new Vector3(Player.position.x, -3, -10f);
        Vector3 vec1 = Followplatform.position;
        Followplatform.position = Vector3.Lerp(vec1, cam, 10);

        // Score square position
        Vector3 score_pos = Score.position = new Vector3(Player.position.x + 40,17,0);

	}
}
