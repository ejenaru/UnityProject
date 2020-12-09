using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : MonoBehaviour
{
    public Transform[] puntosRuta;
    private MaquinaEstados maquinaDeEstados;
    private NavMeshController controladorNavMesh;
    private ControlVision controladorVision;

    private int siguientePuntoRuta;

    private void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaEstados>();
        controladorNavMesh = GetComponent<NavMeshController>();
        controladorVision = GetComponent<ControlVision>();
        siguientePuntoRuta = 0;
    }

    private void Update()
    {
        if (controladorVision.PuedeVerAlJugador())
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.estadoPersecucion);
            return;
        }
        if (controladorNavMesh.HemosLlegado())
        {
            siguientePuntoRuta = (siguientePuntoRuta+1)% puntosRuta.Length;
            ActualizarPuntoRuta();
        }
        

    }
    private void ActualizarPuntoRuta()
    {
        controladorNavMesh.ActualizarPuntoDestino(puntosRuta[siguientePuntoRuta].position);
    }
    private void OnEnable()
    {
        ActualizarPuntoRuta();
    }
}
