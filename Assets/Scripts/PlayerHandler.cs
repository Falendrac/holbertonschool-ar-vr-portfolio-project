using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField]
    float healthMax = 100f;
    [SerializeField]
    GameObject deadCanvas;
    [SerializeField]
    GameObject leftHand;
    [SerializeField]
    GameObject rightHand;

    private float health;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Change the health of the player
    /// </summary>
    /// <param name="damage">Damage deal by the Enemy</param>
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && !isDead)
        {
            Dead();
        }
    }

    // Called when the enemy have not enough health and will be destroyed
    void Dead()
    {
        isDead = true;
    }
}
