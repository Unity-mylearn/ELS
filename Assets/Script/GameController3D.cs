using UnityEngine;
using System.Collections;

public class GameController3D : MonoBehaviour {

	public GameObject currentObject;
	[SerializeField]
	private Transform spawn;

	[SerializeField]
	private GameObject[] cubes;

	public static GameController3D _instance;

	void Awake(){
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		currentObject = spawnNext ();
	}
	
	// Update is called once per frame
	void Update () {

	}



	public GameObject spawnNext(){
		int index = Random.Range (0, cubes.Length);
		return Instantiate (cubes [index], spawn.position, Quaternion.identity) as GameObject;
	}
}
