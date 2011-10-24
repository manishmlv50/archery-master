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
			}
			else{
				if(_moveDiretion < 0)
					animation.CrossFade("left");
				else if(_moveDiretion > 0)
					animation.CrossFade("right");
			}	
		}
	}
	
	void Start()
	{
		_moveDiretion = 0;
		animation["idle"].layer = 0;
		animation["left"].layer = 0;
		animation["right"].layer = 0;
		animation["shoot"].layer = 1;
	}
	
	void Update () {		
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
