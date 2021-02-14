using System.Collections;
using UnityEngine;
using UnityEngine.UI;




//---------------------------------------------------------------------------------
// Author		: Ang Wei Jie
// Date  		: 14/12/2020
// Modified By	: Ang Wei Jie
// Modified Date: 14/12/2020
// Description	: Handles switching of active panels for main menu
//---------------------------------------------------------------------------------
public class panelControls : MonoBehaviour {
	//===================
	// Public Variables
	//===================
//
//

	//===================
	// Private Variables
	//===================
	[Header ("List of panels")]
	[SerializeField] private GameObject panel;
	[SerializeField] private GameObject panel2;
	[SerializeField] private GameObject panel3;

	[Header ("Animator")]
	[SerializeField] private Animator animator;

	//---------------------------------------------------------------------------------
	// enables the menu panel and disasble the splash panel
	//---------------------------------------------------------------------------------
	public void disablepanel1 () {
		panel.SetActive (false);
		panel2.SetActive (true);
	}

	//---------------------------------------------------------------------------------
	// Toggles the panel active state for main menu panel and setting panel
	//---------------------------------------------------------------------------------
	public void swappanel () {
		panel2.SetActive (!panel2.activeInHierarchy);
		panel3.SetActive (!panel3.activeInHierarchy);
	}

	//---------------------------------------------------------------------------------
	// Toggles boolean of a animator property when the play button is clicked
	//---------------------------------------------------------------------------------
	public void playstart () {
		animator.SetBool("playpressed", true);
	}
}