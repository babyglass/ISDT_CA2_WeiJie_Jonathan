using System.Collections;
using UnityEngine;

//---------------------------------------------------------------------------------
// Author		: Ang Wei Jie
// Date  		: 14/12/2020
// Modified By	: Ang Wei Jie
// Modified Date: 14/12/2020
// Description	: Script makes belt snapzones follow player camera rotation
//---------------------------------------------------------------------------------
public class Followinv : MonoBehaviour {
	//===================
	// Public Variables
	//===================
	public Transform target;
	public Vector3 offset;

	//===================
	// Private Variables
	//===================

	//---------------------------------------------------------------------------------
	// FixedUpdate for Physics update
	//---------------------------------------------------------------------------------
	protected void FixedUpdate () {

		transform.position = target.position + Vector3.up * offset.y +
			Vector3.ProjectOnPlane (target.right, Vector3.up).normalized * offset.x +
			Vector3.ProjectOnPlane (target.forward, Vector3.up).normalized * offset.z;

		transform.eulerAngles = new Vector3 (0, target.eulerAngles.y, 0);
	}



	//---------------------------------------------------------------------------------
	// XXX is when blah blah
	//---------------------------------------------------------------------------------
	protected void OnDestroy () { }
}