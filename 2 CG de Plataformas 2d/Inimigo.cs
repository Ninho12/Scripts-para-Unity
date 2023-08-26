using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    private Vector3 targetPoint;

    private void Start()
    {
        targetPoint = patrolPoints[currentPatrolIndex].position;
    }

    private void Update()
    {
        // Move o inimigo em direção ao ponto de patrulha atual
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        // Verifica se o inimigo alcançou o ponto de patrulha
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            // Muda para o próximo ponto de patrulha
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            targetPoint = patrolPoints[currentPatrolIndex].position;

            // Inverte a escala horizontal para mudar a direção do inimigo
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}
