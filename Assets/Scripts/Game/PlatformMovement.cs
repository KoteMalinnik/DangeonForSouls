using UnityEngine;

/// <summary>
/// Движение объекта по оси Х с постоянной скоростью
/// </summary>
public class PlatformMovement : MonoBehaviour
{
	[SerializeField]
	/// <summary>
	/// Скорость движения
	/// </summary>
	float movementSpeed = 1f;

	Transform cachedTransform = null;
    void Awake()
    {
		cachedTransform = transform;
    }

	Vector3 deltaPosition = Vector3.zero;
    void Update()
    {
		deltaPosition = new Vector3(movementSpeed * Time.deltaTime, 0, 0);
		cachedTransform.position -= deltaPosition;
    }
}
