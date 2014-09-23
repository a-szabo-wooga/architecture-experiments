using UnityEngine;
using System;
using System.Collections;

public class ValidatorTest : MonoBehaviour {

	[MyAttribute]
	public int SomeInt;
	
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
