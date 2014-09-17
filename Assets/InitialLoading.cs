using UnityEngine;
using System.Collections;

public class InitialLoading : MonoBehaviour
{	
	void Awake()
	{
		ServiceLocator.Instance.Init();
	}
}
