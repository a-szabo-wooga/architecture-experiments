using UnityEngine;
using System.Collections;

public class SomeOtherScript : MonoBehaviour {
	
	void Start () {
		var s = aServiceLocator.Instance.GetService("GearService") as IAGearService;
		s.DoStuff();

		var x = aServiceLocator.Instance.GetService("AnotherService") as IANotherService;
		x.DoStuff();
	}

}
