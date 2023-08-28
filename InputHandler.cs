using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject actor;
    Animator anim;
    Command keyW, keyA, keyS, keyD, keySpace;

    List<Command> commands = new List<Command>();
    public Coroutine interaction;
    bool shouldPlay;
    bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        keySpace = new Jump();
        keyW = new MoveFoward();
        keyA = new DoNothing();
        keyS = new DoNothing();
        keyD = new DoNothing();
        anim = actor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
            HandleInput();
        Play();

    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //keySpace.Execute(anim);
            commands.Add(keySpace);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //keyW.Execute(anim);
            commands.Add(keyW);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //keyA.Execute(anim);
            commands.Add(keyA);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //keyS.Execute(anim);
            commands.Add(keyS);
        }
        else if (Input.GetKeyDown(KeyCode.D)) { 
            //keyD.Execute(anim);
            commands.Add(keyD);
        }
    }
    void Play()
    {
        if(shouldPlay && commands.Count > 0)
        {
            shouldPlay = false;
            if (interaction != null)
            {
                StopCoroutine(interaction);
            }
            interaction = StartCoroutine(PlayCommands());
        }
    }
    IEnumerator PlayCommands()
    {
        isPlaying = true;
        for (int i = 0; i < commands.Count; i++)
        {
            commands[i].Execute(anim);
            yield return WaitForSeconds(1f);
        }
    }
}
