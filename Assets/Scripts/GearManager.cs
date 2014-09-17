using System;
using System.Collections;
using UnityEngine;

public class GearManager : IService, IGearService
{
	#region singleton stuff
	private static readonly GearManager _instance = new GearManager();
	private GearManager() { }

	public static GearManager Instance
	{
		get
		{
			return _instance;
		}
	}
	#endregion
	
	private ServiceLocator _serloc;
	private IEventService _evtmgr;
	
	public void DoStuff()
	{
		Debug.Log("Gear Manager here!");
	}
	
	public void Init(ServiceLocator serloc)
	{
		Debug.Log("Setting up gear manager.");
		_serloc = serloc;
		_evtmgr = serloc.GetService("EventManager") as IEventService;
		Debug.Log("Calling event manager: ");
		_evtmgr.DoEventRelatedStuff();
	}
	
	public void DoGearRelatedStuff()
	{
		Debug.Log ("Gear Mgr here, doing some gear related stuff.");
	}
}
