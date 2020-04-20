using UnityEngine;

/// <summary>
/// Методы для установок объекта
/// </summary>
public abstract class ControllerSetuper: MonoBehaviour
{
	/// <summary>
	/// Позиция предыдущего объекта по оси Х
	/// </summary>
	protected Vector3 lastObjectPosition = Vector3.zero;

	/// <summary>
	/// Установить позицию objTransform
	/// </summary>
	protected virtual void setupPosition(Transform objTransform) { }

	/// <summary>
	/// Установить вращение objTransform
	/// </summary>
	protected virtual void setupRotation(Transform objTransform) { }

	/// <summary>
	/// Установить размер objTransform
	/// </summary>
	protected virtual void setupScale(Transform objTransform) { }

	/// <summary>
	///  Переопределяемый метод для настройки объекта
	/// </summary>
	protected virtual void setupObject(PoolObject obj) { }
}