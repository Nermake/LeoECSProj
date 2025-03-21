using UnityEngine;

namespace Services
{
    public class Destroyer : MonoBehaviour
    {
        public void DestroyUnit(GameObject unit) => Destroy(unit);
    }
}