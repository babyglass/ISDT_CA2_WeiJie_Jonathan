using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//---------------------------------------------------------------------------------
// Author		: Jonathan Chong Lyen Chyn
// Date  		: 29/12/2020
// Modified By	: Jonathan Chong Lyen Chyn
// Modified Date: 29/12/2020
// Description	: Script checks to see if there is collision between colliders and changes active state of guidance trails
//---------------------------------------------------------------------------------

public class KitDisposal : MonoBehaviour
{
    #region Variables
    //===================
    // Public Variables
    //===================

    //===================
    // Private Variables
    //===================
    [SerializeField] private GameObject UnresolveTrail02;
    [SerializeField] private GameObject ResolveTrail;
    [SerializeField] private RawImage LapseNotice;
    [SerializeField] private Texture LapseResolve;
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
    // Checks if the Oil Spill Kit has been disposed of and updates the trail
    //---------------------------------------------------------------------------------
    void OnTriggerEnter(Collider collision)
    {
        if (collision)
        {
            UnresolveTrail02.SetActive(false);
            ResolveTrail.SetActive(true);
            RawImage Sign = LapseNotice.GetComponent<RawImage>();
            Sign.texture = LapseResolve;
        }
    }
	#endregion
}
