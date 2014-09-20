using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class aServiceLocator
{
	#region singleton matters
	private aServiceLocator()
	{
	}

	private static readonly aServiceLocator _instance = new aServiceLocator();
	public static aServiceLocator Instance
	{
		get { return _instance; }
	}
	#endregion
	
	private Dictionary<string, IAService> _services = new Dictionary<string, IAService>();

	public void AddService(string name, IAService service)
	{
		_services.Add(name, service);
	}

	public IAService GetService(string name)
	{
		if (_services.ContainsKey(name))
		{
			return _services[name];
		}
		else
		{
			return null;
			// throw KeyNotFoundException;
		}
	}

}
