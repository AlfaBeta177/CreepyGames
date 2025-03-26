using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoDialogo", menuName = "Dialogo/Nodo")]
public class DialogoNodo : ScriptableObject
{
    [Header("Contenido del di�logo")]
    public string nombre;                      // Nombre del personaje
    [TextArea(3, 10)]
    public string texto;                       // Texto del di�logo
    public Sprite imagenPersonaje;            // Imagen del personaje que habla

    [Header("Flujo del di�logo")]
    public DialogoNodo nodoSiguiente;         // Para di�logos lineales (Z para continuar)
    public List<OpcionDialogo> opciones;      // Para respuestas interactivas (botones)
}
