using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Collider[] InRangeCheck(Vector3 centerPosition, float radius)
    {
        return Physics.OverlapSphere(centerPosition, radius);
    }

    public static Transform GetClosestFromList(List<Collider> colliderList, Transform toTransform)
    {
        return colliderList.OrderBy(x => (x.transform.position - toTransform.position)).First().transform;
    }
}
