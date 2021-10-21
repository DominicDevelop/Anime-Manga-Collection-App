﻿// Copyright (c) 2015 - 2021 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using Doozy.Runtime.Common;
// ReSharper disable MemberCanBePrivate.Global

namespace Doozy.Editor.UIManager
{
	internal class EditorUIManagerPath : BasePathFinder<EditorUIManagerPath>
	{
		internal static string automationFolderPath => $"{path}/Automation";
		internal static string automationTemplatesFolderPath => $"{automationFolderPath}/Templates";
	}
}