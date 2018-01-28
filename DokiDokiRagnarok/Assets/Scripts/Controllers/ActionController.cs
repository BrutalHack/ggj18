using DokiDokiRagnarok.Models;
using UnityEngine;

namespace DokiDokiRagnarok.Controllers
{
    public class ActionController : MonoBehaviour
    {
        public ActionDialogModel RaidActionDialogModel; 
        public ActionDialogModel MeadActionDialogModel; 
        public ActionDialogModel OdinActionDialogModel; 
        public ActionDialogModel AttackEnglandActionDialogModel; 
        
        /// <returns>Next Dialog or null, if no reaction from village.</returns>
        public DialogModel Raid()
        {
            int nextDialog = GetDialogIdByCondition(RaidActionDialogModel);
            Viking.Score += RaidActionDialogModel.Score[nextDialog];

            DialogModel dialogModel = null;
            if (nextDialog > -1)
            {
                dialogModel = RaidActionDialogModel.Dialogs[nextDialog];
                //RaidController dialog = 
            }
            Viking.RaidCount++;
            return dialogModel;
        }

        private int GetDialogIdByCondition(ActionDialogModel actionDialogModel)
        {
            for (int i = 0; i < actionDialogModel.Conditions.Count; i++)
            {
                if (CheckCondition(actionDialogModel.Conditions[i]))
                {
                    {
                        return i;
                    }
                }
            }

            Debug.LogError("No DialogId");
            return -1;
        }

        public void PraiseOdin()
        {
            Viking.OdinCount++;
        }

        public void AttackEngland()
        {
            if (Village.Emotion == Emotion.Angry)
            {
                Village.AttackedEnglandWhileAngry = true;
            } else if (Village.Emotion == Emotion.SweatDrop)
            {
                Village.AttackedEnglandWhileSweatDrop = true;
            }

            Viking.AttackedEnglandCount++;
        }

        public void DrinkMead()
        {
            Viking.MeadCount++;
        }
        
        public bool CheckCondition(ActionConditions conditions)
        {
            if (conditions == ActionConditions.IsHappy &&
                Village.Emotion == Emotion.Happy)
            {
                return true;
            }

            if (conditions == ActionConditions.MeadEqualsZero &&
                Viking.MeadCount == 0)
            {
                return true;
            }

            if (conditions == ActionConditions.MeadGreaterZero &&
                Viking.MeadCount > 0)
            {
                return true;
            }

            if (conditions == ActionConditions.MeadGreaterTwo &&
                Viking.MeadCount > 2)
            {
                return true;
            }

            if (conditions == ActionConditions.IsSweatDrop &&
                Village.Emotion == Emotion.SweatDrop)
            {
                return true;
            }

            if (conditions == ActionConditions.IsAngry &&
                Village.Emotion == Emotion.Angry)
            {
                return true;
            }

            if (conditions == ActionConditions.OdinEqualsZero &&
                Viking.OdinCount == 0)
            {
                return true;
            }

            if (conditions == ActionConditions.OdinEqualsOne &&
                Viking.OdinCount == 1)
            {
                return true;
            }

            if (conditions == ActionConditions.OdinGreaterZero &&
                Viking.OdinCount > 0)
            {
                return true;
            }

            if (conditions == ActionConditions.OdinGreaterOne &&
                Viking.OdinCount > 1)
            {
                return true;
            }

            if (conditions == ActionConditions.IsNotAngry &&
                Village.Emotion != Emotion.Angry)
            {
                return true;
            }

            if (conditions == ActionConditions.AttackedEnglandWhileAngry &&
                Village.AttackedEnglandWhileAngry)
            {
                return true;
            }

            if (conditions == ActionConditions.AttackedEnglandWhileSweatDrop &&
                Village.AttackedEnglandWhileSweatDrop)
            {
                return true;
            }

            if (conditions == ActionConditions.IsShy &&
                Village.Emotion == Emotion.Shy)
            {
                return true;
            }

            if (conditions == ActionConditions.IsNotSweatDrop &&
                Village.Emotion != Emotion.SweatDrop)
            {
                return true;
            }

            if (conditions == ActionConditions.AttackedEnglandEqualsZero &&
                Viking.AttackedEnglandCount == 0)
            {
                return true;
            }
            
            if (conditions == ActionConditions.AttackedEnglandEqualsOne &&
                Viking.AttackedEnglandCount == 1)
            {
                return true;
            }

            if (conditions == ActionConditions.AttackedEnglandGreaterOne &&
                Viking.AttackedEnglandCount > 1)
            {
                return true;
            }

            if (conditions == ActionConditions.IsHappyAndDrunk &&
                (Village.Emotion == Emotion.Happy && Viking.MeadCount > 0))
            {
                return true;
            }
            
            if (conditions == ActionConditions.IsShyAndDrunk &&
                (Village.Emotion == Emotion.Shy && Viking.MeadCount > 0))
            {
                return true;
            }
            
            return false;
        }
    }
}