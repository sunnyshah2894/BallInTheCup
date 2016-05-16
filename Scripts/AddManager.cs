using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.

public class AddManager : MonoBehaviour
{
	
	public string gameId = "1064628"; // Set this value from the inspector.
	public bool enableTestMode = true;

	void Start ()
	{
		
		if (Advertisement.isSupported) { // If runtime platform is supported...
			Advertisement.Initialize(gameId, enableTestMode); // ...initialize.
		}

	}

	public void showAd(){

		// Wait until Unity Ads is initialized,
		//  and the default ad placement is ready.
		if (!Advertisement.isInitialized || !Advertisement.IsReady()) {

			print( "Waiting for ads!" ) ; 

		}

		// Show the default ad placement.
		Advertisement.Show();

	}

}