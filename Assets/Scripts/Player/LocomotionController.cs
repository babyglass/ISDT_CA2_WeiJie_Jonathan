using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//---------------------------------------------------------------------------------
// Author		: Jonathan Chong Lyen Chyn
// Date  		: 13/02/2021
// Modified By	: Jonathan Chong Lyen Chyn
// Modified Date: 13/02/2021
// Description	: Keeps track of whether teleport ray is activated
//---------------------------------------------------------------------------------

public class LocomotionController : MonoBehaviour
{
	#region Variables
   	//===================
	// Public Variables
	//===================
	public XRController leftTeleportRay;
	public XRController rightTeleportRay;
	public InputHelpers.Button teleportActivationButton;

   	//===================
	// Private Variables
	//===================

   	#endregion


	#region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leftTeleportRay)
		{
			leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
		}

		if(rightTeleportRay)
		{
			rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
		}
    }

	#endregion


	#region Own Methods
	//---------------------------------------------------------------------------------
    // Function description
    //---------------------------------------------------------------------------------
	public bool CheckIfActivated(XRController controller)
	{
		InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated);
		return isActivated;
	}

	#endregion
}
