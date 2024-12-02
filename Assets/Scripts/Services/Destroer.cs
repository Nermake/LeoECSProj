using Services.Locator;
using UnityEngine;

namespace Services
{
    public class Destroyer : MonoBehaviour, IService
    {
        public void DestroyUnit(GameObject unit) => Destroy(unit);
    }
}