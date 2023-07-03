using UnityEngine;
public class BackgroundScript : MonoBehaviour
{
    private float _length, _startpos;
    public GameObject Cam;
    public float ParallexEffect;

    void Start()
    {
        _startpos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (Cam.transform.position.x * (1 - ParallexEffect));
        float dist = (Cam.transform.position.x * ParallexEffect);
        transform.position = new Vector3(_startpos + dist, Cam.transform.position.y, transform.position.z);
        if (temp > _startpos + _length) { _startpos += _length; }
        else if (temp < _startpos - _length) { _startpos -= _length; }
    }
}