using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Rigidbody motorSphereRB;

    [Header("Speeds")]
    [SerializeField] private float fwdSpeed;
    [SerializeField] private float revSpeed;
    [SerializeField] private float turnSpeed;

    float _vInput;
    float _hInput;

    private void Start()
    {
        motorSphereRB.transform.parent = null;
    }

    private void Update()
    {
        _vInput = Input.GetAxisRaw("Vertical");
        _hInput = Input.GetAxisRaw("Horizontal");

        _vInput *= _vInput > 0 ? fwdSpeed : revSpeed;

        float yRot = _hInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0f, yRot, 0f, Space.World);

        transform.position = motorSphereRB.position;
    }

    private void FixedUpdate()
    {
        motorSphereRB.AddForce(transform.forward * _vInput, ForceMode.Acceleration);
    }
}
