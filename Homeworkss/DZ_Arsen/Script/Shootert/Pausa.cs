using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField] private KeyCode _pausa;

    public void PausaGames(Collision2D collision2D)
    {
        if(Input.GetKey(_pausa))
        {
            if (collision2D.gameObject.TryGetComponent(out Menu menu))
            {
                menu.Pause();
            }
        }
    }
}
