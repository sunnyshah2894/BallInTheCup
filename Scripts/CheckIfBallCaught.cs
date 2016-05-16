using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class CheckIfBallCaught : MonoBehaviour {

	private GameObject ball;

	private bool HasBallEntered ; 
	private long timeEntered ;

	void Start(){
		
		ball = GameObject.FindGameObjectWithTag( "Player" );
		HasBallEntered = false ; 
		timeEntered = 0 ;
			
	}

	void OnTriggerEnter2D( Collider2D otherObj ){

		if( otherObj.tag == "Player" ){

			HasBallEntered = true ;

		}
			
	}

	void OnTriggerExit2D( Collider2D otherObj ){

		if( otherObj.tag == "Player" ){

			HasBallEntered = false ;
			timeEntered = 0 ;

		}

	}

	void FixedUpdate(){

		if( HasBallEntered )timeEntered++ ; 

	}


	void OnGUI(){

		if( HasBallEntered ){

			var centeredStyle = GUI.skin.GetStyle("Label");
			centeredStyle.alignment = TextAnchor.UpperCenter;
			centeredStyle.fontSize = 30 ; 

			if( timeEntered < 150 )
				GUI.Label(new Rect(Screen.width/2-50, Screen.height/4, 100, 50),""+ (timeEntered/50 + 1) );
			
			if( timeEntered > 150 ){
				
				/*var fishEye = new FishEyeTransition()
				{
					nextScene = SceneManager.GetActiveScene().buildIndex ,
					duration = 2.0f,
					size = 0.2f,
					zoom = 100.0f,
					colorSeparation = 0.1f
				};
				TransitionKit.instance.transitionWithDelegate( fishEye );
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) {
					
					if( ( !go.name.Equals("levelComplete") || !go.transform.parent.name.Equals("levelComplete") ) )
					{
						go.isStatic = true ;
						print(go.name) ; 
					}
				}*/

				//Time.timeScale = 0.0f;



				LevelCompletePanel.MoveInPanel( 3 , 3 ) ; 



			}

		}

	}

}
