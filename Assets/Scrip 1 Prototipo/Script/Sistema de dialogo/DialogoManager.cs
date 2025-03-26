using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoManager : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI nombreText;
    public TextMeshProUGUI dialogoText;
    public Image imagenPersonaje;
    public GameObject panelDeBotones;
    public Button prefabBoton;

    [Header("Nodo inicial")]
    public DialogoNodo nodoInicial;
    private DialogoNodo nodoActual;

    void Start()
    {
        IniciarDialogo(nodoInicial);
    }

    void Update()
    {
        if (nodoActual != null && nodoActual.opciones.Count == 0 && nodoActual.nodoSiguiente != null)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                IrAlNodo(nodoActual.nodoSiguiente);
            }
        }
    }

    public void IniciarDialogo(DialogoNodo nodo)
    {
        IrAlNodo(nodo);
    }

    void IrAlNodo(DialogoNodo nodo)
    {
        nodoActual = nodo;

        // Mostrar contenido del nodo actual
        nombreText.text = nodoActual.nombre;
        dialogoText.text = nodoActual.texto;
        imagenPersonaje.sprite = nodoActual.imagenPersonaje;

        // Limpiar botones anteriores
        foreach (Transform hijo in panelDeBotones.transform)
        {
            Destroy(hijo.gameObject);
        }

        // Si hay opciones, crear botones
        if (nodoActual.opciones != null && nodoActual.opciones.Count > 0)
        {
            panelDeBotones.SetActive(true);

            foreach (OpcionDialogo opcion in nodoActual.opciones)
            {
                Button nuevoBoton = Instantiate(prefabBoton, panelDeBotones.transform, false);
                nuevoBoton.gameObject.SetActive(true); // Asegurarse de que esté activo

                TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
                textoBoton.text = opcion.texto;

                DialogoNodo destino = opcion.nodoDestino;
                nuevoBoton.onClick.AddListener(() => IrAlNodo(destino));
            }
        }
        else
        {
            panelDeBotones.SetActive(false);
        }
    }
}
