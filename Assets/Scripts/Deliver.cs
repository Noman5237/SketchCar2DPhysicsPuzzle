using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour {
	private bool _delivered;

	private void OnCollisionEnter2D(Collision2D other) {
		if (_delivered) {
			return;
		}

		if (other.gameObject.CompareTag("Car")) {
			Debug.Log("Delivery Complete");
			_delivered = true;
		}
	}
}