using UnityEngine;

public class SquareBehaviours : MonoBehaviour
{
    public Vector3 Vel { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Vel = new Vector3(0.01f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acc = new Vector3(0.001f, 0, 0);

        Vel += acc * Time.deltaTime;
        gameObject.transform.position += Vel;
    }

    void FixedUpdate()
    {

    }
}