using UnityEngine;

namespace Sources.Variant1
{
    public class InteractiveHologram : MonoBehaviour, IClickable
    {
        [SerializeField] private Light _light;
    
        public void Click()
        {
            var randomColor = (Vector4) Random.insideUnitSphere;
            _light.color = randomColor;
        }
    }
}
