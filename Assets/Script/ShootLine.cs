using UnityEngine;
using System.Collections;

public class ShootLine : MonoBehaviour {

	void Update () {
		RaycastHit rayinf = new RaycastHit ();;
		if (Physics.Raycast (transform.position, Vector3.down, out rayinf, 1) && enabled) {
			if (rayinf.collider.gameObject.name == "Plane" ||
			   rayinf.collider.gameObject.name == "Cube") {

				GameController3D._instance.currentObject = GameController3D._instance.spawnNext ();
				enabled = false;
			}
		}
	}
}
