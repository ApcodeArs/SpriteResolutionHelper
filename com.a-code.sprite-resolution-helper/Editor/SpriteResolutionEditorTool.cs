using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SpriteResolutionHelper
{
    public static class SpriteResolutionEditorTool
    {
        private const string IsUsedMenuPath = "Tools/SpriteResolutionHelper/IsUsed";
        private const string IsUsedMenuItemName = "IsUsed";

        public static bool IsUsed
        {
            get => EditorPrefs.GetBool(IsUsedMenuItemName, true);
            set => EditorPrefs.SetBool(IsUsedMenuItemName, value);
        }

        [MenuItem(IsUsedMenuPath)]
        private static void IsUsedSpriteResolutionHelper()
        {
            IsUsed = !IsUsed;
        }

        [MenuItem(IsUsedMenuPath, true)]
        private static bool IsUsedSpriteResolutionHelperValidate()
        {
            Menu.SetChecked(IsUsedMenuPath, IsUsed);
            return true;
        }
    }
}
