﻿using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

public class MainController : MonoBehaviour 
{
    public GameObject AlarmSound;
    public GameObject ExitObject;

	// Use this for initialization
	void Start ()
    {
		Data.Controller = this;
		StartCoroutine(Init());
	}

	float GetCurrentPlayerHeight()
	{
		var curCameraHeight = Camera.main.transform.position.y;
		var floorHeight = Data.FloorHeight;
		return Mathf.Abs(curCameraHeight - floorHeight);
	}

	IEnumerator Init()
	{
		yield return new WaitForSeconds(5);
		InitHeight();
		// AlarmSound.SetActive(true);
		Data.IsSmokeActivated = true;
	}

	void InitHeight()
	{
		RaycastHit hitInfo;
		bool hit = Physics.Raycast(Camera.main.transform.position,
								new Vector3(0, -1, 0),
								out hitInfo,
								3f,
								SpatialMappingManager.Instance.LayerMask);
		var height = Vector3.Distance(Camera.main.transform.position, hitInfo.point);
		if (Mathf.Abs(height) < 0.2f)
		{
			height = 1.8f;
		}
		Data.FloorHeight = -height;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Data.IsSmokeActivated)
		{
			if (Data.FloorHeight + GetCurrentPlayerHeight() >= Data.GetSmokeHeight())
			{
				Data.DamagePlayer(DamageType.Smoke);
			}
			else
			{
				Data.HealPlayer(DamageType.Smoke);
			}
		}
	}

	public void KillPlayer()
	{
		// todo: kill user
	}

    public void CollidedWith(GameObject collidedWith)
    {
        if (collidedWith == ExitObject)
        {
            StartExitProcedure();
        }
    }

    private void StartExitProcedure()
    {
        //TODO:EXIT!!
    }
}