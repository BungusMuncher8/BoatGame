using UnityEngine;

public class PlayerHarpoonAnim : MonoBehaviour
{
    [SerializeField] private GameObject harpoon;
   private void ShowHarpoon()
   {
        harpoon.SetActive(true);
   }
}
