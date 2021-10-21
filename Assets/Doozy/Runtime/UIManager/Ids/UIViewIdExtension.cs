//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using System.Collections.Generic;
// ReSharper disable All
namespace Doozy.Runtime.UIManager.Containers
{
    public partial class UIView
    {
        public static IEnumerable<UIView> GetViews(UIViewId.HUD id) => GetViews(nameof(UIViewId.HUD), id.ToString());
        public static void Show(UIViewId.HUD id, bool instant = false) => Show(nameof(UIViewId.HUD), id.ToString(), instant);
        public static void Hide(UIViewId.HUD id, bool instant = false) => Hide(nameof(UIViewId.HUD), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.Menu id) => GetViews(nameof(UIViewId.Menu), id.ToString());
        public static void Show(UIViewId.Menu id, bool instant = false) => Show(nameof(UIViewId.Menu), id.ToString(), instant);
        public static void Hide(UIViewId.Menu id, bool instant = false) => Hide(nameof(UIViewId.Menu), id.ToString(), instant);
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIViewId
    {
        public enum HUD
        {
            Bottom,
            Left,
            Portrait,
            Right,
            Score,
            Stars,
            Top
        }

        public enum Menu
        {
            Login,
            Mail,
            Main,
            Quit,
            Register,
            Settings
        }    
    }
}