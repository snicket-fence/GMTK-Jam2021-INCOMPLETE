using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;

	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer > 0)
			Destroy(this.gameObject);
		if (col.gameObject.tag == "Box")
			Destroy(col.gameObject);
	}
}
