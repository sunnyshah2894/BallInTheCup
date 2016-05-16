using UnityEngine;
using System.Collections;

public class TakeUserInput : MonoBehaviour {

	private Rigidbody2D rigidBody ; 
	private Touch touch ;
	private bool hasUserTouched ; 

	private Camera camera ;
	private Vector3 myball ;

	private float power = 5f ;

	private Vector2 myTouchPos ;
	private Vector2 ballVec2dPos ;
	private Vector2 difference ; 
	private double maxMagnitude ;

	void Start(){

		rigidBody = GetComponent<Rigidbody2D>() ; 
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() ; 
		hasUserTouched = false ;
		maxMagnitude = new Vector2( Screen.width , Screen.height ).magnitude ; 

	}

	// Update is called once per frame
	void Update () {

		myball = camera.WorldToScreenPoint( rigidBody.position );

		if (Input.touchCount > 0) {

			hasUserTouched = true ; 
			touch = Input.GetTouch(0);

			if( touch.phase == TouchPhase.Ended ){

				rigidBody.isKinematic = false ;
				myTouchPos = new Vector2( touch.position.x , touch.position.y ) ;
				ballVec2dPos = new Vector2( myball.x , myball.y ) ;
				difference = ( myTouchPos - ballVec2dPos ) ; 
				float scaleFactor = (float)((difference.magnitude)/maxMagnitude)*power ; 
				rigidBody.AddForce( difference*scaleFactor ) ; 

			}


		}


	}

	void OnGUI(){
		if(hasUserTouched && false){
			print("new ");
			var centeredStyle = GUI.skin.GetStyle("Label");
			centeredStyle.alignment = TextAnchor.UpperCenter;
			GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-25, 100, 50),""+touch.position.x+" , " + touch.position.y + " ball : "+ myball.x +","+ myball.y );

		}
	}
}
