using UnityEngine;
using System.Collections;

/* Change Log
 * 
 * September 24, 2011 - BD
 *              Added the following targets: BombTarget, FreezeTarget, TimeTarget
 * */

public class Arrow : MonoBehaviour {

        // Use this for initialization
        public int Counter{get;set;}
        void Start () {
                Counter=0;
        }
        
        // Update is called once per frame
        void Update () {
        
        }
        
        void OnTriggerEnter(Collider c)
        {
                Target ti = c.gameObject.GetComponent<Target>();
                if(ti != null){
                        ti.DoEffect(this);
                }
        }               
}
