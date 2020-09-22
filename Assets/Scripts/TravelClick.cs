using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TravelClick : MonoBehaviour, IPointerDownHandler
{
    public int idBonfire;
	private BonfireManager bm;
	private GameObject teleportMenu;
	private controller player;
	
	void Awake()
	{
		bm = GameObject.Find("Player").GetComponent<BonfireManager>();
		teleportMenu = GameObject.Find("Teleport");
		player = GameObject.Find("Player").GetComponent<controller>();
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		bm.TravelFunction(idBonfire);
		teleportMenu.SetActive(false);
		player.enabled = true;
	}
}
