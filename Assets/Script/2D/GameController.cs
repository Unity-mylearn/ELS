using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int row;
	public int col;

	public static Transform[,] grid;

	public static GameController _instance;
	[SerializeField]
	private GameObject[] cubes;
	private static GameObject currentCubes;

	void Awake(){
		_instance = this;
	}

	void Start () {
		grid = new Transform[row,col];

		currentCubes = cubes [0];
		currentCubes.GetComponent<Group> ().isAlive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCubes != null && !currentCubes.GetComponent<Group>().isAlive) {
			int index = Random.Range (0, cubes.Length);
			currentCubes = GameObject.
			Instantiate (cubes [index], transform.position, Quaternion.identity)
			as GameObject;
			currentCubes.GetComponent<Group> ().isAlive = true;
		}
	}

	public void setCube(ref Transform tt){
		int x = (int)tt.position.x;
		int y = (int)tt.position.y;
		grid [x, y] = null;
		grid [x, y] = tt;
	}

	public bool isFullCube(int r){
		bool isfull = true;
		for (int i = r; i < row; i++) {
			if (grid [i, r] == null) {
				isfull = false;
				break;
			}
		}
		return isfull;
	}
	public void DeleteCube(int r){
		for (int i = 0; i < row; i++) {
			Destroy (grid [i, r].gameObject);
			grid [i, r] = null;
		}
	}

	public void DownCube(int r){
		for (int x = r; x < col; x++) {
			for (int i = 0; i < row; i++) {
				if (grid [i, r] != null) {
					grid [i, r - 1] = grid [i, r];
					grid [i, r] = null;
					grid [i, r - 1].position += new Vector3 (0, -1, 0);
				}
			}
		}
	}

	public bool canDown(Transform tt){
		int x = (int)tt.position.x;
		int y = (int)tt.position.y;
		if (y == 0)
			return false;
		if (grid [x,y-1] != null)
			return false;
		return true;
	}

	public bool canMoveLeft(Transform tt){
		int x = (int)tt.position.x;
		if (x == 0)
			return false;
		int y = (int)tt.position.y;
		if (grid [x-1,y] != null)
			return false;
		return true;
	}

	public bool canMoveRight(Transform tt){
		int x = (int)tt.position.x;
		if (x == 10)
			return false;
		int y = (int)tt.position.y;
		if (grid [x+1,y] != null)
			return false;
		return true;
	}

}
