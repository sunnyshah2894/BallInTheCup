using UnityEngine;
using System.Collections;

public class MyCanvas{

	public static GameObject myCanvasObject = GameObject.FindGameObjectWithTag( "MyCanvas" ) ; 
	public static RectTransform canvasRectTransform = myCanvasObject.transform.GetComponent<RectTransform> () ; 
	public static float canvasWidth = canvasRectTransform.rect.width ; 
	public static float canvasHeight = canvasRectTransform.rect.height ; 
	public static GameObject glass = GameObject.FindGameObjectWithTag( "Glass" );

}