using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitialLoading : MonoBehaviour
{	
	private List<int>		_myList = new List<int>();

	void Awake()
	{
		ServiceLocator.Instance.Init();
		FillUp(_myList, 10);
		foreach(int i in _myList)
		{
			Debug.Log(i);
		}
	}

	private void FillUp(List<int> lista, int count)
	{
		for(int i = 0; i < count; ++i)
		{
			lista.Add(i);
		}
	}
}
