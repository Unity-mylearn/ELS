using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Groups : MonoBehaviour {


	private float lastTime;
	private bool gameOver = false;
	public static bool downKey = false;

	// Use this for initialization
	void Start () {
		if (!isValidGridPos ()) {
			gameOver = true;
			Time.timeScale = 0;
//            Debug.Log("GameOver");
		}
	}
	// Update is called once per frame
	void Update () {
		if (gameOver)
			return;

		if (UIManager.touchOne.x > UIManager.touchTwo.x) {
			transform.position += new Vector3 (-1*Time.deltaTime, 0, 0);
			if (isValidGridPos ()) {
				UpdateGrid ();
			} else {
				transform.position += new Vector3 (1*Time.deltaTime, 0, 0);
			}
		}

		if (UIManager.touchOne.x < UIManager.touchTwo.x) {
			transform.position += new Vector3 (1*Time.deltaTime, 0, 0);
			if (isValidGridPos ()) {
				UpdateGrid ();
			} else {
				transform.position += new Vector3 (-1*Time.deltaTime, 0, 0);
			} 
		}

		if (UIManager.touchOne.y > UIManager.touchTwo.y ||
		     Time.time - lastTime >= 1) { 
			transform.position += new Vector3 (0, -1*Time.deltaTime, 0);
			if (isValidGridPos ()) {
				UpdateGrid ();
			} else {
				transform.position += new Vector3 (0, 1*Time.deltaTime, 0);
				Grid.DeleteAllPassRow ();
				enabled = false;
				Spawn._instance.spawnNext ();
			}
			lastTime = Time.time;
		}

		if (UIManager.touchOne.y < UIManager.touchTwo.y) {
			transform.Rotate (new Vector3 (0, 0, -90));
			if (isValidGridPos ()) {
				UpdateGrid ();
			} else {
				transform.Rotate (new Vector3 (0, 0, 90));
			}
		}

	}


	public bool isValidGridPos () {
		foreach (Transform tt in transform) {
			Vector2 v = Grid.roundVec2 (tt.position);
			if (!Grid.insideBorder (v)) {
				return false;
			}

			if (Grid.grid [(int)v.x, (int)v.y] != null &&
			             Grid.grid [(int)v.x, (int)v.y].parent != transform) {
				return false;
			}
		}
		return true;
	}

	public void UpdateGrid () {

		for (int y = 0; y < Grid.h; y++) {
			for (int x = 0; x < Grid.w; x++) {
				if (Grid.grid [x, y] != null &&
				    Grid.grid [x, y].parent == transform) {
					Grid.grid [x, y] = null;
				}
			}
		}
		foreach (Transform tt in transform) {
			Vector2 v = Grid.roundVec2 (tt.position);
			Grid.grid [(int)v.x, (int)v.y] = tt;
		}
	}
}
