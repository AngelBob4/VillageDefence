using UnityEngine;
using View.PlayerComponents;

namespace Infrastructure
{
    public class Generator : MonoBehaviour
    {
        private float _radiusOfMap = 36f;
        private float _raisedRadiusOfMap;

        private void Awake()
        {
            _raisedRadiusOfMap = _radiusOfMap * _radiusOfMap;
        }

        protected void SetPositionOnRadius(GameObject gameObject, float radius, Player player)
        {
            Vector3 newPosition = SetRandomPosition(radius, player);
            gameObject.gameObject.transform.position = newPosition;
        }

        private Vector3 SetRandomPosition(float radius, Player player)
        {
            float positionX = Random.Range(-radius, radius);
            float positionZ = Mathf.Pow(radius * radius - positionX * positionX, 0.5f);
            float randomSign = Random.Range(-1, 1);
            positionZ = positionZ * Mathf.Sign(randomSign);
            Vector3 offset = new Vector3(positionX, 0, positionZ);
            Vector3 newPosition = new Vector3(offset.x + player.Position.x, 0, positionZ + player.Position.z);

            if (newPosition.x * newPosition.x + newPosition.z * newPosition.z > _raisedRadiusOfMap)
            {
                Vector3 positionInCorrectArea = player.Position;
                positionInCorrectArea -= offset;
                newPosition = positionInCorrectArea;
            }

            return newPosition;
        }
    }
}