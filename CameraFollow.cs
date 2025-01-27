
/* using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    public Transform target; // Refer�ncia � nave
    public Vector3 offset = new Vector3(0, 10, 10); // Posi��o relativa da c�mera em rela��o � nave
    public float followSpeed = 5f; // Velocidade de transi��o da posi��o
    public float rotationSpeed = 5f; // Velocidade de ajuste da rota��o

    void LateUpdate()
    {
        if (target == null) return; // Verifica se a nave est� definida

        // Calcula a posi��o desejada da c�mera com base na posi��o da nave e no offset
        Vector3 targetPosition = target.position + target.TransformDirection(offset);

        // Atualiza a posi��o da c�mera suavemente para acompanhar a nave
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Mant�m a rota��o da c�mera olhando para a nave
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}*/
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // A nave que a c�mera deve seguir
    public Vector3 offset; // Dist�ncia da c�mera em rela��o � nave
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o do movimento

    void LateUpdate()
    {
        // Calcula a posi��o desejada da c�mera
        Vector3 desiredPosition = target.position + offset;

        // Move a c�mera suavemente para a posi��o desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Sempre olha para o alvo (opcional)
        transform.LookAt(target);
    }
}
