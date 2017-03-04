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
		float cameraX = this.targetCamera.transform.position.x;
		float cameraY = this.targetCamera.transform.position.y;
		float cameraZ = this.targetCamera.transform.position.z;


		//カメラの方向を向くようにする。
		this.transform.LookAt(this.targetCamera.transform.position);    
		Debug.Log ("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
		Debug.Log (cameraX);
		Debug.Log (cameraY);
		Debug.Log (cameraZ);
		Debug.Log ("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
		Vector3 pos = new Vector3(cameraX - 10, cameraY - 10, cameraZ - 10);
		this.transform.position = pos;
	}
}