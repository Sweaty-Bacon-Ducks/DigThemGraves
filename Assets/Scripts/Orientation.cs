using UnityEngine;
using Pathfinding;

public class Orientation : MonoBehaviour
{
    void Update()
    {
        Vector3 moveDirection = GetComponent<AIPath>().steeringTarget - transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            if (angle < 0)
                angle = 360 + angle;
            GetComponent<Animator>().SetFloat("Rotation", angle);
        }
    }
}
