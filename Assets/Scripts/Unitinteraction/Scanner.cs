using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
	
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit[] targets;
    public Transform nearestTarget;

	private void FixedUpdate()
	{
		targets = Physics.SphereCastAll(transform.position, scanRange, Vector3.forward,0,targetLayer);
		nearestTarget = GetNearest();
	}

	Transform GetNearest() {

		Transform result = null;
		float diff = Mathf.Infinity;

		foreach (RaycastHit target in targets) {
			Vector3 myPos = transform.position;
			Vector3 targetPos = target.transform.position;
			float curDiff = Vector3.Distance(myPos, targetPos);

			if (curDiff < diff) {
				diff = curDiff;
				result = target.transform;
			}
		
		}
		
		return result;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, scanRange);
	}
}

