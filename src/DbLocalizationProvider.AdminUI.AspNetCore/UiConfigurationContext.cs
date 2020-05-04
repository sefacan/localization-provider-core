// Copyright (c) Valdis Iljuconoks. All rights reserved.
// Licensed under Apache-2.0. See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;

namespace DbLocalizationProvider.AdminUI.AspNetCore
{
    /// <summary>
    /// Class responsible for providing way to customize AdminUI
    /// </summary>
    public class UiConfigurationContext
    {
        /// <summary>
        /// Set roles to users who will have admin access to UI with more privileges (create new, delete, import, etc).
        /// </summary>
        public ICollection<string> AuthorizedAdminRoles { get; } = new List<string> { "Administrators" };

        /// <summary>
        /// Set roles to users who will have editor access to UI (can add translations).
        /// </summary>
        public ICollection<string> AuthorizedEditorRoles { get; } = new List<string>
                                                                    {
                                                                        "Administrators",
                                                                        "Editors"
                                                                    };

        /// <summary>
        /// Sometimes resource keys might get pretty long. You can chop them here.
        /// </summary>
        public int MaxResourceKeyDisplayLength { get; set; } = 80;

        /// <summary>
        /// Sometimes resource keys might get pretty long even in edit popup window. You can chop them here.
        /// </summary>
        public int MaxResourceKeyPopupTitleLength { get; set; } = 80;

        /// <summary>
        /// Someone asked me once - "I like tree view, can it be my default preference".
        /// </summary>
        public ResourceListView DefaultView { get; set; } = ResourceListView.Table;

        /// <summary>
        /// If you wanna get rid of some view (table OR tree) this is the method. You cannot disable all views - will receive exception.
        /// </summary>
        /// <param name="view"></param>
        //public void DisableView(ResourceListView view)
        //{
        //    if(view == ResourceListView.None)
        //        throw new ArgumentException("Cannot disable `None` view");

        //    if(view == ResourceListView.Table)
        //    {
        //        if(IsTreeViewDisabled)
        //            throw new ArgumentException("Cannot disable both views");

        //        IsTableViewDisabled = true;
        //    }


        //    if(view == ResourceListView.Tree)
        //    {
        //        if(IsTableViewDisabled)
        //            throw new ArgumentException("Cannot disable both views");

        //        IsTreeViewDisabled = true;
        //    }

        //}

        /// <summary>
        /// Tree view will be expanded by default.
        /// </summary>
        //public bool TreeViewExpandedByDefault { get; set; } = true;

        /// <summary>
        /// This is sometimes pretty useful when want to see what exactly resource translation was synced from the code.
        /// </summary>
        public bool ShowInvariantCulture { get; set; } = false;

        /// <summary>
        /// Sometimes it's worth to look for some hidden treasure. This option will also show resources decorated with <see cref="DbLocalizationProvider.Abstractions.HiddenAttribute"/>.
        /// </summary>
        public bool ShowHiddenResources { get; set; } = false;

        /// <summary>
        /// Access to current configuration context instance. Statics sucks.
        /// </summary>
        public static UiConfigurationContext Current { get; } = new UiConfigurationContext();

        /// <summary>
        /// This might become handy sometimes when white background and black fonts are too boooooring.
        /// </summary>
        public string CustomCssPath { get; set; }

        /// <summary>
        /// If you find conflicts in your project and somebody already took this address, please set you unique custom address here.
        /// </summary>
        /// <remarks>This is Url how editors or even maybe admins will be able to access admin panel and mess around with translations. Needs to start with `/` otherwise runtime will blow up.</remarks>
        public string RootUrl { get; set; } = "/localization-admin";

        /// <summary>
        /// If you don't need to remove resource ever - set this to <code>true</code>
        /// </summary>
        public bool HideDeleteButton { get; set; } = false;

        //internal bool IsTreeViewDisabled { get; set; }

        //internal bool IsTableViewDisabled { get; set; }

        /// <summary>
        /// Wanna customize anything here? Call this method.
        /// </summary>
        /// <param name="configCallback">You will receive context instance through which some customization is theoretically possible.</param>
        public static void Setup(Action<UiConfigurationContext> configCallback)
        {
            configCallback?.Invoke(Current);
        }
    }
}
