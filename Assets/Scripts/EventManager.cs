using UnityEngine;
using System.Collections;

public class EventManager : IService
{
	#region singleton
	private static readonly EventManager _instance = new EventManager();
	
	private EventManager()
	{
	}
	
	public static EventManager Instance
	{
		get
		{
			return _instance;
		}
	}
	#endregion
	
	private ServiceLocator _serloc;
	private IService _gearmgr;
	
	public void DoStuff()
	{
		Debug.Log("Event manager here!");
	}
	
	public void Init(ServiceLocator serloc)
	{
		Debug.Log("Setting up event manager.");
		_serloc = serloc;
		_gearmgr = _serloc.GetService("GearManager");
	}
}
