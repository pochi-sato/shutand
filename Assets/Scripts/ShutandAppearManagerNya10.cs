using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShutandAppearManagerNya10 : MonoBehaviour, ITrackableEventHandler
{

	private string trackableName = "nya10";
    private TrackableBehaviour mTrackableBehaviour;
	public GameObject targetObj;


    // Use this for initialization
	void Start ()
	{
	    mTrackableBehaviour = GetComponent<TrackableBehaviour>();
	    if (mTrackableBehaviour)
	    {
	        mTrackableBehaviour.RegisterTrackableEventHandler(this);
	    }
	    Debug.Log("start----------------------------------------1");
		Debug.Log(transform.name); //名前
		Debug.Log(transform.tag); //タグ
	    Debug.Log("start----------------------------------------2");


		targetObj.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
//	    Debug.Log("update----------------------------------------");
	}

    private void OnTrackingFound()
    {
        Debug.Log("found きたよ、対象のやつが!!!---------------------------1");
		Debug.Log(trackableName);
        Debug.Log("found!!!---------------------------2");
		targetObj.SetActive (true);
    }

    private void OnTrackingLost()
    {
        Debug.Log("lost きたよ、対象のやつが!!!---------------------------1");
		Debug.Log(trackableName);
        Debug.Log("lost!!!---------------------------2");
		targetObj.SetActive (false);
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
//			if (IsMyTarget ()) {
				OnTrackingFound();
//			}
        }
        else
        {
//			if (IsMyTarget ()) {
                OnTrackingLost();
//			}
        }
    }

	// 対象のマーカーかしらべるお
//	private bool IsMyTarget()
//	{
//
//
//		StateManager sm = TrackerManager.Instance.GetStateManager();
//		IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();
//
//		foreach(TrackableBehaviour tb in tbs)
//		{
//			string name = tb.TrackableName;
//			if (tb.GetType().Equals(TrackableType.IMAGE_TARGET))
//			{
//				ImageTarget it = tb.Trackable as ImageTarget;
//				Vector2 size = it.GetSize ();
//
//				Debug.Log ("Active image target:" + name + "  -size: " + size.x + ", " + size.y);
//			}
//		}
//
//
//
//
////		IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
////
////		foreach (TrackableBehaviour tb in tbs) {
////			Debug.Log ("============vvvvvvvvvvvvv trackablename");
////			Debug.Log (tb.TrackableName);
////			Debug.Log ("============^^^^^^^^^^^^^ trackablename");
////			if (tb.TrackableName.Equals (trackableName)) {
////
////				return true;
////			}
////		}
////		return false;
//	}
}
