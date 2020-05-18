using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public static class PlayFabGuiFieldHelper
    {
        private static int IndexOf(string[] elements, string element)
        {
            if (elements == null)
                return -1;
            for (var i = 0; i < elements.Length; i++)
                if (elements[i].Equals(element))
                    return i;
            return -1;
        }

        /// <summary>
        /// Build a dropdown menu from a list of arbitrary elements.
        /// </summary>
        public static void SuperFancyDropdown<T>(float labelWidth, string label, T activeElement, IList<T> elements, Func<T, string> getElementKey, Action<T> OnChangeTo, GUIStyle style, params GUILayoutOption[] options)
        {
            if (elements == null || elements.Count == 0)
                return; // Nothing to show

            string[] namesList = new string[elements.Count];
            for (var i = 0; i < elements.Count; i++)
                namesList[i] = getElementKey(elements[i]);

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
            {
                EditorGUILayout.LabelField(label, PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.Width(labelWidth));
                var prevIndex = IndexOf(namesList, getElementKey(activeElement));
                var newIndex = EditorGUILayout.Popup(prevIndex, namesList, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.MinHeight(25));
                if (newIndex != prevIndex)
                    OnChangeTo(elements[newIndex]);
            }
        }
    }

    /// <summary>
    /// A disposable wrapper for enabled/disabled which sets it to one way or another and restores when finished
    /// </summary>
    public class UnityGuiToggler : IDisposable
    {
        private bool previous;

        public UnityGuiToggler(bool isEnabled = false)
        {
            previous = GUI.enabled;
            GUI.enabled = isEnabled;
        }

        public void Dispose()
        {
            GUI.enabled = previous;
        }
    }

    /// <summary>
    /// A disposable wrapper for Verticals, to ensure they're paired properly, and to make the code visually block together within them
    /// </summary>
    public class UnityHorizontal : IDisposable
    {
        public UnityHorizontal(params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal(options);
        }

        public UnityHorizontal(GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal(style, options);
        }

        public void Dispose()
        {
            EditorGUILayout.EndHorizontal();
        }
    }

    /// <summary>
    /// A disposable wrapper for Horizontals, to ensure they're paired properly, and to make the code visually block together within them
    /// </summary>
    public class UnityVertical : IDisposable
    {
        public UnityVertical(params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginVertical(options);
        }

        public UnityVertical(GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginVertical(style, options);
        }

        public void Dispose()
        {
            EditorGUILayout.EndVertical();
        }
    }

    //FixedWidthLabel class. Extends IDisposable, so that it can be used with the "using" keyword.
    public class FixedWidthLabel : IDisposable
    {
        private readonly ZeroIndent indentReset; //helper class to reset and restore indentation
        public float fieldWidth = 0;

        public FixedWidthLabel(GUIContent label, GUIStyle style) // constructor.
        {
            //state changes are applied here.

            this.fieldWidth = style.CalcSize(label).x + 9 * EditorGUI.indentLevel;
            EditorGUILayout.BeginHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")); // create a new horizontal group
            EditorGUILayout.LabelField(label, style, GUILayout.Width(fieldWidth));
            // indentation from the left side. It's 9 pixels per indent level

            indentReset = new ZeroIndent(); //helper class to have no indentation after the label
        }

        public FixedWidthLabel(string label)
            : this(new GUIContent(label), PlayFabEditorHelper.uiStyle.GetStyle("labelStyle")) //alternative constructor, if we don't want to deal with GUIContents
        {
        }

        public void Dispose() //restore GUI state
        {
            indentReset.Dispose(); //restore indentation
            EditorGUILayout.EndHorizontal(); //finish horizontal group
        }
    }

    class ZeroIndent : IDisposable //helper class to clear indentation
    {
        private readonly int originalIndent; //the original indentation value before we change the GUI state

        public ZeroIndent()
        {
            originalIndent = EditorGUI.indentLevel; //save original indentation
            EditorGUI.indentLevel = 0; //clear indentation
        }

        public void Dispose()
        {
            EditorGUI.indentLevel = originalIndent; //restore original indentation
        }
    }
}
