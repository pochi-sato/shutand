using System.Collections;
using UnityEngine;

public class MoveTransformPosition : MonoBehaviour
{
	private Camera targetCamera;
	private Vector3 prePosition;
	
	// 初回に1回呼ばれるメソッド
	void Start ()
	{
		targetCamera = Camera.main;
	}
	
	void Update ()
	{
		if (Input.GetMouseButton (1)) {

			// 右クリックもしくは二本指スワイプで移動
			
			// 　タップした画面のワールド座標を取得
			Vector3 cameraDiff = new Vector3 (0, 0, transform.localPosition.z);
			Vector3 newPosition = targetCamera.ScreenToWorldPoint (Input.mousePosition + cameraDiff);
			
			
			// 座標を上書き
			transform.position = newPosition;
			
			// 前回の座標をクリア
			prePosition = Vector3.zero;
			
		} else if (Input.GetMouseButton (0)) {
			// 左ドラッグもしくは一本指スワイプ
			if (prePosition != Vector3.zero) {
				
				// 前回の座標と今回の指の位置の相対値を取得
				Vector3 diff = prePosition - Input.mousePosition;
				float rotationSpeed = Time.deltaTime * 3;
				
				// モデルを回転
				transform.RotateAround (transform.position, targetCamera.transform.right * -1, diff.y * rotationSpeed);
				transform.RotateAround (transform.position, targetCamera.transform.up, diff.x * rotationSpeed);
			}
			
			// 前回の座標をキャッシュ
			prePosition = Input.mousePosition;
		} else {
			// 前回の座標をクリア
			prePosition = Vector3.zero;
		}
	}
}