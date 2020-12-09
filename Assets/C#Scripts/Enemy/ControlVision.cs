using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVision : MonoBehaviour
{
    public Transform[] targetPatrol;
    public Transform ojos;
    public float rangoVision = 10f;

    private NavMeshController controladorNavmesh;

    private void Awake()
    {
        controladorNavmesh = GetComponent<NavMeshController>();
    }

    public bool PuedeVerAlJugador()
    {

        return (transform.position - controladorNavmesh.targetPlayer.position).magnitude < rangoVision;

    }
}
