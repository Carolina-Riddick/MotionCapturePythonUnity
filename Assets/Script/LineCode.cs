using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCode : MonoBehaviour
{
    LineRenderer LineRenderer;
    [SerializeField] Transform origin;
    [SerializeField] Transform destination;

    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.startWidth = 0.1f;
        LineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        // We are setting the starting point as our origin position / Estamos a la posicion de origen como el punto de partida (0) de la linea, y a su vez configurando como el final de la linea (1) como la position de destino

        LineRenderer.SetPosition(0, origin.position);
        LineRenderer.SetPosition(1, destination.position);
    }
}