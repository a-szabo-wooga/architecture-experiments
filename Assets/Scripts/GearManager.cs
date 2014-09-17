using System;
using System.Collections;
using UnityEngine;

public class GearManager : IService
{
	private static readonly GearManager _instance = new GearManager();
	private GearManager() { }

	public static GearManager Instance
	{
		get
		{
			return _instance;
		}
	}
	
	private ServiceLocator _serloc;
	private IService _evtmgr;
	
	public void DoStuff()
	{
		Debug.Log("Gear Manager here!");
	}
	
	public void Init(ServiceLocator serloc)
	{
		Debug.Log("Setting up gear manager.");
		_serloc = serloc;
		_evtmgr = serloc.GetService("EventManager");
		Debug.Log("Calling event manager: ");
		_evtmgr.DoStuff();
	}
}
