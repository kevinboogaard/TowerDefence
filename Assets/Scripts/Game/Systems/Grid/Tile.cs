using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class Tile : MonoBehaviour
{
    /* This is the class every tile has. It switches between visible or invisible when the mouse hovers over the tile. */
    public int type = 0; // Types: 0 - Unspawn-able. 1 - Spawn-able.

    private GameManager _manager;

    void Start()
    {
        Switch(false);
        ChangeTransparency(0.50f);
        _manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    void OnMouseOver()
    {
        /* If the mouse hovers over the tile .. */
        if (_manager.eventGame == GameManager.gameEvents.EVENT_OUT_OF_COMBAT)
        {
            ChangeTransparency(1f);
        }
    }

    void OnMouseExit()
    {
        /* If the mouse exits the tile .. */
        if (_manager.eventGame == GameManager.gameEvents.EVENT_OUT_OF_COMBAT)
        {
            ChangeTransparency(0.50f);
        }
    }

    public void ChangeTransparency(float value)
    {
        Color color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, value);
        renderer.material.color = color;
    }

    public void Switch(bool value)
    {
        /* Enable or Disable the renderer. */
        renderer.enabled = value;
    }
}
