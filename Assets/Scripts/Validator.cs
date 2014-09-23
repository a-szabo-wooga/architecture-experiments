using System;
using UnityEngine;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

public interface ICA<T>
{
	bool IsValid(T x);
}

[AttributeUsage(AttributeTargets.Field)]
public class MyAttribute : Attribute
{
	public MyAttribute(int limit)
	{
		Limit = limit;
	}
	
	public int Limit { get; private set; }
}

[AttributeUsage(AttributeTargets.Field)]
public class NeedsInt : Attribute, ICA<int>
{
	public NeedsInt(int stuff)
	{
		ToBeValidated = stuff;
	}
	
	public bool IsValid(int x)
	{
		Debug.Log("Aww yiss validating!");
		return ToBeValidated == x;
	}
		
	public int ToBeValidated { get; private set; }
}

[AttributeUsage(AttributeTargets.Field)]
public class TypeAttribute : Attribute
{
	public TypeAttribute(System.Type t)
	{
		AttribType = t;
	}
	
	public System.Type AttribType { get; private set; }
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
			
			foreach(var attrib in f.GetCustomAttributes(typeof(ICA<int>), false))
			{
				Debug.Log ("Attrib type: " + attrib.GetType());
				((ICA<int>)attrib).IsValid((int)f.GetValue(obj));
			}
			
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
			
			
			
			var es = (TypeAttribute) Attribute.GetCustomAttribute(f, typeof(TypeAttribute));
			if (es != null)
			{
				Debug.Log("OK, type attrib found!");
				DoStuff<System.Type>(es.AttribType);				
			}
		}
		
		Debug.Log("Passed object has following non-public fields: ");
		foreach (var f in typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
		{
			Debug.Log(f.Name + " : " + f.GetValue(obj).ToString());
		}
		
		
		return true;
	}
	
	public static void DoStuff<T>(T thing)
	{
		Debug.Log("Yay, called!");
		Debug.Log(thing.GetType().Module);
	}
}