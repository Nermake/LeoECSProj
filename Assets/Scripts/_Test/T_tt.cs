using Extensions;
using UnityEngine;

namespace _Test
{
    public class T_tt : MonoBehaviour
    {
        private readonly string _test = "Test";
        
        private void Start()
        {
            Debug.Log(_test.Color("00ff00ff").Italic().Bold());
            Debug.Log(_test.Color(Color.red).Bold());
            Debug.Log(_test.Color(Color.yellow).Strikethrough());
        }
    }
}