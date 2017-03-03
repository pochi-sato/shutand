using UnityEngine;
using System.Collections;

public class ClickComentManager : MonoBehaviour {

	public GameObject targetObj;
	protected int count = 0;
	GameObject[] firsts;
	GameObject[] seconds;
	GameObject[] thirds;
	GameObject[] fourths;

	void Change(GameObject[] objs, bool nextStatus) {
		foreach (GameObject obj in objs) {
			obj.SetActive (nextStatus);
		}
	}

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
				Debug.Log ("----------------------------1");
				Change (firsts, true);
				break;
			case 1:
				Debug.Log ("----------------------------2");
				Change (firsts, false);
				Change (seconds, true);
				break;
			case 2:
				Debug.Log ("----------------------------3");
				Change (seconds, false);
				Change (thirds, true);
				break;
			case 3:
				Debug.Log ("----------------------------4");
				Change (thirds, false);
				Change (fourths, true);
				break;
			default:
				Debug.Log ("----------------------------df");
				Change (firsts, false);
				Change (seconds, false);
				Change (thirds, false);
				Change (fourths, false);

				break;
			}

			count = count + 1;

		}
	}
}