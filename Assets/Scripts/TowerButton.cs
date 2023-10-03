using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private GameObject towerObject;
    [SerializeField]
    private Sprite dragSprite;
    [SerializeField]
    private int towerPrice;

    public int TowerPrice { get { return towerPrice; } set { towerPrice = value; } }
    public GameObject TowerObject { get { return towerObject; } }
    public Sprite DragSprite { get {  return dragSprite; } }
}
