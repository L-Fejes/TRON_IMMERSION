using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererWithCollider : MonoBehaviour {

	public TrailRenderer trail;
	public bool colliderIsTrigger = true;
	public bool colliderEnabled = true;

	private new BoxCollider[] walls;

}
