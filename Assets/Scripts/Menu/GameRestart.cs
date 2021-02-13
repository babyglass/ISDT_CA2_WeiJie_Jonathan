using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//---------------------------------------------------------------------------------
// Author		: Jonathan Chong Lyen Chyn
// Date  		: 30/12/2020
// Modified By	: Jonathan Chong Lyen Chyn
// Modified Date: 30/12/2020
// Description	: Activates the trigger to play the blockout animation and restart the game
//---------------------------------------------------------------------------------

public class GameRestart : MonoBehaviour
{
    #region Variables
    //===================
    // Public Variables
    //===================

    //===================
    // Private Variables
    //===================
    [SerializeField] private GameObject BlockOut;

   	#endregion


	#region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	#endregion


	#region Own Methods
	//---------------------------------------------------------------------------------
    // Restarts game by loading scene at Index 0
    //---------------------------------------------------------------------------------
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    //---------------------------------------------------------------------------------
    // Sets trigger to true to play animation
    //---------------------------------------------------------------------------------
    public void TriggerFadeOut()
    {
        Animator BOAnimator = BlockOut.GetComponent<Animator>();
        BOAnimator.SetTrigger("GameComplete");
    }

    //---------------------------------------------------------------------------------
    // Detects collision of colliders and triggers TriggerFadeOut function
    //---------------------------------------------------------------------------------
    void OnTriggerEnter(Collider collision)
    {
        if (collision)
        {
            TriggerFadeOut();
        }
    }
    #endregion
}
