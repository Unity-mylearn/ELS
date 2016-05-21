using UnityEngine;
using System.Collections;

public class CheckLine : MonoBehaviour {

    public int count = 0;
	void Update () {
        count = 0;
        if ( GameController3D.currentObject == null )
            return;
        //if ( GameController3D.currentObject.GetComponent<Group3D>().isStop ) {
        if ( GameController3D.canRun ) {
            RaycastHit[] hitInfo = new RaycastHit[30];
            hitInfo = Physics.RaycastAll(transform.position, Vector3.right, 100);
            for ( int i = 0; i < hitInfo.Length; i++ ) {
                if ( hitInfo[i].transform.name == "Cube" ) {
                    //Debug.Log(transform.name);
                    ++count;
                }
            }
            if ( count >= 20 ) {
                Debug.Log(transform.name);
                foreach ( RaycastHit hit in hitInfo ) {
                    if ( hit.transform.name == "Cube" ) {
                        Destroy(hit.transform.gameObject);
                    }
                }
                //for ( int i = 0; i < hitInfo.Length; i++ )
                //    hitInfo[i] = new RaycastHit();
            }
            //Debug.Log(transform.name + " " + count);
        }
    }
}
