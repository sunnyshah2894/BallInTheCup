using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class MyEventManager : MonoBehaviour {

	public void StartCurrentLevel(){

		/*var blur = new BlurTransition()
		{
			nextScene = 1,
			duration = 1.0f,
			blurMax = 0.01f
		};
		TransitionKit.instance.transitionWithDelegate( blur );
		*/
		int currentLevel = PlayerPrefs.GetInt( MyPlayerPreferences.CURRENT_LEVEL_STRING  , 1 ) ;
		GoToScene( currentLevel + MyPlayerPreferences.LEVEL_SCREEN_OFFSET );

	}
	public void PlayAgain(){

		int currentSceneNumber = SceneManager.GetActiveScene().buildIndex ; 
		GoToScene( currentSceneNumber ) ; 

	}

	public void rateUs(){



	}

	public void settingsMenu(){



	}

	public void loadLevelChoser(){

		GoToScene( MyPlayerPreferences.LEVEL_CHOOSER_INDEX );

	}

	public void backToMainMenu(){

		GoToScene( MyPlayerPreferences.MENU_SCREEN_INDEX ) ;

	}

	public void OnLevelButtonClick( ){

		int levelSelected = Int32.Parse(EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text) ;
		print(levelSelected) ; 
		GoToScene( levelSelected + 1 ) ;

	}

	void GoToScene(int sceneSelected){

		var fishEye = new FishEyeTransition()
		{
			nextScene = sceneSelected  ,
			duration = 1.0f,
			size = 0.2f,
			zoom = 100.0f,
			colorSeparation = 0.1f
		};
		TransitionKit.instance.transitionWithDelegate( fishEye );

	}

}
