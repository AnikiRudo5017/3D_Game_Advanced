using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent _agent;
    private Animator _animator;
    private string currentAnim;

    [SerializeField] private float detectionRange = 10.0f;
    [SerializeField] private float attackRange = 1.5f;
    private bool isAttacking = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= detectionRange)
        {
            if (distance > attackRange)
            {
                changeAnim("Run");
                _agent.SetDestination(target.position);
            }
            else
            {
                changeAnim("Run");
            }
        }
        else
        {
            changeAnim("Idle");
        }
    }
    private void changeAnim(string AnimName)
    {
        if (currentAnim != AnimName)
        {
            _animator.ResetTrigger(AnimName);
            currentAnim = AnimName;
            _animator.SetTrigger(currentAnim);

        }
    }
}