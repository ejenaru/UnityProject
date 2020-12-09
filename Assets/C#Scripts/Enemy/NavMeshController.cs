using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NavMeshController : MonoBehaviour
{
	public Transform targetPlayer;
	public Transform actualTarget;

	public float attackRange = 10;
	IAstarAI ai;

	void OnEnable()
	{
		ai = GetComponent<IAstarAI>();
		if (ai != null) ai.onSearchPath += Update;
		
	}

	void OnDisable()
	{
		if (ai != null) ai.onSearchPath -= Update;
	}

	void Update()
	{
		if (actualTarget != null && ai != null) ai.destination = actualTarget.position;
      
	}

	public void ActualizarPuntoDestino(Vector3 puntoDestino)
    {
		actualTarget.position = puntoDestino;
		ai.canMove = true;
    }
	public void ActualizarPuntoDestino()
    {
		ActualizarPuntoDestino(targetPlayer.position);
    }

	public bool HemosLlegado()
    {
		return ai.reachedDestination;
    }
}
