using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion : MonoBehaviour
{
    

    private MaquinaEstados maquinaDeEstados;
    private NavMeshController controladorNavMesh;
    private ControlVision controladorVision;

    private void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaEstados>();
        controladorNavMesh = GetComponent<NavMeshController>();
        controladorVision = GetComponent<ControlVision>();
        
    }
    private void OnEnable()
    {
        controladorNavMesh.ActualizarPuntoDestino();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controladorVision.PuedeVerAlJugador())
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.estadoPatrulla);
            return;
        }
        controladorNavMesh.ActualizarPuntoDestino();
    }
}
