using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Collider[] GetCollidersInRange(Vector3 centerPosition, float radius)
    {
        return Physics.OverlapSphere(centerPosition, radius);
    }

    public static Transform GetClosestFromList(List<Collider> colliderList, Transform toTransform)
    {
        return colliderList.OrderBy(x => (x.transform.position - toTransform.position)).First().transform;
    }

    public static int CalculateIncrementalValue(int valueToIncrease, int incrementAmount, int incrementTimes)
    {
        var newValue = valueToIncrease;
        for (int i = 0; i < incrementTimes; i++)
        {
            newValue += i * incrementAmount;
        }
        return newValue;
    }

    public static Quaternion GetRandomDirection(int angle)
    {
        return Quaternion.Euler(Random.insideUnitSphere * angle);
    }
}

