using UnityEngine;

namespace Extensions
{
    public static class ColorExtension
    {
        public static Color SetRGBA(this Color color, float r, float g, float b, float a)
        {
            color.r = r / 255;
            color.g = g / 255;
            color.b = b / 255;
            color.a = a / 255;
            
            return color;
        }
        
        public static Color SetRGB(this Color color, float r, float g, float b)
        {
            color.r = r / 255;
            color.g = g / 255;
            color.b = b / 255;
            
            return color;
        }
    }
}