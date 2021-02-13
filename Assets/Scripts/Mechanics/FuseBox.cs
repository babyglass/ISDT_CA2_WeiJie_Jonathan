using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//---------------------------------------------------------------------------------
// Author		: Jonathan Chong Lyen Chyn
// Date  		: 29/12/2020
// Modified By	: Jonathan Chong Lyen Chyn
// Modified Date: 30/12/2020
// Description	: Monitors and handles events triggered by player actions for the Fusebox safety lapse
//---------------------------------------------------------------------------------

public class FuseBox : MonoBehaviour
{
    #region Variables
    //===================
    // Public Variables
    //===================

    //===================
    // Private Variables
    //===================
    [SerializeField] private GameObject SparkParticles;
    [SerializeField] private RawImage LapseNotice;
    [SerializeField] private Texture LapseResolve;
    [SerializeField] private TextMeshProUGUI FuseText;
    [SerializeField] private GameObject TrailResolved;
    [SerializeField] private GameObject TrailUnresolved;
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
    // Stop spark particles emission and changes texture of raw image from LapsePresent to LapseResolve
    //---------------------------------------------------------------------------------
    public void LapseFixed()
    {
        ParticleSystem.EmissionModule Sparks = SparkParticles.GetComponent<ParticleSystem>().emission;
        Sparks.enabled = false;
        RawImage Sign = LapseNotice.GetComponent<RawImage>();
        Sign.texture = LapseResolve;
        FuseText.text = "Safety lapse resolved!\n Well Done!";
        TrailUnresolved.SetActive(false);
        TrailResolved.SetActive(true);
    }
    #endregion
}
