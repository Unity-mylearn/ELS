using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Group3D : MonoBehaviour {


    public static Group3D _instance;
    //public Rigidbody[] childRb;
    //public List<Rigidbody> childRb = new List<Rigidbody>();
    public bool isStop = false;

    void Awake() {
        _instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        isStop = CheckAlive();
        if ( isStop ) {
            enabled = false;
        }
        //if(childRb.Count!=0)
        //    childRb.Clear();
        if ( Input.GetKeyDown(KeyCode.LeftArrow) && checkBorder() ) {
            transform.position += new Vector3(-1, 0, 0);
        }
        if ( Input.GetKeyDown(KeyCode.RightArrow) && checkBorder() ) {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    public bool CheckAlive() {
        //foreach ( Transform tt in transform ) {
        //    childRb.Add(tt.GetComponent<Rigidbody>());
        //}
        //for ( int i = 0; i < childRb.Count; i++ ) {
        //    //Debug.Log("The" + i + "'s" + childRb[i].velocity);
        //    if ( childRb[i].velocity != Vector3.zero )
        //        return false;
        //}
        foreach ( Transform tt in transform ) {
            if ( tt.GetComponent<Rigidbody>().velocity != Vector3.zero ) {
                return false;
            }
        }
        return true;
    }

    public bool checkBorder() {
        if ( transform.position.x <= -9 ||
            transform.position.x >= 9 ) {
            return false;
        }
        return true;
    }
}
