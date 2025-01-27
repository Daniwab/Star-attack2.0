
/* using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referência à nave
    public Vector3 offset = new Vector3(0, 10, 10); // Posição relativa da câmera em relação à nave
    public float followSpeed = 5f; // Velocidade de transição da posição
    public float rotationSpeed = 5f; // Velocidade de ajuste da rotação

    void LateUpdate()
    {
        if (target == null) return; // Verifica se a nave está definida

        // Calcula a posição desejada da câmera com base na posição da nave e no offset
        Vector3 targetPosition = target.position + target.TransformDirection(offset);

        // Atualiza a posição da câmera suavemente para acompanhar a nave
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Mantém a rotação da câmera olhando para a nave
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}*/
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // A nave que a câmera deve seguir
    public Vector3 offset; // Distância da câmera em relação à nave
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento

    void LateUpdate()
    {
        // Calcula a posição desejada da câmera
        Vector3 desiredPosition = target.position + offset;

        // Move a câmera suavemente para a posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Sempre olha para o alvo (opcional)
        transform.LookAt(target);
    }
}
