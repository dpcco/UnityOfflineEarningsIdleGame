using UnityEngine;
using System.Collections;
using System;

public class OfflineEarnings : MonoBehaviour
{
	DateTime currentDate;
	DateTime oldDate;
	int coin = 14;
	int earned;
	void Start()
	{
		currentDate = System.DateTime.Now;
		long temp = Convert.ToInt64(PlayerPrefs.GetString("exitTime"));
		DateTime oldDate = DateTime.FromBinary(temp);
		Debug.Log("oldDate: " + oldDate);
		TimeSpan difference = currentDate.Subtract(oldDate);
		Debug.Log("Difference: " + difference.TotalMinutes);
		int x = (int)difference.TotalMinutes;
		earned = coin * x;
		Debug.Log ("You earned = " + earned);
		InvokeRepeating("exitDate", 2f, 30f);
	}

	void exitDate()
	{
		PlayerPrefs.SetString("exitTime", System.DateTime.Now.ToBinary().ToString());

		Debug.Log("Last Time " + System.DateTime.Now);
	}

}