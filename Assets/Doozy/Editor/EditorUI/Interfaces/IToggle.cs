﻿// Copyright (c) 2015 - 2021 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

namespace Doozy.Editor.EditorUI
{
    public interface IToggle
    {
        bool isOn { get; set; }
        IToggleGroup toggleGroup { get; set; }
        void AddToToggleGroup(IToggleGroup value);
        void RemoveFromToggleGroup();
        void UpdateValueFromGroup(bool newValue, bool animateChange, bool silent = false);
    }
}
