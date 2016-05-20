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

		if (UIManager.left) {
			transform.position += new Vector3 (-1, 0, 0);
			if (isValidGridPos ()) {
				UpdateGrid ();
			} else {
				transform.position += new Vector3 (1, 0, 0);
			}
			UIManager.left = false;
		}

		if (UIManager.right) {
			transform.position += new Vector3 (1, 0, 0);
			if (isValidGridPos ()) {
				UpdateGrid ();
			} else {
				transform.position += new Vector3 (-1, 0, 0);
			} 
			UIManager.right = false;
		}

		if (UIManager.down ||
		     Time.time - lastTime >= 1) { 
			transform.position += new Vector3 (0, -1, 0);
			if (isValidGridPos ()) {
				UpdateGrid ();
			} else {
				transform.position += new Vector3 (0, 1, 0);
				Grid.DeleteAllPassRow ();
				enabled = false;
				Spawn._instance.spawnNext ();
			}
			lastTime = Time.time;
			UIManager.down = false;
		}

		if (UIManager.change) {
			transform.Rotate (new Vector3 (0, 0, -90));
			if (isValidGridPos ()) {
				UpdateGrid ();
			} else {
				transform.Rotate (new Vector3 (0, 0, 90));
			}
			UIManager.change = false;
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
