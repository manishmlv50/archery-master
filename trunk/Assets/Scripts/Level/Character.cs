using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour{
    
	public static Character Inst{get;set;}
	
	
	public Transform left;
	public Transform right;
	
	private float _moveDiretion;
	
	private bool _super;
	public bool Super
	{
		get
		{
			return _super;
		}
		set
		{
			_super = value;
			if(!_super)
				animation.CrossFade("idle");
			else
				animation.CrossFade("idlek");
		}
	}
	public float MoveDirection {
		get{
			return _moveDiretion;
		}
		set{
			_moveDiretion = value;
			if(_moveDiretion == 0)
			{
				if(!_super)
					animation.CrossFade("idle");
				else
					animation.CrossFade("idlek");
			}
			else{
				if(_moveDiretion < 0){
					if(!_super)
						animation.CrossFade("left");
					else
						animation.CrossFade("leftk");
				}
				else if(_moveDiretion > 0){
					if(!_super)
						animation.CrossFade("right");
					else
						animation.CrossFade("rightk");
				}
			}	
		}
	}
	
	void Start()
	{
		Inst = this;
		
		_moveDiretion = 0;
		animation["idle"].layer = 0;
		animation["idlek"].layer = 0;
		
		animation["left"].layer = 0;
		animation["right"].layer = 0;
		animation["leftk"].layer = 0;
		animation["rightk"].layer = 0;
		
		animation["shoot"].layer = 1;
		animation["cut"].layer = 1;
		
		animation["left"].speed = 2f;
		animation["right"].speed = 2f;
		
		animation["leftk"].speed = 2f;
		animation["rightk"].speed = 2f;
		
		Super = false;
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
