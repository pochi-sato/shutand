using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class testScript : MonoBehaviour, ITrackableEventHandler
{
    public int y = 1;
    string z = "safa";
    private TrackableBehaviour mTrackableBehaviour;

    // Use this for initialization
	void Start ()
	{
	    mTrackableBehaviour = GetComponent<TrackableBehaviour>();
	    if (mTrackableBehaviour)
	    {
	        mTrackableBehaviour.RegisterTrackableEventHandler(this);
	    }
	    Debug.Log("start----------------------------------------");
	}
	
	// Update is called once per frame
	void Update () {
//	    Debug.Log("update----------------------------------------");
	}

    private void OnTrackingFound()
    {
        Debug.Log("found!!!---------------------------");

    }

    private void OnTrackingLost()
    {
        Debug.Log("lost!!!---------------------------");

    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }
}
