using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//---------------------------------------------------------------------------------
// Author		: Jonathan Chong Lyen Chyn
// Date  		: 29/12/2020
// Modified By	: Jonathan Chong Lyen Chyn
// Modified Date: 29/12/2020
// Description	: Monitors and handles events triggered by player actions for the Forklift safety lapse
//---------------------------------------------------------------------------------

public class Forklift : MonoBehaviour
{
    #region Variables
    //===================
    // Public Variables
    //===================

    //===================
    // Private Variables
    //===================
    [SerializeField] private bool KeySlotted;
    [SerializeField] private GameObject Lift;
    [SerializeField] private RawImage LapseNotice;
    [SerializeField] private Texture LapseResolve;
    [SerializeField] private TextMeshProUGUI ForkliftText;
    [SerializeField] private GameObject UnresolvedTrail;
    [SerializeField] private GameObject ResolvedTrail;

    #endregion


    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        KeySlotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	#endregion


	#region Own Methods
	//---------------------------------------------------------------------------------
    // Updates the KeySlotted bool variable to true
    //---------------------------------------------------------------------------------
    public void KeyInserted()
    {
        KeySlotted = true;
    }

    //---------------------------------------------------------------------------------
    // Checks to see if the KeySlotted is true and that the LOWER button collider has been triggered to activate an animator
    //---------------------------------------------------------------------------------
    void OnTriggerEnter(Collider collision)
    {
        if (collision && KeySlotted)
        {
            Animator LiftAnimator = Lift.GetComponent<Animator>();
            LiftAnimator.enabled = true;
            RawImage Sign = LapseNotice.GetComponent<RawImage>();
            Sign.texture = LapseResolve;
            ForkliftText.text = "Well done! \n\nThe lift has been lowered but caution should still be exercised when near heavy machinery.";
            UnresolvedTrail.SetActive(false);
            ResolvedTrail.SetActive(true);
        }
    }
    #endregion
}
