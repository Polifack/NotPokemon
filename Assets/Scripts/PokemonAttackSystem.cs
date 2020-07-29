using System.Collections;
using UnityEngine;

public class PokemonAttackSystem : MonoBehaviour
{
    public float attackCooldown;    //Attack cooldown in seconds
    public CooldownBar cooldownBar; //Cooldown bar
    
    private float _currentCooldown;

    public Attack attack;

    private IEnumerator executeAttack()
    {
        Debug.Log("Attacking");
        StartCoroutine(attack.executeAttack());
        yield return null;
    }
    private IEnumerator doCooldown()
    {
        cooldownBar.enableCooldownBar();
        while (_currentCooldown < attackCooldown)
        {
            cooldownBar.setPercentage(_currentCooldown / attackCooldown);
            Debug.Log("Cooldown: "+_currentCooldown);
            _currentCooldown += Time.deltaTime;
            yield return null;
        }
        cooldownBar.disableCooldownBar();
    }


    public void doAttack()
    {
        if (_currentCooldown >= attackCooldown)
        {
            _currentCooldown = 0;
            StartCoroutine(executeAttack());
            StartCoroutine(doCooldown());
        }
    }


    private void Awake()
    {
        _currentCooldown = attackCooldown;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            doAttack();
        }
    }
}
