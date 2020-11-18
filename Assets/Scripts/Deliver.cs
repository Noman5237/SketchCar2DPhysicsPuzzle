using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour {
	private bool _delivered;

	private void OnTriggerEnter2D(Collider2D other) {
		if (_delivered) {
			return;
		}

		if (other.gameObject.CompareTag("Load")) {
			Debug.Log("Delivery Complete");
			_delivered = true;
			GameObject o;
			(o = other.gameObject).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			o.transform.position = gameObject.transform.position;
			o.transform.rotation = Quaternion.identity;
			other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}