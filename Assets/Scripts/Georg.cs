using UnityEngine;
using System.Collections;

public class Georg : MonoBehaviour {

	private aServiceLocator _serLoc;
	private IANotherService _anotherService;
	private IAGearService _agearService;

	void Awake()
	{
		_serLoc = aServiceLocator.Instance;
		_anotherService = aNotherManager.Instance;
		_agearService = aGearManager.Instance;

		_anotherService.Init();
		_agearService.Init();
	}
}
