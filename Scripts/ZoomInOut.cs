using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ZoomInOut : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Sequence run = DOTween.Sequence() ; 
		Tween rot = this.transform.DOScale(1.3f,1f).SetEase(Ease.Linear) ;
		Tween rot2 = this.transform.DOScale(1f,1f).SetEase(Ease.Linear) ;
		run.Append(rot).Append(rot2).SetLoops(-1) ; 

	}
	

}
