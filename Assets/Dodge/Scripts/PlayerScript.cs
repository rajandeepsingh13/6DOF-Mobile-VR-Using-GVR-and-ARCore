using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public Transform ARMainCamera;
    public GameObject teapot;

    private GameObject Environment;
    private bool isEnvironmentKnown = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectables")
        {
            GameController.playerScore++;
            other.transform.localPosition = new Vector3(Random.Range(-4.32f, 4.37f), Random.Range(0f, 1f), Random.Range(-4.4f, 4.54f));
            if (!isEnvironmentKnown)
            {
                findEnvironment();
            }
            GameObject TeaPotInstance = (GameObject)Instantiate(teapot, new Vector3(0f,0f,0f), Quaternion.identity,Environment.transform);
            //_ShowAndroidToastMessage("created");
            TeaPotInstance.transform.localPosition = new Vector3(Random.Range(-3.85f,3.89f),Random.Range(2f,5f),Random.Range(-3.95f,3.95f));
            TeaPotInstance.GetComponent<LookAt>().Rectile_Camera = ARMainCamera;
        } else if (other.tag=="TeaBullet") {
            GameController.playerScore--;
            Destroy(other.gameObject);
        }
    }

    private void findEnvironment()
    {
        Environment=GameObject.FindGameObjectWithTag("Environment");
        isEnvironmentKnown = true;
    }

    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                    message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
