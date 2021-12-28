// Copyright (c) 2015 - 2021 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

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
        public static IEnumerable<UIView> GetViews(UIViewId.Content id) => GetViews(nameof(UIViewId.Content), id.ToString());
        public static void Show(UIViewId.Content id, bool instant = false) => Show(nameof(UIViewId.Content), id.ToString(), instant);
        public static void Hide(UIViewId.Content id, bool instant = false) => Hide(nameof(UIViewId.Content), id.ToString(), instant);

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
        public enum Content
        {
            InfoPanel,
            SearchResult
        }

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