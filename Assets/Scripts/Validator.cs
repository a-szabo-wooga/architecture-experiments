using System;
using UnityEngine;
using System.Text;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field)]
public class MyAttribute : Attribute
{
	public MyAttribute(int limit)
	{
		Limit = limit;
	}
	
	public int Limit { get; private set; }
}

public class Validator
{
	public static bool Validate<T>(T obj)
	{
		
		// OK so GetFields really only gets fields,
		// not properties.
		
		Debug.Log("Passed object has following public fields: ");
		foreach (var f in typeof(T).GetFields())
		{
			Debug.Log(f.Name + " : " + f.GetValue(obj).ToString());
			
			var s = (MyAttribute) Attribute.GetCustomAttribute(f, typeof(MyAttribute));
			if ( s != null )
			{
				Debug.Log ("Aww yiss, my attrib found!");
				if ((int)f.GetValue(obj) < s.Limit)
				{
					Debug.Log("And the number is smaller than the limit.");
				}
				else
				{
					Debug.Log("But the number is not smaller than the limit!");
				}
			}
		}
		
		Debug.Log("Passed object has following non-public fields: ");
		foreach (var f in typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
		{
			Debug.Log(f.Name + " : " + f.GetValue(obj).ToString());
		}
		
		
		return true;
	}
}