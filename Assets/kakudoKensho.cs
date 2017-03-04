using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakudoKensho : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ($"({this.transform.localEulerAngles.x},{this.transform.localEulerAngles.y},{this.transform.localEulerAngles.z})");
	}
}
