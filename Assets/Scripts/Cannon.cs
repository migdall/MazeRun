using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public float rayDistance = 10;

	private RaycastHit hit;
	private Ray ray;

	private GameObject cannonBase;
	private GameObject cannonBarrel;
	private Material cannonBaseMaterial;
	private Material cannonBarrelMaterial;

	// Use this for initialization
	void Awake () {
		cannonBase = transform.Find ("Base").gameObject;
		cannonBarrel = transform.Find ("Barrel").gameObject;
		cannonBaseMaterial = cannonBase.GetComponent<Renderer> ().material;
		cannonBarrelMaterial = cannonBarrel.GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		ray = new Ray (transform.position, transform.forward);
		Debug.DrawRay (ray.origin, ray.direction * rayDistance, Color.red);

		if (Physics.Raycast (ray, out hit)) {
			if (hit.distance < rayDistance) {
				cannonBaseMaterial.color = Color.black;
				cannonBarrelMaterial.color = Color.yellow;
			}
		} else {
			cannonBaseMaterial.color = Color.white;
			cannonBarrelMaterial.color = Color.white;
		}
	}
}
