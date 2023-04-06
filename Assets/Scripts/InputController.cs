using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] TreeGenerator tree;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip[] jumpSounds;

    private float lastMoveTime = 0.0f;

    void Update()
    {
        MovePlayer();
    }

#if UNITY_ANDROID
    private void MovePlayer()
    {
        if (!player.IsGameplayOn())
            return;

        if (!player.isAlive())
        {
            lastMoveTime = 0.0f;
        }
        else
        {
            if (Input.touchCount <= 0)
                return;

            Touch touch = Input.GetTouch(0);

            if (Input.GetTouch(0).phase != TouchPhase.Began)
                return;

            if (Time.time - lastMoveTime < tree.branchMoveDuration)
                return;

            if (player.isHawkActive)
                return;

            if (touch.position.x < Screen.width / 2)
            {
                player.SetPosition(PlayerController.Position.Left);
            }
            else
            {
                player.SetPosition(PlayerController.Position.Right);
            }

            tree.CyclePositions();
            player.ClimbNextBranch();

            lastMoveTime = Time.time;
            animator.SetTrigger("Jump");
            SoundManager.Instance.PlaySound(jumpSounds[Random.Range(0, jumpSounds.Length)]);
        }
    }
#else
    private void MovePlayer()
    {
        if (!player.IsGameplayOn())
            return;

        if (!player.isAlive())
        {
            lastMoveTime = 0.0f;
        }
        else
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            if (Time.time - lastMoveTime < tree.branchMoveDuration)
                return;

            if (player.isHawkActive)
                return;

            if (Input.mousePosition.x < Screen.width / 2)
            {
                player.SetPosition(PlayerController.Position.Left);
            }
            else
            {
                player.SetPosition(PlayerController.Position.Right);
            }
        
            tree.CyclePositions();
            player.ClimbNextBranch();

            lastMoveTime = Time.time;
            animator.SetTrigger("Jump");
            SoundManager.Instance.PlaySound(jumpSounds[Random.Range(0, jumpSounds.Length)]);
        }
    }
#endif
}
