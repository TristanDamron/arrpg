using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Mapbox.Unity.Map;
using Mapbox.Unity.Location;

public class RecenterCamera : MonoBehaviour {
    [SerializeField]
    private AbstractMap _map;
    private Mapbox.Utils.Vector2d _latLong;

    void Awake () {
        InvokeRepeating("GetLatLong", 1f, 1f);
    }
    
	ILocationProvider _locationProvider;
	ILocationProvider LocationProvider
	{
		get
		{
			if (_locationProvider == null)
			{
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
			}
			return _locationProvider;
		}
    }
    
    public void GetLatLong() {
        _latLong = LocationProvider.CurrentLocation.LatitudeLongitude;
    }

    public void Recenter() {
        var position = _map.GeoToWorldPosition(_latLong);                
        position.y = Camera.main.transform.position.y;
        position.z = position.z - 50;
        Camera.main.transform.position = position;
    }
}