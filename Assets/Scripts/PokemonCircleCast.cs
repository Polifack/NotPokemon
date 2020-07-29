using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PokemonCircleCast : MonoBehaviour
{
    public float a = 5;
    public float b = 3;
    public float h = 1;
    public float k = 1;
    public float theta = 45;
    public int resolution = 1000;

    private Vector3[] positions;

    Vector3[] CreateEllipse(float a, float b, float h, float k, float theta, int resolution)
    {

        positions = new Vector3[resolution + 1];
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);
        Vector3 center = new Vector3(transform.position.x, transform.
            position.y, 0.0f);

        for (int i = 0; i <= resolution; i++)
        {
            float angle = (float)i / (float)resolution * 2.0f * Mathf.PI;
            positions[i] = new Vector3(a * Mathf.Cos(angle), b * Mathf.Sin(angle), 0.0f);
            positions[i] = q * positions[i] + center;
        }

        return positions;
    }

    void doCast()
    {
        RaycastHit2D[] collisions = Physics2D.CircleCastAll(transform.position, a, Vector2.right);
        foreach(RaycastHit2D c in collisions)
        {
            Debug.Log(c.collider.gameObject.name);
        }
    }


    private void Update()
    {
        positions = CreateEllipse(a, b, h, k, theta, resolution);
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetVertexCount(resolution + 1);
        for (int i = 0; i <= resolution; i++)
        {
            lr.SetPosition(i, positions[i]);
        }

        doCast();
    }
}
