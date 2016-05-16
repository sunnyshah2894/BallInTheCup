using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Animator contentPanel;

	public void ToggleMenu() {
		bool isHidden = contentPanel.GetBool("isHidden");
		contentPanel.SetBool("isHidden", !isHidden);
	}

}
