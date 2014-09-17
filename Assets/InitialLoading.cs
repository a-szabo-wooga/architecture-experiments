using UnityEngine;
using System.Collections;

public class InitialLoading : MonoBehaviour
{
	private	ServiceLocator SerLock;
	
	void Awake()
	{
		SerLock = new ServiceLocator();
	}
}
