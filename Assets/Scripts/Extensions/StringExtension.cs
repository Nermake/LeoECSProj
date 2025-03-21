using UnityEngine;

namespace Extensions
{
    public static class StringExtension
    {
        public static string Color(this string s, string color)
        {
            return $"<color=#{color}>{s}</color>";
        }
        
        public static string Color(this string s, Color color)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{s}</color>";
        }
        
        public static string Size(this string s, float size)
        {
            return $"<size={size}>{s}</size>";
        }
        
        public static string Bold(this string s)
        {
            return $"<b>{s}</b>";
        }
        
        public static string Italic(this string s)
        {
            return $"<i>{s}</i>";
        }
        
        /// <summary>
        /// It only works when displayed in Text or TextMeshPro
        /// </summary>
        public static string Strikethrough(this string s)
        {
            return $"<s>{s}</s>";
        }
    }
}