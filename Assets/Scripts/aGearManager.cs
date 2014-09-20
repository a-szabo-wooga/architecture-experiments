using UnityEngine;
using System.Collections;

public class aGearManager : IAService, IAGearService
{
	private aGearManager()
	{ 
	}

	private static readonly aGearManager _instance = new aGearManager();
	public static aGearManager Instance
	{
		get { return _instance; }
	}
	
	public string CurrentGear
	{
		get;
		set;
	}

	private aServiceLocator _serLoc;

	public void Init()
	{
		_serLoc = aServiceLocator.Instance;
		_serLoc.AddService("GearService", Instance);
	}

	public void DoStuff()
	{
		Debug.Log("aGearManager here.");
	}

}