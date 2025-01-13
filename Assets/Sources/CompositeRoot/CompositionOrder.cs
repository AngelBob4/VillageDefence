using Infrastructure;
using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _order;

        private void Awake()
        {
            foreach (var compositionRoot in _order)
            {
                compositionRoot.Compose();
                compositionRoot.enabled = true;
            }
        }
    }
}