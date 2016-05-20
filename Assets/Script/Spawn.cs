using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    [SerializeField]
    private GameObject[] cubes;

    public static Spawn _instance;


    void Awake() {
        _instance = this;
    }
	// Use this for initialization
	void Start () {
        spawnNext();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnNext() {
        int i = Random.Range(0, cubes.Length);
        GameObject gb = Instantiate(cubes[i], transform.position, Quaternion.identity) as GameObject;
		Groups.downKey = false;
	}
}
