using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{	
	#region singleton stuff

	private static readonly ServiceLocator _instance = new ServiceLocator();
	private ServiceLocator()
	{
	}

	public static ServiceLocator Instance
	{
		get
		{
			return _instance;
		}
	}
	#endregion

	private Dictionary<string, IService> _services = new Dictionary<string, IService>();

	public void Init()
	{
		AddServices();
		InitServices();
	}

	private void AddServices()
	{
		_services.Add("GearManager", GearManager.Instance);
		_services.Add("EventManager", EventManager.Instance);
	}

	private void InitServices()
	{
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
