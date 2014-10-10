using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GUIText winText;
	private int count;
	private string countText;
	private bool has_won;
	
	void Start() { 
		count = 0;
		has_won = false;
		winText.text = "";
	}

	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,120,120), getCountText());
	
		if (has_won) {
			if (GUI.Button (new Rect (30, 90, 80, 30), "Play Again")) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void FixedUpdate() { 
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movment = new Vector3 (moveHorizontal, 0, moveVertical);

		rigidbody.AddForce (movment * speed *Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) { 
		if (other.gameObject.tag == "Pickup") { 
			other.gameObject.SetActive (false);
			count++;
			doWinCheck ();
		}
	}

	string getCountText() { 
		countText = "RollaBall\n\n" +
					"Count: " + count.ToString () + "\n" +
					"Time:";

		return countText;
	}

	void doWinCheck(){ 
		if (count == 12) { 
			has_won = true;
			winText.text = "You Win!!";
		}
	}
}
