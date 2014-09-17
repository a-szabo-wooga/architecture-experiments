using UnityEngine;
using System.Collections;

public class EventManager : IService, IEventService
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
	private IGearService _gearmgr;
	
	public void DoStuff()
	{
		Debug.Log("Event manager here!");
	}

	public void DoEventRelatedStuff()
	{
		Debug.Log("Event manager doing event related stuff here.");
	}
	
	public void Init(ServiceLocator serloc)
	{
		Debug.Log("Setting up event manager.");
		_serloc = serloc;
		_gearmgr = _serloc.GetService("GearManager") as IGearService;
		Debug.Log("Calling gear service through IGearService: ");
		_gearmgr.DoGearRelatedStuff();
	}
}
