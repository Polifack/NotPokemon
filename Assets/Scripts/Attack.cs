using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject fire;
    public GameObject target;

    public IEnumerator executeAttack()
    {
        GameObject f = Instantiate(fire, transform);
        f.transform.SetParent(null);

        while (fire.transform.position != target.transform.position)
        {
            f.transform.position = Vector3.MoveTowards(f.transform.position, target.transform.position, 5f*Time.deltaTime);
            yield return null;
        }

        Destroy(f);
    }
}
