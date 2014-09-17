using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{	
	private Dictionary<string, IService>	_services = new Dictionary<string, IService>();

	public ServiceLocator()
	{
		// Add services (managers) to dictionary
		_services.Add("GearManager", GearManager.Instance);
		_services.Add("EventManager", EventManager.Instance);
		
		// Wire them up:
		foreach (var kvpair in _services)
		{
			var cast = kvpair.Value as IService;
			cast.DoStuff();
			cast.Init(this);
		}
	}
	
	public IService GetService(string s)
	{
		if (_services.ContainsKey(s))
		{
			return _services[s] as IService;
		}
		else
		{
			Debug.Log("Couldn't find: " + s);
			return null;
		}
	}
}
