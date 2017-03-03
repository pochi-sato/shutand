using UnityEngine;
using System.Collections;

public enum ARMode
{
	Tracking,
	Untracking
}	
public delegate void ChangeARModeEvent (ARMode currentARMode);
public delegate void ChangeAnimationEvent (string animationName);


public class GameController : MonoBehaviour
{

	// 表情・ポーズのイベント
	public event ChangeAnimationEvent changeanimationE;
	public event ChangeAnimationEvent changeFaceE;
	
	public string currentFace;	// 現在の表情
	public string currentPose;	// 現在のポーズ
	
	// 表情の変更
	public void ChangeFace (string faceName)
	{
		currentFace = faceName;
		if (changeFaceE != null) {
			changeFaceE (currentFace);
		}
	}

	// ポーズの変更
	public void ChangePose (string animationName)
	{
		currentPose = animationName;
		if (changeanimationE != null) {
			changeanimationE (animationName);
		}
	}

	private static GameController m_instance;
	public static GameController Instance {
		get {
			// m_instanceがまだ登録されていない場合、シーン内のInstanceを探して割り当てる
			if (m_instance == null) {
				m_instance = FindObjectOfType<GameController> ();
			}
			return m_instance;
		}
	}
	
	void Awake ()
	{
		// 自分以外のGameControllerが既に存在するならば、自身を削除する
		if (this != Instance)
			Destroy (this);
	}

	// 値を変更した際に呼び出すイベント
	public event ChangeARModeEvent changeARModeE;
	// 現在のARMode
	public ARMode currentARMode = ARMode.Untracking;
	// ARモード変更通知を申請
	public void ChangeARMode (ARMode newARMode)
	{
		currentARMode = newARMode;
		if (changeARModeE != null) {
			changeARModeE (newARMode);
		}
	}

}
