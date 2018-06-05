using System.Collections;
using System.Collections.Generic;

public class Shape {
    public List<float> vectorPoints;
    private float _average;
    
    public Shape () {
        vectorPoints = new List<float>();
    }

    public float AveragePoints() {
        if (_average != 0f) 
            return _average;

        foreach (float p in vectorPoints) {
            _average += p;
        }

        _average = _average / vectorPoints.Count;
        return _average;
    }

}