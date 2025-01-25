using UnityEngine;

public class Ball_Controller : MonoBehaviour
{

    private Vector3 position;
    private Quaternion rotation;

    public GameObject thisTarget;
    public GameObject nextBall;
    public GameObject nextTarget;
    public GameObject startButton;
    public GameObject resetButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = this.transform.position;
        rotation = this.transform.rotation;
    }

    public void ResetBall() {
        this.transform.position = position;
        this.transform.rotation = rotation;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void DropBall() {
        this.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void NextLevel(){
        if (nextBall != null) {
            startButton.GetComponent<Button_Press>().NextLevel();
            resetButton.GetComponent<Button_Press>().NextLevel();

            thisTarget.SetActive(false);
            nextBall.SetActive(true);
            nextTarget.SetActive(true);
            gameObject.SetActive(false);
        }
        else {
            print("all done");
            thisTarget.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
