using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionPhase : MonoBehaviour
{

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void Update()
    {
        // Début de la phase de destruction
        if (Game.DestructionPhase)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}