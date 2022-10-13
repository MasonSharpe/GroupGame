using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDestroy : MonoBehaviour
{
	public GameObject Sword;
	void OnCollisionEnter2D(Collision2D collision)
	{
		string otherTag = collision.gameObject.tag;
		if (otherTag == "Enemy")
		{
			GameObject.Destroy(Sword);
		}
	}
}