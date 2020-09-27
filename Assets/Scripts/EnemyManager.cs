using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool isDead;
	public float health;//жизни
	public float strength;//сила
	public float agility;//ловкость
	public float stamina;//выносливость
	public float intelligence;//интеллект
	public float mana;// кол-во маны	
	private Vector3 startPosition = new Vector3();
	void Start()
    {
        startPosition = transform.position;
		SetRigidbodyState(true);
		SetColliderState(false);
		
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyDead(isDead);
		AliveEnemy(isDead);
    }
	
	public void EnemyDead(bool dead)
	{
		if(dead)
		{
			GetComponent<Animator>().enabled = false;
			SetRigidbodyState(false);
			SetColliderState(true);
		}
	}
	public void AliveEnemy(bool dead)
	{
		if(!dead)
		{
			GetComponent<Animator>().enabled = true;
			SetRigidbodyState(true);
			SetColliderState(false);
		}
	}
	void SetRigidbodyState(bool state)
	{
		Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();// через похожую лабуду найдем начальную позицию всех костей, чтоб потом их на место поставить:D
		foreach(Rigidbody rigidbody in rigidbodies)
		{
			rigidbody.isKinematic = state;
		}
		GetComponent<Rigidbody>().isKinematic = !state;
	}
	
	void SetColliderState(bool state)
	{
		Collider[] colliders = GetComponentsInChildren<Collider>();
		foreach(Collider collider in colliders)
		{
			collider.enabled = state;
		}
		GetComponent<Collider>().enabled = !state;
	}
}
