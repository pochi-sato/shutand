using System.Collections;
using UnityEngine;

public class GUIController : MonoBehaviour
{
	private GameController gameController = null;
	public float defaultHeight = 640;

	void Start ()
	{
		gameController = GameController.Instance;
	}
	
	void OnGUI ()
	{
		GUIUtility.ScaleAroundPivot (
			new Vector2 (Screen.height / defaultHeight, 
		             Screen.height / defaultHeight), 
			Vector2.zero);


		// ポーズを変更する
		if (GUILayout.Button ("POSE01")) {
			gameController.ChangePose ("POSE01");
		}
		if (GUILayout.Button ("POSE12")) {
			gameController.ChangePose ("POSE12");
		}
		if (GUILayout.Button ("POSE30")) {
			gameController.ChangePose ("POSE30");
		}
		
		GUILayout.Space (15);
		
		// 表情を変更する
		if (GUILayout.Button ("SMILE2")) {
			gameController.ChangeFace ("smile2@unitychan");
		}
		if (GUILayout.Button ("ANG2")) {
			gameController.ChangeFace ("angry2@unitychan");
		}
		if (GUILayout.Button ("SAP")) {
			gameController.ChangeFace ("sap@unitychan");
		}
		if (GUILayout.Button ("DIS1")) {
			gameController.ChangeFace ("disstract1@unitychan");
		}
		
		GUILayout.Space (15);

		if (GUILayout.Button ("AF")) {
			CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
		}
	}
}