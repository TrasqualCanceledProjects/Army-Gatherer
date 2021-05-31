using System;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] protected float detectionRange = 10f;
    public CharacterType charactersType;

    public event Action OnAttack;

    protected Transform target;

    protected void GetNearestCharacter(CharacterType characterType)
    {
        float maxDistance = Mathf.Infinity;
        Transform closestTarget = null;
        var collidersInRange = Utilities.GetCollidersInRange(transform.position, detectionRange);
        if (collidersInRange != null)
        {
            foreach (var collider in collidersInRange)
            {
                if(collider.GetComponent<CharacterBase>() != null)
                {
                    if (collider.GetComponent<CharacterBase>().charactersType == characterType)
                    {
                        float distance = Vector3.Distance(transform.position, collider.transform.position);

                        if (distance < maxDistance)
                        {
                            closestTarget = collider.transform;
                            maxDistance = distance;
                        }
                    }
                }
            }
            target = closestTarget;
        }
        else
        {
            target = null;
        }

    }

    protected void Attack()
    {
        transform.LookAt(target);
        OnAttack?.Invoke();
    }
}
