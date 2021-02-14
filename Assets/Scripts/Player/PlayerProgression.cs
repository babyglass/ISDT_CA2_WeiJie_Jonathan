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
// Description	: Tracks player progression through level and activates certain events
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
	// Swapping elements
	[SerializeField] private GameObject gate;
	[SerializeField] private GameObject sparks;
	[SerializeField] private Texture lapseResolve;

	// Intro elements
	[SerializeField] private GameObject introCanvas;
	[SerializeField] private GameObject padCanvas;

	// Fuse elements
	[SerializeField] private GameObject fuseUnfixed;
	[SerializeField] private GameObject fuseFixed;
	[SerializeField] private RawImage fuseNotice;
	[SerializeField] private TextMeshProUGUI fuseText;
	[SerializeField] private TextMeshProUGUI fuseStatus;

	// Oil spill elements
	[SerializeField] private GameObject oilSpill;
	[SerializeField] private GameObject sponge;
	[SerializeField] private GameObject oilUnfixed;
	[SerializeField] private GameObject oilFixed;
	[SerializeField] private RawImage oilNotice;
	[SerializeField] private TextMeshProUGUI oilText;
	[SerializeField] private TextMeshProUGUI oilStatus;

	// Sponge elements
	[SerializeField] private GameObject spongeUnfixed;

	private string excelName;

   	#endregion


	#region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
		SetupExcel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion


	#region Own Methods
	//---------------------------------------------------------------------------------
    // PadGrab(): Disables pad canvas on grabbing datapad
    //---------------------------------------------------------------------------------
	public void PadGrab()
	{
		padCanvas.SetActive(false);
	}

	//---------------------------------------------------------------------------------
    // GateOpen(): Plays gate opening animation
    //---------------------------------------------------------------------------------
	public void GateOpen()
	{
		gate.GetComponent<Animator>().enabled = true;
		introCanvas.SetActive(false);
	}

	//---------------------------------------------------------------------------------
    // ResolveFuse(): Disables and enables the appropriate elements to indicate fuse lapse has been resolved
    //---------------------------------------------------------------------------------
	public void ResolveFuse()
	{
		sparks.SetActive(false);
		fuseUnfixed.SetActive(false);
		fuseFixed.SetActive(true);
		fuseNotice.GetComponent<RawImage>().texture = lapseResolve;
		fuseText.text = "Electrical hazard resolved!";
		fuseStatus.text = "Resolved";
		UpdateExcel(1, 1);
	}

	//---------------------------------------------------------------------------------
    // ResolveOil(): Disables and enables the appropriate elements to indicate oil spill lapse has been resolved
    //---------------------------------------------------------------------------------
	public void ResolveOil()
	{
		oilSpill.GetComponent<Animator>().enabled = true;
		sponge.GetComponent<Animator>().enabled = true;
		oilUnfixed.SetActive(false);
		oilFixed.SetActive(true);
		oilNotice.GetComponent<RawImage>().texture = lapseResolve;
		oilText.text = "Chemical hazard resolved!\n(Dispose of the sponge in the chemical waste bin)";
		spongeUnfixed.SetActive(true);
		oilStatus.text = "Resolved";
		UpdateExcel(2, 1);
	}


	//---------------------------------------------------------------------------------
    // SetupExcel(): Creates the excel file to hold test results
    //---------------------------------------------------------------------------------
	void SetupExcel()
	{
		DateTime dt = DateTime.Now;
        //excelName = dt.ToString("yyyy-MM-dd") + ".xls";
		excelName = "CandidateResult.xls";

        string path = Application.dataPath + "/Output/";

        if (!Directory.Exists(path))
        {
            Debug.Log("Create Directory");
            Directory.CreateDirectory(path);
        }

        Debug.Log("streaming assets: " + Application.streamingAssetsPath);

        if (System.IO.File.Exists(path + excelName))
        {
            Debug.Log("File Exist: [" + path + "]");
            //*****
            HSSFWorkbook book;
            using (FileStream file = new FileStream(@path + excelName, FileMode.Open, FileAccess.Read))
            {
                book = new HSSFWorkbook(file);
                file.Close();
            }

            ISheet sheet = book.GetSheetAt(0);

            IRow hRow = sheet.GetRow(0);
            IRow row = sheet.CreateRow(sheet.LastRowNum);

            sheet.CreateRow(0).CreateCell(0).SetCellValue("Task");
            sheet.CreateRow(1).CreateCell(0).SetCellValue("Electrical Hazard");
            sheet.CreateRow(2).CreateCell(0).SetCellValue("Chemical Hazard");
            sheet.CreateRow(3).CreateCell(0).SetCellValue("Mechanical Hazard");
            sheet.GetRow(1).CreateCell(1).SetCellValue("FAIL");
            sheet.GetRow(2).CreateCell(1).SetCellValue("FAIL");
            sheet.GetRow(3).CreateCell(1).SetCellValue("FAIL");

            using (FileStream file = new FileStream(@path + excelName, FileMode.Open, FileAccess.Write))
            {
                book.Write(file);
                file.Close();
            }
        }
        else
        {
            Debug.Log("File DOES NOT Exist");

            //*****
            IWorkbook book = new HSSFWorkbook(); ;
            //using (var file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite)) {
            //	book = new XSSFWorkbook();
            //}

            ISheet sheet = book.CreateSheet("Test Results");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Task");
            sheet.CreateRow(1).CreateCell(0).SetCellValue("Electrical Hazard");
            sheet.CreateRow(2).CreateCell(0).SetCellValue("Chemical Hazard");
            sheet.CreateRow(3).CreateCell(0).SetCellValue("Mechanical Hazard");
            sheet.GetRow(1).CreateCell(1).SetCellValue("FAIL");
            sheet.GetRow(2).CreateCell(1).SetCellValue("FAIL");
            sheet.GetRow(3).CreateCell(1).SetCellValue("FAIL");

            //Save
            FileStream xfile = File.Create(path + excelName);
            book.Write(xfile);
            xfile.Close();
        }
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
