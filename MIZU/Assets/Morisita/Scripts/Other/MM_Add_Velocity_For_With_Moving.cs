using UnityEditor;
using UnityEngine;

public class MM_Add_Velocity_For_With_Moving : MonoBehaviour
{
    // 前とのPositionの差を取ってきた方が正確に動くっぽい？->MovePositionで解決
    [SerializeField]
    private Rigidbody otherRigidbody;
    [SerializeField]
    private bool isOnMoveGround;
    [SerializeField]
    private Vector3 addVelocity;

    string MOVE_GROUND = "MoveGround";

    Vector3 oldPosition;
    Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Init();
    }
    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        if (isOnMoveGround)
        {
            CalcAddVelocity();
            //_rb.AddForce(addVelocity.normalized * ((addVelocity.x - _rb.velocity.x) * power), ForceMode.Acceleration);
            _rb.MovePosition(_rb.position + AddVelocity() * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(MOVE_GROUND))
        {
            print("接続");
            isOnMoveGround = true;
            if (other.gameObject.GetComponent<MM_Get_Parent_Rigidbody>() != null)
            {
                otherRigidbody = other.gameObject.GetComponent<MM_Get_Parent_Rigidbody>().rb;
            }
            else
            {
                otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            }
            oldPosition = otherRigidbody.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(MOVE_GROUND))
        {
            print("解除");

            Init();
        }
    }

    void Init()
    {
        isOnMoveGround = false;
        addVelocity = Vector3.zero;
        otherRigidbody = null;
    }

    private void CalcAddVelocity()
    {
        addVelocity = (otherRigidbody.position - oldPosition) / Time.deltaTime;
        if (addVelocity.y < 0)
            addVelocity = new(addVelocity.x, addVelocity.y, 0f);
        else
            addVelocity = new(addVelocity.x, 0f, 0f);
        oldPosition = otherRigidbody.position;
    }

    public Vector3 AddVelocity()
    {
        return addVelocity;
    }
}
