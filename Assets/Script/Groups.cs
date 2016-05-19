using UnityEngine;
using System.Collections;

public class Groups : MonoBehaviour {


    private float lastTime;
	// Use this for initialization
	void Start () {
        if ( !isValidGridPos() ) {
            Debug.Log("GameOver");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if ( Input.GetKeyDown(KeyCode.LeftArrow) ) {
            transform.position += new Vector3(-1, 0, 0);
            if ( isValidGridPos() ) {

            } else {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        if ( Input.GetKeyDown(KeyCode.RightArrow) ) {
            transform.position += new Vector3(1, 0, 0);
            if ( isValidGridPos() ) {

            } else {
                transform.position += new Vector3(-1, 0, 0);
            } 
        }
        if ( Input.GetKeyDown(KeyCode.DownArrow) || 
            Time.time - lastTime >= 1) { 
            transform.position += new Vector3(0, -1, 0);
            if ( isValidGridPos() ) {
            } else {
                transform.position += new Vector3(0, 1, 0);
                Spawn._instance.spawnNext();
                enabled = false;
            }
            lastTime = Time.time;
        }
        if ( Input.GetKeyDown(KeyCode.UpArrow) ) {
            transform.Rotate(new Vector3(0, 0, -90));
            if ( isValidGridPos() ) {

            } else {
                transform.Rotate(new Vector3(0, 0, 90));
            }
        }

    }

    public bool isValidGridPos() {
        foreach ( Transform tt in transform ) {
            Vector2 v = Grid.roundVec2(tt.position);
            if ( !Grid.insideBorder(v) ) {
                return false;
            }

            if ( Grid.grid[( int ) v.x, ( int ) v.y] != null ) {
                return false;
            }
        }
        return true;
    }
}
