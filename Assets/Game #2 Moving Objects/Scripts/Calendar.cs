using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System;

public class Calendar : MonoBehaviour {

	public TextMesh Day;
	public TextMesh Month;
	public TextMesh Year;

	void Start () {
		SetDate();
	}

	void SetDate(){
		DateTime today = DateTime.Today;
		Day.text = today.Day.ToString();
		Month.text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(today.Month);
		Year.text = today.Year.ToString();
	}
	
}
