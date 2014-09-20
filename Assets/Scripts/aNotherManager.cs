using UnityEngine;
using System.Collections;

public class aNotherManager : IAService, IANotherService
{
	private aNotherManager() { }
	private static readonly aNotherManager _instance = new aNotherManager();
	public static aNotherManager Instance { get { return _instance; } }

	private aServiceLocator _serLoc;

	public string Blah { get; set; }

	public void Init()
	{
		_serLoc = aServiceLocator.Instance;
		_serLoc.AddService("AnotherService", Instance);
	}

	public void DoStuff()
	{
		Debug.Log("Another service here.");
	}
}
