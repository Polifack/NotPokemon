using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonEnemy : MonoBehaviour
{
    public MeshCollider meshField;
    public PokemonVisuals _visuals;
    private Vector3 _next = Vector3.zero;
    bool isComputing = false;

    public bool checkIfPointValid(Vector3 pos)
    {
        return (meshField.bounds.Contains(pos));
    }

    IEnumerator computeNextPosition()
    {
        isComputing = true;
        Vector3 nextPos = transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        while (!checkIfPointValid(nextPos)){
            nextPos = transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            yield return null;
        }
        _next = nextPos;
        Vector3 delta = _next - transform.position;

        _visuals.doFlip(delta.x > 0);

        if (delta.y > 0) _visuals.doBackward();
        if (delta.y < 0) _visuals.doForward();
        isComputing = false;
    }
    private void Start()
    {
        StartCoroutine(computeNextPosition());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _next, 3f * Time.deltaTime);
        if ((Vector3.Distance(transform.position, _next) < 0.1f)&&!isComputing)
            StartCoroutine(computeNextPosition());
    }
}
