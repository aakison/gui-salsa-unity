using UnityEngine;

public static class ColorExtensions {

    public static Color Transparent(this Color color) {
        return new Color(color.r, color.g, color.b, 0);
    }

    public static Color Alpha(this Color color, float alpha) {
        return new Color(color.r, color.g, color.b, alpha);
    }

    public static Color Opaque(this Color color) {
        return new Color(color.r, color.g, color.b, 1);
    }

}
