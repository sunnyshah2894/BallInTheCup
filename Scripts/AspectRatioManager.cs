using UnityEngine;
using System.Collections;

public class AspectRatioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Object [] objs = FindObjectsOfType (typeof(GameObject));
		print( Screen.height + " , " + Screen.width ) ; 
		double ar = Screen.width / Screen.height ; 

		foreach( GameObject obj in objs ){

			Vector3 myLocation = obj.transform.localPosition ; 
			//print(obj.name + " :: " + myLocation) ; 
			

		}

	}
	

}
