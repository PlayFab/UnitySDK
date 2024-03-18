using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.PfEditor
{
    //[InitializeOnLoad]
    public class SubMenuComponent : UnityEditor.Editor
    {

        Dictionary<string, MenuItemContainer> items = new Dictionary<string, MenuItemContainer>();
        
        GUIStyle selectedStyle;
        GUIStyle defaultStyle;
        GUIStyle bgStyle;
        private static int focusIndex = 0;

        //changes local
        public static void InputSubMenuStudiosHandler()
        {
            var e = Event.current;
            if (e.type == EventType.KeyUp)
            {
                if (e.keyCode == KeyCode.RightArrow)
                {
                    switch (focusIndex)
                    {
                        case 0:
                            GUI.FocusControl("project");
                            focusIndex = 1;
                            break;
                        case 1:
                            GUI.FocusControl("studios");
                            focusIndex = 2;
                            break;
                        case 2:
                            GUI.FocusControl("API");
                            focusIndex = 0;
                            break;
                    }
                }
                else if (e.keyCode == KeyCode.LeftArrow)
                {
                    switch (focusIndex)
                    {
                        case 0:
                            GUI.FocusControl("API");
                            focusIndex = 1;
                            break;
                        case 1:
                            GUI.FocusControl("studios");
                            focusIndex = 2;
                            break;
                        case 2:
                            GUI.FocusControl("project");
                            focusIndex = 0;
                            break;
                    }
                }
                else if (e.keyCode == KeyCode.UpArrow)
                {
                    GUI.FocusControl("settings");
                    PlayFabEditorMenu.OnSdKsClicked();
                }
                else if (e.keyCode == KeyCode.DownArrow)
                {
                    GUI.FocusControl("project");
                    PlayFabEditorMenu.OnSettingsClicked();
                }
            }
        }
        public static void InputDataMenuHandler()
        {
            var e = Event.current;
            if (e.type == EventType.KeyUp)
            {
                if (e.keyCode == KeyCode.RightArrow)
                {
                    switch (focusIndex)
                    {
                        case 0:
                            GUI.FocusControl("title");
                            focusIndex = 1;
                            break;
                        case 1:
                            GUI.FocusControl("internal");
                            focusIndex = 0;
                            break;
                    }
                }
                else if (e.keyCode == KeyCode.LeftArrow)
                {
                    switch (focusIndex)
                    {
                        case 0:
                            GUI.FocusControl("title");
                            focusIndex = 1;
                            break;
                        case 1:
                            GUI.FocusControl("internal");
                            focusIndex = 0;
                            break;
                    }
                }
                else if (e.keyCode == KeyCode.UpArrow)
                {
                    GUI.FocusControl("sdk");
                    PlayFabEditorMenu.OnSdKsClicked();
                }
                else if (e.keyCode == KeyCode.DownArrow)
                {
                    GUI.FocusControl("title");
                }
            }
        }

        public void DrawMenu()
        {
            selectedStyle = selectedStyle ?? PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            defaultStyle = defaultStyle ?? PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            bgStyle = bgStyle ?? PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1");
            using (new UnityHorizontal(bgStyle, GUILayout.ExpandWidth(true)))
            {
                foreach (var item in items)
                {
                    var styleToUse = item.Value.isSelected ? selectedStyle : defaultStyle;
                    var content = new GUIContent(item.Value.displayName);
                    var size = styleToUse.CalcSize(content);
                    //Chnages in local
                    switch (item.Value.displayName)
                    {
                        case "PROJECT":
                            GUI.SetNextControlName("project");
                            InputSubMenuStudiosHandler();
                            break;
                        case "STUDIOS":
                            GUI.SetNextControlName("studios");
                            break;
                        case "API":
                            GUI.SetNextControlName("API");
                            break;
                        case "TITLE":
                            InputDataMenuHandler();
                            GUI.SetNextControlName("title");
                            break;
                        case "INTERNAL":
                            GUI.SetNextControlName("internal");
                            break;
                    }
                    if (GUILayout.Button(item.Value.displayName, styleToUse, GUILayout.Width(size.x + 1)))
                    {
                        OnMenuItemClicked(item.Key);
                    }
                }
            }
        }

        public void RegisterMenuItem(string n, System.Action m)
        {
            if (!items.ContainsKey(n))
            {
                var selectState = false;
                var activeSubmenu = PlayFabEditorPrefsSO.Instance.curSubMenuIdx;
                if (items.Count == 0 && activeSubmenu == 0 || activeSubmenu == items.Count)
                    selectState = true;

                items.Add(n, new MenuItemContainer() { displayName = n, method = m, isSelected = selectState });
            }
        }
        private void OnMenuItemClicked(string key)
        {
            if (!items.ContainsKey(key))
                return;

            DeselectAll();
            items[key].isSelected = true;
            if (items[key].method != null)
            {
                items[key].method.Invoke();
            }
        }

        private void DeselectAll()
        {
            foreach (var item in items)
            {
                item.Value.isSelected = false;
            }
        }

        public SubMenuComponent()
        {
            if (!PlayFabEditor.IsEventHandlerRegistered(StateUpdateHandler))
            {
                PlayFabEditor.EdExStateUpdate += StateUpdateHandler;
            }
        }

        void StateUpdateHandler(PlayFabEditor.EdExStates state, string status, string json)
        {
            switch (state)
            {
                case PlayFabEditor.EdExStates.OnMenuItemClicked:
                    DeselectAll();
                    if (items != null)
                        foreach (var each in items)
                        {
                            each.Value.isSelected = true; // Select the first
                            break;
                        }
                    break;
            }
        }
    }

    public class MenuItemContainer
    {
        public string displayName;
        public System.Action method;
        public bool isSelected;
    }
}
