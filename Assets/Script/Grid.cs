using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public static int w = 10;
    public static int h = 16;

    public static Transform[,] grid = new Transform[w, h];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static bool insideBorder(Vector2 pos) {
        return ( int ) pos.x >= 0 && ( int ) pos.x < w && ( int ) pos.y >= 0; 
    }

    public static Vector2 roundVec2(Vector2 v2) {
        return new Vector2(Mathf.Round(v2.x), Mathf.Round(v2.y));
    }
}
