using UnityEngine;
using Pathfinding;

public class PlayerAnimationView : MonoBehaviour
{
    public AIPath aiPath;
    private Animator animator;

    [SerializeField]
    private float speedMultiplier;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 moveDirection = aiPath.steeringTarget - transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = CalculateRotation(moveDirection);
            float velocity = aiPath.velocity.magnitude * speedMultiplier;
            SetAnimatorParameters(angle, velocity);
        }
    }

    private float CalculateRotation(Vector2 moveDirection)
    {
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        if (angle < 0)
            angle = 360 + angle;
        return angle;
    }

    private void SetAnimatorParameters(float angle, float velocity)
    {
        animator.SetFloat("Rotation", angle);
        animator.SetFloat("Speed", velocity);
    }
}
