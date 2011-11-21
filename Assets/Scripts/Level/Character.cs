using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour{
    
	public static Character Inst{get;set;}
	
	public int fireSpeed = 5000;
	public Transform shotPoint;
	public Transform normalArrow;
	public Transform superArrow;
	
	public Transform left;
	public Transform right;
	
	private float _moveDiretion;
	public GameObject _superEffect;
	
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
			if(!_super){
				animation.CrossFade("idle");
				_superEffect.renderer.enabled = false;
			}
			else{
				animation.CrossFade("idlek");
				_superEffect.renderer.enabled = true;
			}
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
				if(_moveDiretion < 0 && CanMove){
					if(!_super)
						animation.CrossFade("left");
					else
						animation.CrossFade("leftk");
				}
				else if(_moveDiretion > 0 && CanMove){
					if(!_super)
						animation.CrossFade("right");
					else
						animation.CrossFade("rightk");
				}
			}	
		}
	}
	
	public bool CanMove {get;set;}
	public bool CanShoot {get;set;}
	
	void Start()
	{
		Inst = this;
		
		_moveDiretion = 0;
		CanMove = true;
		
		animation["idle"].layer = 0;
		animation["idlek"].layer = 0;
		
		animation["left"].layer = 0;
		animation["right"].layer = 0;
		animation["leftk"].layer = 0;
		animation["rightk"].layer = 0;
		
		animation["shoot"].layer = 0;
		animation["cut"].layer = 0;
		
		animation["cut"].speed = 0.7f;
		
		animation["left"].speed = 2f;
		animation["right"].speed = 2f;
		
		animation["leftk"].speed = 2f;
		animation["rightk"].speed = 2f;
		animation["shoot"].speed = 0.85f;
		
		Super = false;
		CanMove = false;
		CanShoot = false;
	}
	
	void Update () {
		if(!CanMove)
			return;
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
	
	public void Freeze(float time)
	{
		MoveDirection = 0;
		CanMove = false;
		Invoke("enableMove",time);
	}
	
	void enableMove()
	{
		CanMove = true;
		MoveDirection = 0;
	}
	
	public void ShootArrow ()
	{
		MoveDirection = 0;
		CanMove = false;
		if(!Character.Inst.Super)
		{	
			animation.CrossFade("shoot");
			Invoke ("doNormalShoot", 0.3f);
		}
		else
		{
			animation.CrossFade("cut");
			Invoke ("doSuperShoot", 0.2f);
		}
	}

	void doNormalShoot ()
	{
		Transform bullet = (Transform)Instantiate (normalArrow, shotPoint.transform.position, Quaternion.LookRotation (Vector3.forward));
		bullet.rigidbody.AddForce (transform.forward * fireSpeed);
		Energy e = FindObjectOfType(typeof(Energy)) as Energy;
		if(e == null || !Character.Inst.Super)
			GameStatus.Inst.ArrowCount--;
		Invoke ("enableMove", 0.3f);
		
	}
	
	void doSuperShoot ()
	{
		Transform bullet = (Transform)Instantiate (superArrow, shotPoint.transform.position, Quaternion.LookRotation (Vector3.forward));
		bullet.rigidbody.AddForce (transform.forward * fireSpeed);
		Energy e = FindObjectOfType(typeof(Energy)) as Energy;
		if(e == null || !Character.Inst.Super)
			GameStatus.Inst.ArrowCount--;
		Invoke ("enableMove", 0.2f);
	}
}
