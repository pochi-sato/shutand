using UnityEngine;
using System.Collections;

public class ARModelEventHandler : MonoBehaviour, ITrackableEventHandler
{
	private GameController gameController;
	
	void Start ()
	{
		// gameControllerへの参照を取得
		gameController = GameController.Instance;
		
		// マーカーがトラッキングされた時のイベントを登録
		var mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}
	
	// トラッキングの状態が切り替わった時のイベント
	public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		switch (newStatus) {
		case TrackableBehaviour.Status.NOT_FOUND:
		case TrackableBehaviour.Status.DETECTED:
		case TrackableBehaviour.Status.EXTENDED_TRACKED:
			OnTrackLost ();
			break;
		default:
			OnTrackFind ();
			break;
		}
	}
	
	// ARモードを非検出へ変更
	void OnTrackFind ()
	{
		gameController.ChangeARMode (ARMode.Tracking);
	}
	
	// ARモードを検出へ変更
	void OnTrackLost ()
	{
		gameController.ChangeARMode (ARMode.Untracking);
	}
}
