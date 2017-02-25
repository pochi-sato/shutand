using UnityEngine;
using System.Collections;

public class ClickActiveSwitchManager : MonoBehaviour {

	public GameObject targetObj;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("mouse 0")) {
			if (targetObj.activeSelf) {
				targetObj.SetActive (false);
			} else {
				targetObj.SetActive (true);
			}
		}
	}
}