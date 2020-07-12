using Assets.Scripts.Controller;
using Assets.Scripts.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Controller
{

    public class SuggestionMenuController : MonoBehaviour
    {
        public bool IsActive { get; set; }
        [SerializeField]
        PlayerController PlayerController;

        public void Enable()
        {
            IsActive = true;
        }

        public void OnClickAttack()
        {
            if (!IsActive)
                return;
            IsActive = false;
            PlayerController.PickSuggestion(Suggestion.Attack);
        }

        public void OnClickDefend()
        {
            if (!IsActive)
                return;
            IsActive = false;
            PlayerController.PickSuggestion(Suggestion.Defend);
        }

        public void OnClickSupport()
        {
            if (!IsActive)
                return;
            IsActive = false;
            PlayerController.PickSuggestion(Suggestion.Support);
        }

        public void OnClickWhatevs()
        {
            if (!IsActive)
                return;
            IsActive = false;
            PlayerController.PickSuggestion(Suggestion.Whatever);
        }

        public void Show()
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 1f;
        }

        public void Hide()
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 0f;
        }
    }
}

