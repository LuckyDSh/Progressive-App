using UnityEngine;
using System.Runtime.InteropServices;

public static class NeumobAndroid
{

	private static readonly string NEUMOB_API_CLASS = "com.neumob.externals.UnityAPI";

	// Logging levels -  See 'setLogLevel' function for more details
	public static int LOG_DETAIL  = 2;
	public static int LOG_WARNING = 3;
	public static int LOG_ERROR   = 5;
	public static int LOG_NONE    = 15;

	#if (UNITY_ANDROID && !UNITY_EDITOR)
	private static AndroidJavaClass mNeumobPlugin = null;
	#endif

	/// Use initialize in order to setup the Neumob library. After successful initialization,
	// your network calls will automatically use Neumob's cloud and optimizations!
	public static void Initialize (string clientKey, AndroidJavaRunnable runnable)
	{
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		if (mNeumobPlugin == null) {
			mNeumobPlugin = new AndroidJavaClass (NEUMOB_API_CLASS);
		}
		using (var unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
			using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject> ("currentActivity")) {
				mNeumobPlugin.CallStatic("initialize", currentActivity, clientKey, runnable);
			}
		}
		#endif
	}

	// Initialized returns a boolean indicating Neumob is enabled and ready to accelerate
	// your network requests. Client must be authenticated before it can be initialized.
	public static bool Initialized ()
	{
		bool initialized = false;
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		if (mNeumobPlugin == null) {
			return initialized;
		}
		initialized = mNeumobPlugin.CallStatic<bool>("initialized");
		#endif
		return initialized;
	}

	// Accelerated will return Neumob is currently accelerating network requests. If Neumob
	// is not initialized, then accelerated will return false.
	public static bool Accelerated ()
	{
		bool accelerated = false;
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		if (mNeumobPlugin == null) {
			return accelerated;
		}
		accelerated = mNeumobPlugin.CallStatic<bool>("accelerated");
		#endif
		return accelerated;
	}

	// By default, Neumob logs messages that may to useful to verify Neumob initialization. To disable or tune what
	// log messages are printed use the *setLogLevel* API. To retrieve the current log level use the *logLevel* API.

	// (int) logLevel - Log level verbosity for Neumob. Use the values in the object com.neumob.LogLevel.
	//                  The logging levels available in order of verbosity are as follows
	//                  1. LOG_DETAIL  - (Default) Print all messages
	//                  2. LOG_WARNING - Only print warning and error messages
	//                  3. LOG_ERROR   - Only print error messages
	//                  4. LOG_NONE    - Turn off all Neumob log messages
	//
	// Usage: NeumobAndroid.SetLogLevel(NeumobAndroid.LOG_NONE);
	public static void SetLogLevel (int logLevel)
	{
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		if (mNeumobPlugin == null) {
			mNeumobPlugin = new AndroidJavaClass (NEUMOB_API_CLASS);
		}
		mNeumobPlugin.CallStatic("setLogLevel", logLevel);
		#endif
	}

	// Sends the Key Performance Index (KPI) attributes to metrics endpoint.
	//
	// key - String object representing KPI key.
	// value - String object representing KPI value.
	public static void ReportKPIMetric (string key, string value)
	{
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		if (mNeumobPlugin == null) {
			mNeumobPlugin = new AndroidJavaClass (NEUMOB_API_CLASS);
		}
		mNeumobPlugin.CallStatic("reportKPIMetrics", key, value);
		#endif
	}
}