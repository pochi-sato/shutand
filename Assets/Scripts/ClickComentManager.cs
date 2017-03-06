using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;

public class ClickComentManager : MonoBehaviour {

	public GameObject targetObj;
	protected int count = 0;
	GameObject[] firsts;
	GameObject[] seconds;
	GameObject[] thirds;
	GameObject[] fourths;

	// unun
	DateTime sendTime;

	void Change(GameObject[] objs, bool nextStatus) {
		foreach (GameObject obj in objs) {
			obj.SetActive (nextStatus);
		}
	}

	// Use this for initialization
	void Start () {
		// unun
		sendTime = DateTime.Now;


		firsts = GameObject.FindGameObjectsWithTag("1stAction");
		seconds = GameObject.FindGameObjectsWithTag("2ndAction");
		thirds = GameObject.FindGameObjectsWithTag("3rdAction");
		fourths = GameObject.FindGameObjectsWithTag("4thAction");
		foreach (GameObject first in firsts) {
			first.SetActive (false);
		}
		foreach (GameObject second in seconds) {
			second.SetActive (false);
		}
		foreach (GameObject third in thirds) {
			third.SetActive (false);
		}
		foreach (GameObject fourth in fourths) {
			fourth.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {

		if(sendTime.AddSeconds(1.5).CompareTo(DateTime.Now) < 0){
			string s = $"{Input.gyro.rotationRate.x},{Input.gyro.rotationRate.y},{Input.gyro.rotationRate.z}";
//			Debug.Log(s);
			if (Input.gyro.rotationRate.x < -2.0) {
//				Debug.Log ("00000000000000000000000000000000000000000000000000 YEEEEESSS!!!");


				// ここからununの内容処理

				switch (count) {
				case 0:
//					Debug.Log ("----------------------------1");
					Change (firsts, true);
					break;
				case 1:
//					Debug.Log ("----------------------------2");
					Change (firsts, false);
					Change (seconds, true);
					break;
				case 2:
//					Debug.Log ("----------------------------3");
					Change (seconds, false);
					Change (thirds, true);
					break;
				case 3:
//					Debug.Log ("----------------------------4");
					Change (thirds, false);
					Change (fourths, true);
					StartCoroutine(postMessage());
					break;
				case 4:
//					Debug.Log ("----------------------------5");
					Change (fourths, false);
					count = 0;
					break;
				default:
//					Debug.Log ("----------------------------df");
					Change (firsts, false);
					Change (seconds, false);
					Change (thirds, false);
					Change (fourths, false);

					break;
				}
				count = count + 1;

				// ここまでununの内容処理


				// 後処理
				sendTime = DateTime.Now;

			} else if (Input.gyro.rotationRate.y > 1.8) {
				Debug.Log ("いやだお");
			}

		}





//		if (Input.GetKey ("mouse 0")) {
//			switch (count) {
//			case 0:
//				Debug.Log ("----------------------------1");
//				Change (firsts, true);
//				break;
//			case 1:
//				Debug.Log ("----------------------------2");
//				Change (firsts, false);
//				Change (seconds, true);
//				break;
//			case 2:
//				Debug.Log ("----------------------------3");
//				Change (seconds, false);
//				Change (thirds, true);
//				break;
//			case 3:
//				Debug.Log ("----------------------------4");
//				Change (thirds, false);
//				Change (fourths, true);
//				StartCoroutine(postMessage());
//				break;
//			case 4:
//				Debug.Log ("----------------------------5");
//				Change (fourths, false);
//				count = 0;
//				break;
//			default:
//				Debug.Log ("----------------------------df");
//				Change (firsts, false);
//				Change (seconds, false);
//				Change (thirds, false);
//				Change (fourths, false);
//
//				break;
//			}
//
//			count = count + 1;
//
//		}
	}

	IEnumerator postMessage(){
//		Debug.Log ("========postMesaage=======");
		string message = "ご主人様と話したがってる人がいるよ！あとで確認してね！";
		const string webhookUrl = "https://hooks.slack.com/services/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";					 
		// フォームを作る
		WWWForm form = new WWWForm();
		string payload = $"{{\"text\": \"{message}\"}}";
		form.AddField("payload", payload);
//		Debug.Log(payload);

		// リクエストを送る

		using(UnityWebRequest www = UnityWebRequest.Post (webhookUrl, form)){
			yield return www.Send();
//			Debug.Log("Requested!");
			if (www.isError) {
				Debug.Log(www.error);
			} else {
				Debug.Log("Form upload complete!");
			}
		}
	}	
}