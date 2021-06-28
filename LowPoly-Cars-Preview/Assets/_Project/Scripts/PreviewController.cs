using UnityEngine;

public class PreviewController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;


    private void Update()
    {
        transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
    }
}
