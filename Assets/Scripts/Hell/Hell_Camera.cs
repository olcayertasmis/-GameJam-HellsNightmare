using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_Camera : MonoBehaviour
{
	public Transform camTransform;
	public static float shakeDuration = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	Vector3 originalPos;

    public GameObject player;
    private Vector3 Pos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
            originalPos = camTransform.localPosition;
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
		}
	}

    private void FixedUpdate() {
        Pos = player.transform.position - gameObject.transform.position;
        Pos.z = 0;
        gameObject.transform.position += Pos / 40;
    }

}
