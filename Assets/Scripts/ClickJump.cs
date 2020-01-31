using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickJump : MonoBehaviour
{
    public Vector2 force;
    public Component mainCharacter;
    
    private Rigidbody2D mainCharacterRB2D;
    private void OnMouseUp()
    {
        mainCharacterRB2D.AddForce(force, ForceMode2D.Impulse);
    }
    

    private void Start()
    {
        mainCharacterRB2D = mainCharacter.GetComponent<Rigidbody2D>();
        
    }
    
}
