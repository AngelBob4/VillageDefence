using UnityEngine;

public class Generator : MonoBehaviour
{
    private float _radiusOfMap = 36f;
    private float _raisedRadiusOfMap;

    private void Awake()
    {
        _raisedRadiusOfMap = Mathf.Pow(_radiusOfMap, 2);
    }

    protected void SetPositionOnRadius(GameObject gameObject, float radius, Player player)
    {
        Vector3 newPosition = SetRandomPosition(radius, player);
        gameObject.gameObject.transform.position = newPosition;
    }

    private Vector3 SetRandomPosition(float radius, Player player)
    {
        float positionX = Random.Range(-radius, radius);
        float positionZ = Mathf.Pow((Mathf.Pow(radius, 2) - Mathf.Pow(positionX, 2)), 0.5f);
        float randomSign = Random.Range(-1, 1);
        positionZ = positionZ * Mathf.Sign(randomSign);
        Vector3 offset = new Vector3(positionX, 0, positionZ);
        Vector3 newPosition = new Vector3(offset.x + player.Position.x, 0, positionZ + player.Position.z);

        if ((Mathf.Pow(newPosition.x, 2) + (Mathf.Pow(newPosition.z, 2))) > _raisedRadiusOfMap)
        {
            Vector3 positionInCorrectArea = player.Position;
            positionInCorrectArea -= offset;
            newPosition = positionInCorrectArea;
        }

        return newPosition;
    }
}