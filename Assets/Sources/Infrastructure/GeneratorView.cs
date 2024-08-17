using UnityEngine;

public class GeneratorView : MonoBehaviour
{
    protected void SetPositionOnRadius(GameObject gameObject, float radius, Player player)
    {
        float positionX = Random.Range(-radius, radius);
        float positionZ = Mathf.Pow((Mathf.Pow(radius, 2) - Mathf.Pow(positionX, 2)), 0.5f);

        float randomSign = Random.Range(-1, 1);
        positionZ = positionZ * Mathf.Sign(randomSign);

        Vector3 offset = new Vector3(positionX, 0, positionZ);
        Vector3 newPosition = new Vector3(offset.x + player.Position.x, 0, positionZ + player.Position.z);
        gameObject.gameObject.transform.position = newPosition;
    }
}