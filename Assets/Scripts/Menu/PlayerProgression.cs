using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//---------------------------------------------------------------------------------
// Author		: Jonathan Chong Lyen Chyn
// Date  		: 30/12/2020
// Modified By	: Jonathan Chong Lyen Chyn
// Modified Date: 30/12/2020
// Description	: Switches on/off certain world elements depending on player progression in demo
//---------------------------------------------------------------------------------

public class PlayerProgression : MonoBehaviour
{
    #region Variables
    //===================
    // Public Variables
    //===================

    //===================
    // Private Variables
    //===================
    [SerializeField] private GameObject IntroCanvas;
    [SerializeField] private GameObject DPIntro;
    [SerializeField] private TextMeshProUGUI HardHatText;
    [SerializeField] private GameObject SafetyLapses;
    [SerializeField] private GameObject FuseResolve;
    [SerializeField] private GameObject OilResolve;
    [SerializeField] private GameObject ForkliftResolve;
    [SerializeField] private GameObject CompletionCanvas;
    [SerializeField] private GameObject CompletionGateway;
    #endregion


    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FuseResolve.activeSelf && OilResolve.activeSelf && ForkliftResolve.activeSelf && CompletionCanvas.activeSelf!=true)
        {
            OnCompletion();
        }
    }

	#endregion


	#region Own Methods
	//---------------------------------------------------------------------------------
    // Disables the Intro Canvas
    //---------------------------------------------------------------------------------
    public void IntroDisable()
    {
        IntroCanvas.SetActive(false);
    }

    //---------------------------------------------------------------------------------
    // Disables the DPIntro Canvas
    //---------------------------------------------------------------------------------
    public void DataPadCanvasDisable()
    {
        DPIntro.SetActive(false);
    }

    //---------------------------------------------------------------------------------
    // Changes text in HardHatCanvas and sets all safety lapse gameobject to active
    //---------------------------------------------------------------------------------
    public void HardHatEquipped()
    {
        HardHatText.text = "Now that you got your hardhat, search around the industrial site for safety lapses and resolve them! If you need a hint, use your datapad!";
        SafetyLapses.SetActive(true);
    }

    //---------------------------------------------------------------------------------
    // Enables the completion mechanic
    //---------------------------------------------------------------------------------
    public void OnCompletion()
    {
        CompletionCanvas.SetActive(true);
        CompletionGateway.SetActive(true);
    }
    #endregion
}
