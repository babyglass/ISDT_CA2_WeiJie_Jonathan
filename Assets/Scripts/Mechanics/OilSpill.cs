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
// Description	: Monitors and handles events triggered by player actions for the Oilspill safety lapse
//---------------------------------------------------------------------------------

public class OilSpill : MonoBehaviour
{
    #region Variables
    //===================
    // Public Variables
    //===================

    //===================
    // Private Variables
    //===================
    [SerializeField] private GameObject OilPatch;
    [SerializeField] private GameObject SpillKit;
    [SerializeField] private RawImage LapseNotice;
    [SerializeField] private Texture LapseResolve;
    [SerializeField] private TextMeshProUGUI OilText;
    [SerializeField] private GameObject UnresolveTrail01;
    [SerializeField] private GameObject UnresolveTrail02;
    [SerializeField] private GameObject KitDisposed;
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
    // Begins animations for both oil patch and spill kit
    //---------------------------------------------------------------------------------
    public void SpillClean()
    {
        Animator OilPatchAnimator = OilPatch.GetComponent<Animator>();
        Animator SpillKitAnimator = SpillKit.GetComponent<Animator>();
        OilPatchAnimator.enabled = true;
        SpillKitAnimator.enabled = true;
        OilText.text = "Oil Spill cleaned up!\n\nOil Spill Kits help absorb the oil, getting rid of the oil spill. Once the oil has been fully absorbed, the kit should be disposed of in a waste bin.";
        UnresolveTrail01.SetActive(false);
        UnresolveTrail02.SetActive(true);
        RawImage Sign = LapseNotice.GetComponent<RawImage>();
        Sign.texture = LapseResolve;
        KitDisposed.SetActive(true);
    }
	#endregion
}
