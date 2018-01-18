using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {



	public static int breakableCount = 0;


	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHit++;
		int maxHits = + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestoyed();
			Destroy(gameObject);
		}
	}
	

	
	// TODO Remove this method once we can actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
