using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoDialogo", menuName = "Dialogo/Nodo")]
public class DialogoNodo : ScriptableObject
{
    [Header("Contenido del diálogo")]
    public string nombre;                      // Nombre del personaje
    [TextArea(3, 10)]
    public string texto;                       // Texto del diálogo
    public Sprite imagenPersonaje;            // Imagen del personaje que habla

    [Header("Flujo del diálogo")]
    public DialogoNodo nodoSiguiente;         // Para diálogos lineales (Z para continuar)
    public List<OpcionDialogo> opciones;      // Para respuestas interactivas (botones)
}
