using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    private float time, startTime;
    public Text timer;
    public Text socre;
	public Text tips;
	// Use this for initialization

	public static Vector2 touchOne = Vector2.zero;
	public static Vector2 touchTwo = Vector2.zero;

	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        time = Time.time - startTime;

        int second = (int)time % 60;
        int minute = ( int ) time / 60;

        timer.text = "时间:" + minute + ":" + second;

		if (Input.touchCount == 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				tips.text = "Touch";
				touchTwo = touchOne = Input.GetTouch (0).position;
			}
			if (Input.GetTouch (0).phase == TouchPhase.Moved) {
				tips.text = "Touch moved";
				touchTwo = Input.GetTouch (0).position;
			}
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				tips.text = "Touch Ended";
				touchOne = touchTwo = Vector2.zero;
			}
		}
	}
}
