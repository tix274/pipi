using UnityEngine;


public class SphereController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 5f;
    public Vector3 jumpDirection = new Vector3(1, 1, 0);
    public float scaleSqueeze = 0.5f;
    public float scaleLerpSpeed = 10f;

    private Vector3 originalScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        originalScale = transform.localScale;
    }



    // Update is called once per frame
    void Update()

    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpDirNormalized = jumpDirection.normalized;
            rb.AddForce(jumpDirNormalized * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Vector3 newScale = new Vector3(
               originalScale.x * scaleSqueeze,
               originalScale.y,
               originalScale.z * scaleSqueeze
           );
            transform.localScale = newScale;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            transform.localScale = originalScale;
        }
        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * scaleLerpSpeed);
        }

    }
}









