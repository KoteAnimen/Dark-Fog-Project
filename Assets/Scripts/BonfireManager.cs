using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireManager : MonoBehaviour
{
	
	
	
	private PlayerManager pm;
	[HideInInspector]
	public GameObject actPanel;
	[HideInInspector]
	public UIController ui;
	public GameObject[] bonfires;
	public GameObject player;
	
    void Awake()
	{
		actPanel = GameObject.Find("Activate");
		pm = GameObject.Find("Player").GetComponent<PlayerManager>();
		ui = GameObject.Find("Player").GetComponent<UIController>();
		actPanel.SetActive(false);
	}

	public void TravelFunction(int idBonfire)
	{
		GameObject teleportPoint = bonfires[idBonfire].transform.Find("tPoint").gameObject;
		player.transform.position = teleportPoint.transform.position;//проблема в этой строке, не хочет перемещать игрока.
		pm.lastBonfire = teleportPoint;		
		
		
	}
    
}
