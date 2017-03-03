using UnityEngine;
using System.Collections;

public class ClickComentManager : MonoBehaviour {

	public GameObject targetObj;
	protected int count = 0;
	GameObject[] firsts;
	GameObject[] seconds;
	GameObject[] thirds;
	GameObject[] fourths;

	// Use this for initialization
	void Start () {
		firsts = GameObject.FindGameObjectsWithTag("1stAction");
		seconds = GameObject.FindGameObjectsWithTag("2ndAction");
		thirds = GameObject.FindGameObjectsWithTag("3rdAction");
		fourths = GameObject.FindGameObjectsWithTag("4thAction");
		foreach (GameObject first in firsts) {
			first.SetActive (false);
		}
		foreach (GameObject second in seconds) {
			second.SetActive (false);
		}
		foreach (GameObject third in thirds) {
			third.SetActive (false);
		}
		foreach (GameObject fourth in fourths) {
			fourth.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("mouse 0")) {
			switch (count) {
			case 0:
				Debug.Log("----------------------------1");
				foreach (GameObject first in firsts) {
					Debug.Log("---------------------------- foreach");
					first.SetActive (true);
				}

				break;
			case 1:
				Debug.Log ("----------------------------2");
				foreach (GameObject first in firsts) {
					first.SetActive (false);
				}

				foreach (GameObject second in seconds) {
					second.SetActive (true);
				}
				break;
			case 2:
				Debug.Log ("----------------------------3");
				foreach (GameObject second in seconds) {
					second.SetActive (false);
				}

				foreach (GameObject third in thirds) {
					third.SetActive (true);
				}
				break;
			case 3:
				Debug.Log ("----------------------------4");
				foreach (GameObject third in thirds) {
					third.SetActive (false);
				}

				foreach (GameObject fourth in fourths) {
					fourth.SetActive (true);
				}
				break;
			default:
				Debug.Log ("----------------------------df");
				foreach (GameObject first in firsts) {
					first.SetActive (false);
				}
				foreach (GameObject second in seconds) {
					second.SetActive (false);
				}
				foreach (GameObject third in thirds) {
					third.SetActive (false);
				}
				foreach (GameObject fourth in fourths) {
					fourth.SetActive (false);
				}
				break;
			}

			count = count + 1;

		}
	}
}