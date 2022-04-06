using System.Collections;
using UnityEngine;

public class GhostHome : GhostBehavior
{
    public Transform inside;
    public Transform outside;

    

    private void OnDisable()
    {
        
        if (gameObject.activeSelf) {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            ghost.movement.SetDirection(-ghost.movement.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
       
        ghost.movement.SetDirection(Vector2.up);
        ghost.movement.rigidbody.isKinematic = true;
        ghost.movement.enabled = false;

        Vector3 position = transform.position;

        float duration = 0.5f;
        float time = 0f;

        
        while (time < duration)
        {
            ghost.SetPosition(Vector3.Lerp(position, inside.position, time / duration));
            time += Time.deltaTime;
            yield return null;
        }

        time = 0f;

       
        while (time < duration)
        {
            ghost.SetPosition(Vector3.Lerp(inside.position, outside.position, time / duration));
            time += Time.deltaTime;
            yield return null;
        }

       
        ghost.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1f : 1f, 0f));
        ghost.movement.rigidbody.isKinematic = false;
        ghost.movement.enabled = true;
    }

}
