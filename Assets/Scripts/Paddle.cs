using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Collections;
public class Paddle : MonoBehaviour {

	//public bool autoPlay = false;
	public float minX, maxX;
	public float speed = 200f;

	//private Ball ball;
	public GameObject BulletPrefab;
	private List<GameObject> Bullet = new List<GameObject> ();
	
	void Start () {
		//ball = GameObject.FindObjectOfType<Ball>();
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime/ Screen.width * 16;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime/ Screen.width * 16;
		}

		if (Input.GetKey (KeyCode.Space)) {
			GameObject bullet = (GameObject)Instantiate (BulletPrefab, transform.position, Quaternion.identity);
			Bullet.Add (bullet);
		}

		for (int i = 0; i < Bullet.Count; i++) {

			GameObject goBullet = Bullet [i];
			if (goBullet != null) {
				goBullet.transform.transform.Translate (new Vector3 (0, 1) * Time.deltaTime * 2f);

				Vector3 bulletpos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletpos.y >= Screen.height || bulletpos.y <= 0) {
					DestroyObject (goBullet);
					Bullet.Remove (goBullet);
				} 
			}
		}
	}
		/*if (!autoPlay) {
			//MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}*/


}
