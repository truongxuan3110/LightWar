using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager : MonoBehaviour
{
    public TowerButton towerBtnPressed { get; set; }
    public SpriteRenderer spriteRenderer;
    private Collider2D buildTile;
    public List<GameObject> TowerList = new List<GameObject>();
    public List<Collider2D> BuildList = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        buildTile = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the left mouse button is clicked
        if(Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position
            Vector2 worldPointPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPointPosition, Vector2.zero);
            //If something was hit, the RaycastHit2D.collider will not be null
            if (hit)
            {
                if (hit.collider.tag == "BuildPlace")
                {
                    buildTile = hit.collider;
                    buildTile.tag = "BuildPlaceFull";
                    RegisterBuildPlace(buildTile);
                    placeTower(hit);
                }
            }
            
        }
        //when sprite is enabled move the sprite where our mouse position is
        if (spriteRenderer.enabled)
        {
            followMouse();
        }
    }
    public void RegisterBuildPlace(Collider2D other)
    {
        BuildList.Add(other);
    }
    public void RenameTagsBuildPlace()
    {
        foreach(Collider2D buildTag in BuildList)
        {
            buildTag.tag = "BuildSite";
        }
        BuildList.Clear();
    }
    public void RegisterTower(GameObject tower)
    {
        TowerList.Add(tower);
    }
    public void DestroyAllTower()
    {
        foreach(GameObject tower in TowerList)
        {
             Destroy(tower.gameObject);
        }
        TowerList.Clear();
    }
    public void placeTower(RaycastHit2D hit)
    {
        if(!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null)
        {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            RegisterTower(newTower);
            DisabledragSprite();
        }
    }
    public void SelectedTower(TowerButton towerButton)
    {
        towerBtnPressed = towerButton;
        EnabledragSprite(towerButton.DragSprite);
    }
    private void followMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }
    public void EnabledragSprite(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }
    public void DisabledragSprite()
    {
        spriteRenderer.enabled = false;
        spriteRenderer.sprite = null;
    }
}
