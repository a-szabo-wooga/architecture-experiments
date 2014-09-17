using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{	
	private static readonly ServiceLocator _instance = new ServiceLocator();
	private ServiceLocator()
	{
	}
	
	private Dictionary<string, IService> _services = new Dictionary<string, IService>();
	
	public static ServiceLocator Instance
	{
		get
		{
			return _instance;
		}
	}
	
	public void Init()
	{
		// Add services (managers) to dictionary
		_services.Add("GearManager", GearManager.Instance);
		_services.Add("EventManager", EventManager.Instance);
		
		// Wire them up:
		foreach (var kvpair in _services)
		{
			kvpair.Value.Init(this);
		}
	}
	
	public IService GetService(string s)
	{
		if (_services.ContainsKey(s))
		{
			return _services[s];
		}
		else
		{
			Debug.Log("Couldn't find: " + s);
			return null;
		}
	}
}
