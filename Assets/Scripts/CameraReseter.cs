using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReseter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetLocal(Transform transform)
	{
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		transform.localScale = Vector3.one;
	}

	public void ResetWorld(Transform transform)
	{
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
	}

}
