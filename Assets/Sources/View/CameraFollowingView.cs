using UnityEngine;
using View.PlayerComponents;

namespace View
{
    public class CameraFollowingView : MonoBehaviour
    {
        private Player _player;
        private Vector3 _offset;
        private float _speed = 0.125f;

        public void Init(Player player)
        {
            _player = player;
            _offset = transform.position - _player.transform.position;
            _offset.x = 0;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position + _offset, _speed);
        }
    }
}