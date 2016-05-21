using UnityEngine;
using System.Collections;

public class GameController3D : MonoBehaviour {

	public static GameObject currentObject;
	[SerializeField]
	private Transform spawn;

	[SerializeField]
	private GameObject[] cubes;

    public static Group3D gp3;

    private float updateInternal = 0.25f;
    private float timeLeft;
    public static bool canRun = false;
	// Use this for initialization
	void Start () {
        timeLeft = updateInternal;
        currentObject = Instantiate(cubes[0], spawn.position, Quaternion.identity) as GameObject;
        gp3 = currentObject.GetComponent<Group3D>();
        gp3.isStop = true;
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if ( timeLeft <= 0.0 ) {
            //if ( gp3.isStop ) {
            //    StartCoroutine(spawnNext());
            //}
            canRun = true;
            timeLeft = 0.5f;
        }
        
    }

    void FixedUpdate() {
        if ( gp3.isStop && canRun) {
            canRun = false;
            StartCoroutine(spawnNext());
        }
    }

	public IEnumerator spawnNext(){
		int index = Random.Range (0, cubes.Length);
        currentObject =  Instantiate(cubes[index], spawn.position, Quaternion.identity) as GameObject;
        gp3 = currentObject.GetComponent<Group3D>();
        yield return new WaitForSeconds(updateInternal);
	}
}
