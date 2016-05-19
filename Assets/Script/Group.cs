using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {

	public bool isAlive = false;
	[SerializeField]
	private Transform[] self;

	[SerializeField]
	private float timeRate;
	private float time = 0.0f;
	private float timeTemp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time >= timeRate && isAlive){
			
			foreach (Transform tt in self) {
				if (!GameController._instance.canDown (tt)) {
					isAlive = false;
				}
			}
			if (!isAlive) {
				for(int i = 0;i<self.Length;i++){
					GameController._instance.setCube (ref self[i]);
				}
				for (int j = 0; j < GameController._instance.row;) {
					if (GameController._instance.isFullCube (j)) {
						GameController._instance.DeleteCube (j);
						GameController._instance.DownCube (j + 1);
					} else {
						j++;
					}
				} 
			}
			foreach (Transform tt in self) {
				if(isAlive)
					tt.Translate (new Vector3 (0.0f, -1.0f, 0));
			}
			time = 0;
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow) && isAlive){
			foreach (Transform tt in self) {
				if (tt.position.x <= 0) {
					return;
				}
			}
			foreach (Transform tt in self) {
				if (!GameController._instance.canMoveLeft (tt)) {
					return;
				}
			}
			foreach (Transform tt in self) {
				tt.Translate (new Vector3 (-1.0f, 0.0f, 0));
			}

		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && isAlive) {
			foreach (Transform tt in self) {
				if (tt.position.x >= 10) {
					return;
				} 
			}
			foreach (Transform tt in self) {
				if (!GameController._instance.canMoveRight (tt)) {
					return;
				}
			}
			foreach (Transform tt in self) {
				tt.Translate (new Vector3 (1.0f, 0.0f, 0));
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && isAlive) {
			timeTemp = timeRate;
			timeRate = timeRate / 4;
		}
		if (Input.GetKeyUp (KeyCode.DownArrow) && isAlive) {
			timeRate = timeTemp;
		}
	}
		
	void FixedUpdate(){

	}
}
