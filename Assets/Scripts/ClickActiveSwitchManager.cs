﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using GodTouches;

public class ClickActiveSwitchManager : MonoBehaviour {

	public GameObject targetObj;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Debug.Log (GodTouch.GetPhase());
		if (GodTouch.GetPhase() == GodPhase.Ended) {
			Debug.Log ("clicked!");
			StartCoroutine(postMessage());
			Debug.Log ("posted!!!");
			if (targetObj.activeSelf) {
				targetObj.SetActive (false);
			} else {
				targetObj.SetActive (true);
			}
		}
	}

	IEnumerator postMessage(){
		Debug.Log ("========postMesaage=======");
		string message = "@tacknyan が会いたがってるよ！";
		const string webhookUrl = "https://hooks.slack.com/services/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";					 
		// フォームを作る
		WWWForm form = new WWWForm();
		string payload = $"{{\"text\": \"{message}\"}}";
		form.AddField("payload", payload);
		Debug.Log(payload);

		// リクエストを送る

		using(UnityWebRequest www = UnityWebRequest.Post (webhookUrl, form)){
			yield return www.Send();
			Debug.Log("Requested!");
			if (www.isError) {
				Debug.Log(www.error);
			} else {
				Debug.Log("Form upload complete!");
			}
		}	

	}
}