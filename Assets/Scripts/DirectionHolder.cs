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


		// カメラリセット　ここから ---------------
		// local reset
//		this.targetCamera.transform.localPosition = Vector3.zero;
//		this.targetCamera.transform.localRotation = Quaternion.identity;
//		this.targetCamera.transform.localScale = Vector3.one;

		// world reset
//		this.targetCamera.transform.position = Vector3.zero;
//		this.targetCamera.transform.rotation = Quaternion.identity;


		// カメラを追従するようにする
//		var q = Input.gyro.attitude;
//		var newQ = new Quaternion(-q.x, -q.z, -q.y, q.w);

		Quaternion rotRH = Input.gyro.attitude;

		float diffX = cameraX - rotRH.x;
		float diffY = cameraY - rotRH.z;
		float diffZ = cameraZ - rotRH.y;

		Debug.Log ("X: " + diffX + " / Y: " + diffY + " / Z: " + diffZ);
//		Debug.Log ("スマホ:X: " + rotRH.x);
//		Debug.Log ("スマホ:Y: " + rotRH.y);
//		Debug.Log ("スマホ:Z: " + rotRH.z);
//		Debug.Log ("スマホ:W: " + rotRH.w);
//		Debug.Log ("カメラ:X: " + rotRH.x);
//		Debug.Log ("カメラ:Y: " + rotRH.y);
//		Debug.Log ("カメラ:Z: " + rotRH.z);
//		Debug.Log ("カメラ:W: " + rotRH.w);



		Quaternion rot = new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w) * Quaternion.Euler(90f, 0f, 0f);

//		this.transform.localRotation = rot;
		// ワールド座標を変えちゃってみる
		targetCamera.transform.rotation = rot;



		// カメラリセット　ここまで ------------------

		// カメラの正面にオブジェクト移動
//		this.transform.position = new Vector3(-rotRH.x, -rotRH.z, -rotRH.y);




		//カメラの方向を向くようにする。
		this.transform.LookAt(this.targetCamera.transform.position);    
//		Debug.Log ("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
//		Debug.Log (cameraX);
//		Debug.Log (cameraY);
//		Debug.Log (cameraZ);
//		Debug.Log ("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");

//		Vector3 pos = new Vector3(cameraX, cameraY - 5, cameraZ - 30);
		Vector3 pos = new Vector3(cameraX, cameraY - 30, cameraZ - 30);
//		Vector3 pos = new Vector3(cameraX, cameraY, cameraZ - 30);
		this.transform.position = pos;


	}


}