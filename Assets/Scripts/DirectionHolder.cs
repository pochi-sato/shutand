using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionHolder : MonoBehaviour {

	public Camera targetCamera;

	// Use this for initialization
	void Start () {
		//対象のカメラが指定されない場合にはMainCameraを対象とします。
		if (this.targetCamera == null)
			targetCamera = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {
		//カメラの方向を向くようにする。
		this.transform.LookAt(this.targetCamera.transform.position);    
	}
}