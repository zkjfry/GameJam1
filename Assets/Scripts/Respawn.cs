using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

	public float boundary;

	void FixedUpdate() {
		if (transform.position.y < boundary) {
			transform.position = new Vector3(0, 5, 0);
		}
	}

}
