using UnityEngine;

public class PreviewManager : MonoBehaviour
{
    [SerializeField] private GameObject carsPrefab;
    [SerializeField] private float rotateSpeed;


    int _currentShowingIndex;
    GameObject[] _cars;

    private void Start()
    {
        InitCars();
    }

    private void Update()
    {
        transform.Rotate(-transform.up * rotateSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            ShowNext();
    }

    private void InitCars()
    {
        var carsObj = Instantiate(carsPrefab);
        _cars = new GameObject[carsObj.transform.childCount];

        for (int i = 0; i < _cars.Length; i++)
        {
            _cars[i] = carsObj.transform.GetChild(i).gameObject;

            _cars[i].transform.position = Vector3.zero;
            _cars[i].transform.rotation = Quaternion.identity;

            _cars[i].SetActive(false);
        }

        _cars[0].SetActive(true);
    }

    private void ShowNext()
    {
        _currentShowingIndex++;

        if (_currentShowingIndex >= _cars.Length)
            _currentShowingIndex = 0;

        foreach (var car in _cars)
            car.SetActive(false);

        _cars[_currentShowingIndex].SetActive(true);
    }
}
