using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARkakudo : MonoBehaviour {

	public Transform targetObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("{targetObj.rotation.eulerAngles.x}");
	}
}
