using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private float horizontal;
    private float vertical;
    private string currentAnim;
    private bool isGround;
    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 40f;
    [SerializeField] private float attackCooldown = 0.7f;
    [SerializeField] private float countLife = 5;
    [SerializeField] private TMP_Text life;
    public Slider hp;
    public float maxHP = 10;
    private float lastAttackTime;

    public GameObject GameOverPanel;
    public GameObject GameWinPanel;
    public GameObject Noti;

    public CinemachineCamera Cam1;
    public CinemachineCamera Cam3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
        hp.maxValue = maxHP;
        hp.value = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Atttack();
        Movement();
        // RotateCharacter();
        Jump();
        Debug.Log(isGround);
        life.text = countLife.ToString();
    }

    private void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            changeAnim("Running");
            Vector3 move = new Vector3(horizontal, 0, vertical).normalized;
            move.y = 0;
            rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else if (isGround)
        {
            rb.linearVelocity = Vector3.zero;
            changeAnim("Idle");
        }
    }

    private void changeAnim(string AnimName)
    {
        if (currentAnim != AnimName)
        {
            anim.ResetTrigger(AnimName);
            currentAnim = AnimName;
            anim.SetTrigger(currentAnim);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {

            changeAnim("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Atttack()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= lastAttackTime + attackCooldown)
        {
            changeAnim("Attack");
            lastAttackTime = Time.time;
            changeAnim("Idle");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (other.gameObject.CompareTag("Portal"))
        {
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("Đã đến level cuối cùng!");
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            hp.value--;
            if (hp.value <= 0)
            {
                GameOver();
            }
        }

        if (other.gameObject.CompareTag("Notification"))
        {
            Noti.SetActive(true);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            GameWinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void GameOver()
    {
        //GameOverPanel.SetActive(true);
        SwitchCamera();
        //Time.timeScale = 0;
    }
    private void SwitchCamera()
    {
        Cam3.Priority = 5;
    }
}
