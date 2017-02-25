using UnityEngine;
using System.Collections;

public class ClickCreateObjectManager : MonoBehaviour {

	public GameObject objSphere;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("mouse 0")) {
			GameObject.Instantiate (objSphere, new Vector3 (0, 0, 10), new Quaternion ());
		}
	}
}