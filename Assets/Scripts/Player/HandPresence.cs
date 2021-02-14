using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;

//---------------------------------------------------------------------------------
// Author		: Jonathan Chong Lyen Chyn / Ang Wei Jie
// Date  		: 13/02/2021
// Modified By	: Jonathan Chong Lyen Chyn
// Modified Date: 13/02/2021
// Description	: Script for rendering hands
//---------------------------------------------------------------------------------

public class HandPresence : MonoBehaviour
{
	#region Variables
   	//===================
	// Public Variables
	//===================
	public bool showController = false;
	public InputDeviceCharacteristics controllerCharacteristics;
	public GameObject handModelPrefab;
	public List<GameObject> controllerPrefabs;

   	//===================
	// Private Variables
	//===================
	private GameObject spawnedHandModel;
	private InputDevice targetDevice;
	private GameObject spawnedController;
	private Animator handAnimator;

   	#endregion


	#region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    // Update is called once per frame
    void Update()
    {
		if (!targetDevice.isValid)
		{
			TryInitialize();
		}
		else
		{
			if(showController)
			{
				spawnedHandModel.SetActive(false);
				spawnedController.SetActive(true);
			}
			else
			{
				spawnedHandModel.SetActive(true);
				spawnedController.SetActive(false);
				UpdateHandAnimation();
			}
		}

    }

	#endregion


	#region Own Methods
	//---------------------------------------------------------------------------------
    // UpdateHandAnimation(): Actively updates the animation state of the hand models based on input
    //---------------------------------------------------------------------------------
	void UpdateHandAnimation()
	{
		if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
		{
			handAnimator.SetFloat("Trigger", triggerValue);
		}
		else
		{
			handAnimator.SetFloat("Trigger", 0);
		}

		if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
		{
			handAnimator.SetFloat("Grip", gripValue);
		}
		else
		{
			handAnimator.SetFloat("Grip", 0);
		}

	}

	void TryInitialize()
	{
		List<InputDevice> devices = new List<InputDevice>();
		
		InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

		foreach(var item in devices)
		{
			Debug.Log(item.name);
		}

		if(devices.Count > 0)
		{
			targetDevice = devices[0];
			GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
			if(prefab)
			{
				spawnedController = Instantiate(prefab, transform);
			}
			else 
			{
				Debug.LogError("Did not find corresponding controller model");
				spawnedController = Instantiate(controllerPrefabs[0], transform);
			}

			spawnedHandModel = Instantiate(handModelPrefab, transform);
			handAnimator = spawnedHandModel.GetComponent<Animator>();

		}
	}

	#endregion
}
