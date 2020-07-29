using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PokemonVisuals))]
public class PokemonMovementSystem : MonoBehaviour
{
    public float movementSpeed;

    private Vector3 _lastMovement = Vector3.zero;
    private Vector3 _movement = Vector3.zero;

    private PokemonVisuals _visuals;

    private void getInput()
    {
        _movement = new Vector3(
            movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 
            movementSpeed * Time.deltaTime * Input.GetAxis("Vertical"), 
            0);

        Vector3 delta = _movement - _lastMovement;

        _visuals.doFlip(delta.x > 0);

        if (delta.y > 0) _visuals.doBackward();
        if (delta.y < 0) _visuals.doForward();
    }
    private void doMove()
    {
        transform.Translate(_movement);
    }

    private void Awake()
    {
        _visuals = gameObject.GetComponent<PokemonVisuals>();
    }
    private void Update()
    {
        getInput();
        doMove();
    }
}
