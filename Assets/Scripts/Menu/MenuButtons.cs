using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//---------------------------------------------------------------------------------
// Author		: Ang Wei Jie
// Date  		: 14/12/2020
// Modified By	: Ang Wei Jie
// Modified Date: 14/12/2020
// Description	: Handles interaction for main menu: loads next scene in build index if play is selected and quits if quit is selected
//---------------------------------------------------------------------------------
public class MenuButtons : MonoBehaviour {
	//===================
	// Public Variables
	//===================

	//===================
	// Private Variables
	//===================

	//---------------------------------------------------------------------------------
	// Loads into the game scene
	//---------------------------------------------------------------------------------
	public void startGame (string scenename) {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //loads by next build number
	}

	//---------------------------------------------------------------------------------
	// Quits the game
	//---------------------------------------------------------------------------------
	public void quitGame () {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit ();
#endif
	}
}