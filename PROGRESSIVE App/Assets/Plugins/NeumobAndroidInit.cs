using UnityEngine;
using System.Collections;

public class NeumobAndroidInit : MonoBehaviour {

	public string ClientKey = "your-neumob-client-key";

	void Awake () {
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		AndroidJavaRunnable onInitCompleteRunnable = new AndroidJavaRunnable(CallInitComplete);
		NeumobAndroid.Initialize(ClientKey, onInitCompleteRunnable);
		Destroy(this);
		#endif
	}

	void CallInitComplete() {
		OnInitComplete (NeumobAndroid.Initialized (), NeumobAndroid.Accelerated ());
	}

	// To check that Neumob is initialized and whether an app session is being accelerated, 
	// you can customize the OnInitComplete method below and check the parameters.
	//
	// initialized - indicates whether Neumob is enabled and ready to accelerate your network requests.
	// accelerated - indicates whether Neumob is currently accelerating your requests. 
	//				 You may configure whether or not Neumob is accelerated by adjusting the % accelerated 
	//				 slider through the portal (click the settings button for the app version on your app 
	//				 details page). If you plan to A / B test accelerated vs unaccelerated Neumob sessions, 
	//				 we recommend using the accelerated parameter the Callback function. Please note that 
	//			     accelerated is sticky- meaning a user who is accelerated will remain accelerated until 
	//				 the % accelerated slider value is changed.
	//
	// Example of how you might verify Neumob initialization:
	//
	// void OnInitComplete(bool initialized, bool accelerated) {
	// 	if (initialized)
	// 	{
	// 		// Neumob is ON.
	// 		// ex. Analytics.LogCustomDimension(Dimension.ACCELERATION, accelerated);
	// 			...
	// 	} else
	// 	{
	// 		// Neumob is OFF. Change log settings for more details.
	// 			...
	// 		}
	// }
	//
	// The method OnInitComplete but you are free to pass in your own custom Runnable to NeumobAndroid.Initialize()
	// in the Awake() method above. You should only fetch the initialized and accelerated parameters in runnable
	// parameter as Neumob initialization may be asynchronous.
	void OnInitComplete(bool initialized, bool accelerated) {
		Debug.Log("Neumob initialized: " + initialized + " Neumob accelerated: " + accelerated);
    }
}
