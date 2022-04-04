using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }
    public CharacterController controller;
        
    [SerializeField]private float speed = 1.3f;
    [SerializeField]private float deathTimer = 5;

    private AudioSource playerAudio;
    public AudioSource gunshotAudio;
    public Animator animator;

    // Update is called once per frame
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.Play(0);
    }
    void Update()
    {


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;

        if(move != Vector3.zero)
        {
            playerAudio.volume = 0.6f;
            animator.SetBool("isMove", true);
        }
        else if (move == Vector3.zero)
        {
            playerAudio.volume = 0;
            animator.SetBool("isMove", false);
        }

        controller.Move(move * speed * Time.deltaTime);

        if (dialogueUI.isOpen) return;

        if (Interactable != null)
        {
            Interactable.Interact(this);
        }
    }

    public void Eliminated(float currentTime)
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent("Eliminated" + transform.position);
        gunshotAudio.Play();
        dialogueUI.enabled = false;
        controller.enabled = false;
        StartCoroutine (DeathTime());
    }
    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(deathTimer);
        SceneManager.LoadScene("Maze");
    }
}
