using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour 
{
	public GameObject ui;

	private Node target;

	public void SetTarget(Node t)
	{
		target = t;

		transform.position = target.BuildPosition;
		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}
}
