﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrouchState : CharacterBaseState
{
    public string Crouch = "s";
    public string Punch = "j";
    public override void EnterState(CharacterStateManager character)
    {
        character.currentEnum = CharacterStateManager.States.CharacterCrouchState;
        Crouch = character.Crouch;
        Punch = character.Punch;

        character.Leg1.SetActive(false);
        character.Leg2.SetActive(true);
        character.transform.localPosition = new Vector3(character.transform.localPosition.x, 2.1f, character.transform.localPosition.z);

    }

    public override void OnCollisionEnter(CharacterStateManager character, Collision collision)
    {
        
    }

    public override void TakeDamage(CharacterStateManager character, int Damage)
    {
        if(Damage == 15)
        {
            character.gameManager.TakeDamage(character.IsPlayer1, Damage/5);
        }
        else
        {
            character.gameManager.TakeDamage(character.IsPlayer1, Damage/2);
        }
        character.SwitchState(character.CharacterCrouchAndBlockState);
    }

    public override void UpdateState(CharacterStateManager character)
    {
     /*
        if (Input.GetKeyDown(Punch))
        { 
            character.SwitchState(character.CharcterCrouchPunchState);
        }   
        if (!Input.GetKey(Crouch))
        {
            character.Leg1.SetActive(true);
            character.Leg2.SetActive(false);
            character.transform.position = new Vector3(character.transform.position.x, 3f, character.transform.position.z);
            character.SwitchState(character.CharacterMoveState);
        } 
        */
        character.transform.position = new Vector3(character.transform.position.x, 2.5f, character.transform.position.z);
    }
    public override void AIinput (CharacterStateManager character, string input)
    {
        // punch
        if(input == "j")
        {
            character.SwitchState(character.CharcterCrouchPunchState);
        }
        // stop crouch 
        else if (input != "s")
        {
            character.Leg1.SetActive(true);
            character.Leg2.SetActive(false);
            character.transform.localPosition = new Vector3(character.transform.localPosition.x, 3f, character.transform.localPosition.z);
            character.SwitchState(character.CharacterMoveState);
        }
    }
}
