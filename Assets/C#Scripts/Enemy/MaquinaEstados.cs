using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstados : MonoBehaviour
{
    public MonoBehaviour estadoPatrulla;
    public MonoBehaviour estadoPersecucion;
    public MonoBehaviour estadoInicial;

    private MonoBehaviour estadoActual;


    private void Start()
    {
        ActivarEstado(estadoInicial);
    }
    

    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if (estadoActual != null)
        {
            estadoActual.enabled = false;
        }

        estadoActual = nuevoEstado;
        estadoActual.enabled = true;
    }
}
