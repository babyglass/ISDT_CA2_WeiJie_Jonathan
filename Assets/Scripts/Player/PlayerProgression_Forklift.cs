using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//---------------------------------------------------------------------------------
// Author		: Jonathan Chong Lyen Chyn
// Date  		: 13/02/2021
// Modified By	: Jonathan Chong Lyen Chyn
// Modified Date: 13/02/2021
// Description	: Tracks player progression through the forklift hazard
//---------------------------------------------------------------------------------

public class PlayerProgression_Forklift : MonoBehaviour
{
	#region Variables
   	//===================
	// Public Variables
	//===================

   	//===================
	// Private Variables
	//===================
	// Swapping elements
	[SerializeField] private Texture lapseResolve;

	// Forklift elements
	[SerializeField] private GameObject forklift;
	[SerializeField] private GameObject forkliftUnfixed;
	[SerializeField] private GameObject forkliftFixed;
	[SerializeField] private RawImage forkliftNotice;
	[SerializeField] private TextMeshProUGUI forkliftText;
	[SerializeField] private TextMeshProUGUI forkliftStatus;

	private string excelName = "CandidateResult.xls";

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
    // OnTriggerEnter(): Detects collision between 2 colliders and runs provided code
    //---------------------------------------------------------------------------------
	void OnTriggerEnter(Collider collision)
	{
		if (collision && collision.gameObject.tag == "Player")
		{
			ResolveForklift();
			forkliftStatus.text = "Resolved";
		}

		Debug.Log(collision.gameObject.tag);
	}

	//---------------------------------------------------------------------------------
    // ResolveForklift(): Disables and enables the appropriate elements to indicate forklift lapse has been resolved
    //---------------------------------------------------------------------------------
	public void ResolveForklift()
	{
		forklift.GetComponent<Animator>().enabled = true;
		forkliftUnfixed.SetActive(false);
		forkliftFixed.SetActive(true);
		forkliftNotice.GetComponent<RawImage>().texture = lapseResolve;
		forkliftText.text = "Mechanical hazard resolved!";
		UpdateExcel(3, 1);
	}

	//---------------------------------------------------------------------------------
    // UpdateExcel(): Updates the specified cell to PASS value
    //---------------------------------------------------------------------------------
	void UpdateExcel(int row, int cell)
	{
		string path = Application.dataPath + "/Output/";

		HSSFWorkbook book;
		using (FileStream file = new FileStream(@path + excelName, FileMode.Open, FileAccess.Read))
		{
			book = new HSSFWorkbook(file);
			file.Close();
		}

		ISheet sheet = book.GetSheetAt(0);

		IRow hRow = sheet.GetRow(0);
		//IRow row = sheet.CreateRow(sheet.LastRowNum);

		sheet.GetRow(row).GetCell(cell).SetCellValue("PASS");
		Debug.Log("Excel file updated");

		using (FileStream file = new FileStream(@path + excelName, FileMode.Open, FileAccess.Write))
		{
			book.Write(file);
			file.Close();
		}
	} 

	#endregion
}
