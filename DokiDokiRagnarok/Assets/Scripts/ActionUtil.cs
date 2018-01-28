using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using DokiDokiRagnarok.Controllers;
using DokiDokiRagnarok.Models;

namespace DokiDokiRagnarok
{
    public static class ActionUtil
    {
        
        public static DialogModel PerformAction(List<ActionDialogModel> actionDialogModels, int option)
        {
            DialogModel nextDialog = Raid(actionDialogModels[option]);

            switch (option)
            {
                case 0:
                    Viking.RaidCount++;
                    break;
                case 1:
                    Viking.MeadCount++;
                    break;
                case 2:
                    Viking.OdinCount++;
                    break;
                case 3:
                    Viking.AttackedEnglandCount++;
                    break;
            }
            return nextDialog;
        }
        
        /// <returns>Next Dialog or null, if no reaction from village.</returns>
        public static DialogModel Raid(ActionDialogModel actionDialogModel)
        {
            int nextDialog = GetDialogIdByCondition(actionDialogModel);
            Viking.Score += actionDialogModel.Score[nextDialog];

            DialogModel dialogModel = null;
            if (nextDialog > -1)
            {
                dialogModel = actionDialogModel.Dialogs[nextDialog];
            }
            return dialogModel;
        }

        private static int GetDialogIdByCondition(ActionDialogModel actionDialogModel)
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

            return -1;
        }

        public static bool CheckCondition(ActionConditions conditions)
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

            if (conditions == ActionConditions.None)
            {
                return true;
            }

            return false;
        }


    }
}