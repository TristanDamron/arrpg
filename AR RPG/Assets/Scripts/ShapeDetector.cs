using System.Collections;
using System.Collections.Generic;

public class ShapeDetector {
    private Shape[] _shapes;

    public enum ShapeType {
        SLASH = 0,
        AERIAL_ATTACK = 1,
        DODGE = 2,
        FIRE_STRIKE = 3,
        NONE = 4
    };    

    public void LoadShapes(Shape[] s) {
        _shapes = s;
    }    

    public ShapeType FindMatch(Shape s) {
        var _avg = s.AveragePoints();

        if (_avg < 180) {
            return ShapeType.AERIAL_ATTACK;
        } else if (_avg >= 180 && _avg < 300) {
            //return ShapeType.FIRE_STRIKE;
            return ShapeType.SLASH;
        } else if (_avg >= 300 && _avg < 350) {
            return ShapeType.SLASH;
        } else {
            return ShapeType.DODGE;
        }
    }
}