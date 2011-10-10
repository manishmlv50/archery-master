using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour{
    	
	public Transform left;
	public Transform right;
	
	private float _moveDiretion;
	public float MoveDirection {
		get
		{
			return _moveDiretion;
		}
		
		set{
			_moveDiretion = value;
			if(_moveDiretion == 0)
			{
				animation.CrossFade("idle");
				animation["idle"].layer = 0;
			}
			else{
				if(_moveDiretion < 0)
					animation.CrossFade("walkleft");
				else if(_moveDiretion > 0)
					animation.CrossFade("walkright");
				animation["idle"].layer = 1;
			}	
		}
	}
	
	void Start()
	{
		_moveDiretion = 0;
		animation.wrapMode = WrapMode.Loop;
		animation["idle"].layer = 0;
		animation["walkleft"].layer = 1;
		animation["walkright"].layer = 1;
	}
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
		
		
        float moveInput = MoveDirection * Time.deltaTime * GameStatus.Inst.MoveSpeed; 
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
