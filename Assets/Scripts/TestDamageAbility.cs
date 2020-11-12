using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TestDamageAbility : MonoBehaviour,IDamage
{
    public int AttackDamageTest;
    public LayerMask AttackMask;
    public GameControls Controls;

    // Start is called before the first frame update

    private void Awake()
    {
        Controls = new GameControls();

        Controls.Player.Ability1.performed += AtkTest;
    }
    private void OnEnable()
    {
        Controls.Enable();
    }
    private void OnDisable()
    {
        Controls.Disable();
    }
    public void DamageTo(int Damage)
    {

    }
    public void AtkTest(InputAction.CallbackContext context)
    {
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, 1.5f,AttackMask);
        foreach(Collider2D target in hitTargets)
        {
            target.GetComponent<IDamage>().DamageTo(AttackDamageTest);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }

}
