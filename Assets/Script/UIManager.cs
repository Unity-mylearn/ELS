using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    private float time, startTime;
    public Text timer;
    public Text socre;
	public Text tips;

	public static bool down = false;
	public static bool change = false;
	public static bool left = false;
	public static bool right = false;

	public Button it;
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        time = Time.time - startTime;

        int second = (int)time % 60;
        int minute = ( int ) time / 60;

        timer.text = "时间:" + minute + ":" + second;
	}

	public void OnLeftClick(){
		left = true;
	}

	public void OnRightClick(){
		right = true;
	}

	public void OnUpClick(){
		change = true;
	}

	public void OnDownClick(){
		down = true;
	}
}
