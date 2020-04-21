using UnityEngine;

/// <summary>
/// Рассчет очков
/// </summary>
public class ScoreEnumerator : MonoBehaviour
{
	[SerializeField, Range(1, 10)]
	/// <summary>
	/// Прямопропорциональный коэффициент. От него зависит итеррация счета за один кадр
	/// </summary>
	float scoreCoefficient = 2;

	/// <summary>
	/// Текущий счет
	/// </summary>
	float score = 0;

    void Update()
	{
		if (!Statements.gameOver && !Statements.pause) calculateScore();
	}

	/// <summary>
	/// Рассчет текущих очков
	/// </summary>
	void calculateScore()
	{
		if (Movement.verticalDirection == 0) return; //verticalDirection не равно 0 только после какого-либо касания

		//считаем очки, если игрок начал управлять сферой
		score += Time.deltaTime * scoreCoefficient;

		if(score > 1)
		{
			score--;
			ValuesController.incrementScoreValue();
		}
	}
}
