
using UnityEngine;
using UnityEngine.InputSystem;


using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour, OnInputReload.IInputReloadActions, OnInputNext.IInputNextActions, OnInputBack.IInputBackActions
{
    public float anguloGiro = 36f;
    private OnInputNext.InputNextActions _inputControls;
    private OnInputReload.InputReloadActions _inputReload;
    private OnInputBack.InputBackActions _inputBack;
    [SerializeField] private ApiController _apiController;
    private float anguloActual;

    void Start()
    {

        anguloActual = transform.eulerAngles.y;

        _inputBack = new OnInputBack().InputBack;
        _inputBack.Enable();
        _inputBack.AddCallbacks(this);
        
        _inputControls = new OnInputNext().InputNext;
        _inputControls.Enable();
        _inputControls.AddCallbacks(this);

        _inputReload = new OnInputReload().inputReload;
        _inputReload.Enable();
        _inputReload.AddCallbacks(this);

        _apiController = GetComponent<ApiController>();
        
        
            _apiController = FindObjectOfType<ApiController>();

            if (_apiController == null)
            {
                Debug.LogError("No se encontró APIController.");
            }
        
    }

    void OnDisable()
    {
        _inputControls.Disable();
        _inputReload.Disable();
        _inputBack.Disable();
    }

    

    
        
        public void OnOnInputReload(InputAction.CallbackContext context)
        {
            if (_apiController != null && context.performed)
            {
                _apiController.ChangePage();
            }
        }
    

    public void OnOnInputNext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.Rotate(Vector3.up, anguloGiro);
        }
    }

    public void OnOnInputBack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.Rotate(Vector3.up, -anguloGiro);
        }
    }
}
