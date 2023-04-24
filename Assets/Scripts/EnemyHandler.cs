using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle the life of the enemy and how his work
/// Take damage and dead
/// </summary>
public class EnemyHandler : MonoBehaviour
{
    [SerializeField]
    float angleDetection = 65.0f;
    [SerializeField]
    float damage = 10f;
    [SerializeField]
    float distanceDetection = 10.0f;
    [SerializeField]
    float distanceOfAttack = 1f;
    [SerializeField]
    float healthMax = 100f;
    [SerializeField]
    GameObject healthBarUI;
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    LayerMask RaycastIgnore;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    Slider slider;
    [SerializeField]
    RuntimeAnimatorController[] animations;

    private Transform cameraTransform;
    private Animator enemyAnimator;
    private float health;
    private bool isDead = false;
    private bool playerDetected = false;
    private Vector3 startPosition;
    private Vector3 endPosition;


    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPosition = transform.position;
        endPosition = startPosition;
        health = healthMax;
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        slider.value = health;
        CanvasRotation();
        PlayerDetection();
    }

    /// <summary>
    /// Change the health of the enemy
    /// </summary>
    /// <param name="damage">Damage deal by the playerTransform</param>
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

        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;

        enemyAnimator.runtimeAnimatorController = animations[2];

        Destroy(gameObject, 2f);
    }

    // Detect the player on his field of view and calculate the distance to go face of the player
    void PlayerDetection()
    {
        if (!playerDetected)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            float angleToPlayer = Vector3.Angle(directionToPlayer, transform.forward);

            if (angleToPlayer < angleDetection)
            {
                RaycastHit infoCollision;

                if (Physics.Raycast(transform.position, directionToPlayer, out infoCollision, distanceDetection, ~RaycastIgnore))
                {
                    if (infoCollision.collider.tag == "Player")
                    {
                        playerDetected = true;
                    }
                }
            }
        }
        else
        {
            endPosition = playerTransform.position;

            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < distanceOfAttack)
            {
                StartCoroutine(AttackPlayer());
            }
            else
            {
                EnemyMovement();
            }
        }
    }

    // Move to the player
    void EnemyMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        transform.LookAt(playerTransform);
        enemyAnimator.runtimeAnimatorController = animations[4];
    }

    // Turn the canvas in the direction of the player
    void CanvasRotation()
    {
        Quaternion lookat = cameraTransform.rotation;
        healthBarUI.transform.rotation = lookat;
    }

    // Start the animation of the attack
    IEnumerator AttackPlayer()
    {
        enemyAnimator.runtimeAnimatorController = animations[0];

        yield return new WaitWhile( () => enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);
    }
}