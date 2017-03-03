using UnityEngine;
using System.Collections;

public class UnitychanController : MonoBehaviour
{
	public ARMode arMode;
	
	void Start ()
	{
		var gameController = GameController.Instance;
		gameController.changeARModeE += HandlechangeARMode;

		gameController.changeFaceE += HandlechangeFace;
		gameController.changeanimationE += HandlechangePose;

		GetComponent<Animator> ().SetLayerWeight (1, 1);
	}
	
	void HandlechangeARMode (ARMode currentARMode)
	{
		bool isActive = (currentARMode == arMode);
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
		foreach (Renderer component in rendererComponents) {
			component.enabled = isActive;
		}
	}

	void HandlechangeFace (string faceName)
	{
		GetComponent<Animator> ().CrossFade (faceName, 0.3f);
	}
	
	void HandlechangePose (string poseName)
	{
		GetComponent<Animator> ().CrossFade (poseName, 10);
	}

}