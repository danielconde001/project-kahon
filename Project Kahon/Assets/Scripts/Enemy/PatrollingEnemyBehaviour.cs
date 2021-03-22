using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum PatrolCommand
{
    MoveLeft, MoveRight, MoveUp, MoveDown, Count
}

public class PatrollingEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] List<PatrolCommand> patrolCommands;
    PatrolCommand currentCommand;
    int index = 0;
    bool inReverse = false;

    protected override void Act()
    {
        currentCommand = patrolCommands[index];

        switch (currentCommand)
        {
            case PatrolCommand.MoveLeft:
                if (!inReverse) Move(-Vector3.right);
                else Move(Vector3.right);
                break;
            case PatrolCommand.MoveRight:
                if (!inReverse) Move(Vector3.right);
                else Move(-Vector3.right);
                break;
            case PatrolCommand.MoveUp:
                if (!inReverse) Move(Vector3.forward);
                else Move(-Vector3.forward);
                break;
            case PatrolCommand.MoveDown:
                if (!inReverse) Move(-Vector3.forward);
                else Move(Vector3.forward);
                break;
        }

        if (index < patrolCommands.Count) 
        {
            if (inReverse) index--;
            else index++;
        }
        
        if (index >= patrolCommands.Count)
        {   
            index = patrolCommands.Count - 1;
            inReverse = true;
        }

        if (index < 0 && inReverse) 
        {
            index = 0;
            inReverse = false; 
        }
    }

    private void Move(Vector3 direction)
    {
        StartCoroutine(MoveCoroutine(direction));
    }

    private IEnumerator MoveCoroutine(Vector3 direction)
    {
        // replace 20 with a modifiable value. Make it not hard coded in the future.
        for (int i = 0; i < 20; i++)
        {
            transform.rotation = Quaternion.LookRotation(direction/20, Vector3.up);
            transform.position += direction/20;
            yield return new WaitForEndOfFrame();
        }
    }
}
