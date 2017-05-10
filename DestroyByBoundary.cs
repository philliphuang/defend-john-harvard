// destroys any object outside of boundary
using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	// destroy any object outside of boundary
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}