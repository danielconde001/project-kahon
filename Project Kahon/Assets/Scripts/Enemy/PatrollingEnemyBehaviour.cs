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
                if (!inReverse) Debug.Log("Left");
                else Debug.Log("Right");
                break;
            case PatrolCommand.MoveRight:
                if (!inReverse) Debug.Log("Right");
                else Debug.Log("Left");
                break;
            case PatrolCommand.MoveUp:
                if (!inReverse) Debug.Log("Up");
                else Debug.Log("Down");
                break;
            case PatrolCommand.MoveDown:
                if (!inReverse) Debug.Log("Down");
                else Debug.Log("Up");
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
        yield break;
    }
}
