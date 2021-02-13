using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//---------------------------------------------------------------------------------
// Author		: Ang Wei Jie / Jonathan Chong Lyen Chyn
// Date  		: 17/12/20
// Modified By	: Ang Wei Jie / Jonathan Chong Lyen Chyn
// Modified Date: 17/12/20
// Description	: Script controls audio mixer volumes
//---------------------------------------------------------------------------------

public class AudioMixerScript : MonoBehaviour 
{
	#region Variables
	//===================
	// Public Variables
	//===================
	public AudioMixer Mixer;

	//===================
	// Private Variables
	//===================
	#endregion


	#region Unity Methods
	//---------------------------------------------------------------------------------
    // Start is called before the first frame update
    //---------------------------------------------------------------------------------
    void Start()
    {

    }

    //---------------------------------------------------------------------------------
    // Update is called once per frame
    //---------------------------------------------------------------------------------
    void Update()
    {

    }
    #endregion


	#region Own Methods
	//---------------------------------------------------------------------------------
	// Update sound levels
	//---------------------------------------------------------------------------------
	public void SetMasterVolume (Slider volume) {
		Mixer.SetFloat ("Master", volume.value);
	}

	public void SetBGMVolume (Slider volume) {
		Mixer.SetFloat ("BGM", volume.value);
	}

	public void SetSFXVolume (Slider volume) {
		Mixer.SetFloat ("SFX", volume.value);
	}

	#endregion

}