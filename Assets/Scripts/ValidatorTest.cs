using UnityEngine;
using System;
using System.Collections;

public class ValidatorTest : MonoBehaviour {

	[MyAttribute(100)]
	public int SomeInt;
	
	[TypeAttribute(typeof(int))]
	public int YInt = 100;
	
	[NeedsInt(10)]
	public int StillAnotherInt = 20;
	
	private int _somePrivateInt = 123;
	protected float protFloat;
	
	public int OtherInt
	{
		get 
		{ 	
			return _somePrivateInt;
		}
	}

	void Start () {
		Validator.Validate<ValidatorTest>(this);
	}
}
