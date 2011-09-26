using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour{
    	
	public Transform left;
	public Transform right;

	void Update () {
		
		if(FreezeTarget.isFrozen)
		{
			if((Time.time - FreezeTarget.lastTime) > FreezeTarget.FREEZETIME)
			{
				// No longer frozen
				FreezeTarget.isFrozen = false;
			}
			else
			{
				// Still frozen - don't allow movement.
				return;	
			}
		}
		
		
        float moveInput = Move.moveDirection * Time.deltaTime * GameStatus.Inst.MoveSpeed; 
        transform.position += new Vector3(moveInput, 0, 0);
		
		float l = left.position.x + 10f;
		float r = right.position.x - 10f;
        if (transform.position.x <= l || transform.position.x >= r)
        {
            float xPos = Mathf.Clamp(transform.position.x, l , r);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
	

	}
}
