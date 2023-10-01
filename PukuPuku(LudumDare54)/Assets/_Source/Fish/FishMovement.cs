using UnityEngine;

namespace Fish
{
    public class FishMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] movePoints;
        [SerializeField] private float speed;

        private Transform _nextPoint;
        private int _index;
        private float time = 0;

        void Start()
        {
            _index = 0;
            _nextPoint = movePoints[_index];
        }


        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _nextPoint.position, time * speed);
            time += Time.deltaTime;
            transform.LookAt(_nextPoint);

            if(transform.position == _nextPoint.position)
            {
                _index++;
                if (_index >= movePoints.Length)
                    _index = 0;

                _nextPoint = movePoints[_index];
                time = 0;
            }

        }
    }
}