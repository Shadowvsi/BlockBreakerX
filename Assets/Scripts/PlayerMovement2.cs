using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Collections;


public class PlayerMovement2 : MonoBehaviour {
	public float speed = 200f;
	public GameObject BulletPrefab;
	private List<GameObject> Bullet = new List<GameObject> ();

	private float BulletVelocity = 200;

	// Use this for initialization
	void Start () {
		
	}


	void OnCollisionEnter(Collision hit){
		if (hit.gameObject.tag == "enemy") {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.Space)) {
			GameObject bullet = (GameObject)Instantiate (BulletPrefab, transform.position, Quaternion.identity);
			Bullet.Add (bullet);
		}

		for (int i = 0; i < Bullet.Count; i++) {
		
			GameObject goBullet = Bullet [i];
			if (goBullet != null)
			
			{
				goBullet.transform.transform.Translate (new Vector3 (0, 1) * Time.deltaTime * BulletVelocity);

				Vector3 bulletpos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletpos.y >= Screen.height || bulletpos.y <= 0) {
					DestroyObject (goBullet);
					Bullet.Remove (goBullet);
				} 

			}

		}
	}



	


}
