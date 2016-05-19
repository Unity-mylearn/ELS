using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    private float time, startTime;
    public Text timer;
    public Text socre;
	// Use this for initialization
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
}
