using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;

namespace PlayFab.Examples
{
    /// <summary>
    /// A light wrapper around UnityEngine.Gui to pre-size and arrange a grid of buttons
    /// </summary>
    [RequireComponent(typeof(PfExampleRenderer))]
    public class PfExampleGui : MonoBehaviour
    {
        private int _buffer = 22;
        private int _rowHeight = 22;
        private int _rowWidth = 110;
        private int _ctrWidth = 12;

        /// <summary>
        /// This is automatically called every tick from ExampleRenderer.
        /// It is not intended to be called from anywhere else.
        /// </summary>
        internal void SetDimensions(int buffer, int rowWidth, int rowHeight, int ctrWidth)
        {
            _buffer = buffer;
            _rowHeight = rowHeight;
            _rowWidth = rowWidth;
            _ctrWidth = ctrWidth;
        }

        public virtual void OnExampleGUI(ref int rowIndex)
        {
            // This should be implemented in each example
        }

        protected void Button(bool condition, int row, int column, string text, Action action)
        {
            if (condition && GUI.Button(new Rect(_buffer + _rowWidth * column, _buffer + _rowHeight * row, _rowWidth, _rowHeight), text))
                action();
        }

        protected void Button(bool condition, int row, int column, string text, object instance, MethodInfo action, params object[] actionParams)
        {
            if (condition && GUI.Button(new Rect(_buffer + _rowWidth * column, _buffer + _rowHeight * row, _rowWidth, _rowHeight), text))
            {
                if (instance == null)
                    action.Invoke(null, BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, actionParams, CultureInfo.CurrentCulture);
                else
                    action.Invoke(instance, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, actionParams, CultureInfo.CurrentCulture);
            }
        }

        protected void TextField(bool condition, int row, int column, ref string text)
        {
            if (condition)
                text = GUI.TextField(new Rect(_buffer + _rowWidth * column, _buffer + _rowHeight * row, _rowWidth, _rowHeight), text);
        }

        protected string TextField(bool condition, int row, int column, string text)
        {
            if (condition)
                text = GUI.TextField(new Rect(_buffer + _rowWidth * column, _buffer + _rowHeight * row, _rowWidth, _rowHeight), text);
            return text;
        }

        protected void CounterField(bool condition, int row, int column, string text, MethodInfo incrementAction, MethodInfo decrementAction, params object[] actionParams)
        {
            int textWidth = _rowWidth - _ctrWidth;
            if (condition)
            {
                GUI.TextField(new Rect(_buffer + _rowWidth * column, _buffer + _rowHeight * row, textWidth, _rowHeight), text);
                if (GUI.Button(new Rect(_buffer + _rowWidth * column + textWidth, _buffer + _rowHeight * row, _ctrWidth, _rowHeight / 2), text))
                    incrementAction.Invoke(null, BindingFlags.Static | BindingFlags.Public, null, actionParams, CultureInfo.CurrentCulture);
                if (GUI.Button(new Rect(_buffer + _rowWidth * column + textWidth, _buffer + _rowHeight * row + _rowHeight / 2 + _rowHeight % 2, _ctrWidth, _rowHeight / 2), text))
                    decrementAction.Invoke(null, BindingFlags.Static | BindingFlags.Public, null, actionParams, CultureInfo.CurrentCulture);
            }
        }

        protected void DisplayDataHelper(ref int rowIndex, string dataDescription, Dictionary<string, string> data, Action refreshAction, MethodInfo updateAction, Dictionary<string, string> existingValuesCache, ref string newKey, ref string newValue)
        {
            Button(true, rowIndex, 0, dataDescription, refreshAction);
            rowIndex++;
            // Display each of the existing keys
            foreach (var userPair in data)
            {
                string eachKey = userPair.Key, eachValue;
                if (!existingValuesCache.TryGetValue(eachKey, out eachValue))
                    eachValue = userPair.Value;

                TextField(true, rowIndex, 0, eachKey); // Existing keys cannot be modified
                existingValuesCache[eachKey] = eachValue = TextField(true, rowIndex, 1, eachValue);
                Button(eachValue != userPair.Value, rowIndex, 2, string.IsNullOrEmpty(eachValue) ? "Delete key" : "Update", null, updateAction, eachKey, eachValue);
                Button(eachValue != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref newValue);
            Button(true, rowIndex, 2, "Add", null, updateAction, newKey, newValue);
            rowIndex++;
        }

        protected void DisplayDataHelper(ref int rowIndex, string dataDescription, Dictionary<string, int> data, Action refreshAction, MethodInfo updateAction, Dictionary<string, int> existingValuesCache, ref string newKey, ref int newValue)
        {
            int temp;
            bool canParse;
            string eachValue;

            Button(true, rowIndex, 0, dataDescription, refreshAction);
            rowIndex++;
            // Display each of the existing keys
            foreach (var userPair in data)
            {
                string eachKey = userPair.Key;
                if (existingValuesCache.TryGetValue(eachKey, out temp))
                    eachValue = temp.ToString();
                else
                    eachValue = userPair.Value.ToString();

                TextField(true, rowIndex, 0, eachKey); // Existing keys cannot be modified
                TextField(true, rowIndex, 1, ref eachValue);

                canParse = int.TryParse(eachValue, out temp);
                existingValuesCache[eachKey] = temp;
                Button(temp != userPair.Value, rowIndex, 2, string.IsNullOrEmpty(eachValue) ? "Delete key" : "Update", null, updateAction, eachKey, temp);
                Button(temp != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }
            eachValue = newValue.ToString();
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref eachValue);
            canParse = int.TryParse(eachValue, out temp);
            Button(canParse, rowIndex, 2, "Add", null, updateAction, newKey, temp);
            if (canParse)
                newValue = temp;
            rowIndex++;
        }

        protected void DisplayDataHelper(ref int rowIndex, string dataDescription, string playFabId, string characterId, Dictionary<string, string> data, MethodInfo refreshAction, MethodInfo updateAction, Dictionary<string, string> existingValuesCache, ref string newKey, ref string newValue)
        {
            if (characterId != null)
                Button(true, rowIndex, 0, dataDescription, null, refreshAction, playFabId, characterId);
            else
                Button(true, rowIndex, 0, dataDescription, null, refreshAction, playFabId);
            rowIndex++;
            // Display each of the existing keys
            foreach (var userPair in data)
            {
                string eachKey = userPair.Key, eachValue;
                if (!existingValuesCache.TryGetValue(eachKey, out eachValue))
                    eachValue = userPair.Value;

                TextField(true, rowIndex, 0, eachKey); // Existing keys cannot be modified
                TextField(true, rowIndex, 1, ref eachValue);

                existingValuesCache[eachKey] = eachValue;
                if (characterId != null)
                    Button(eachValue != userPair.Value, rowIndex, 2, "Update", null, updateAction, playFabId, characterId, eachKey, eachValue);
                else
                    Button(eachValue != userPair.Value, rowIndex, 2, "Update", null, updateAction, playFabId, eachKey, eachValue);
                Button(eachValue != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref newValue);
            if (characterId != null)
                Button(true, rowIndex, 2, "Add", null, updateAction, playFabId, characterId, newKey, newValue);
            else
                Button(true, rowIndex, 2, "Add", null, updateAction, playFabId, newKey, newValue);
            rowIndex++;
        }

        protected void DisplayDataHelper(ref int rowIndex, string dataDescription, string playFabId, string characterId, Dictionary<string, int> data, MethodInfo refreshAction, MethodInfo updateAction, Dictionary<string, int> existingValuesCache, ref string newKey, ref int newValue)
        {
            int temp;
            bool canParse;
            string eachValue;

            if (characterId != null)
                Button(true, rowIndex, 0, dataDescription, null, refreshAction, playFabId, characterId);
            else
                Button(true, rowIndex, 0, dataDescription, null, refreshAction, playFabId);
            rowIndex++;
            // Display each of the existing keys
            foreach (var userPair in data)
            {
                string eachKey = userPair.Key;
                if (existingValuesCache.TryGetValue(eachKey, out temp))
                    eachValue = temp.ToString();
                else
                    eachValue = userPair.Value.ToString();

                TextField(true, rowIndex, 0, eachKey); // Existing keys cannot be modified
                TextField(true, rowIndex, 1, ref eachValue);

                canParse = int.TryParse(eachValue, out temp);
                existingValuesCache[eachKey] = temp;
                if (characterId != null)
                    Button(temp != userPair.Value && canParse, rowIndex, 2, "Update", null, updateAction, playFabId, characterId, eachKey, temp);
                else
                    Button(temp != userPair.Value && canParse, rowIndex, 2, "Update", null, updateAction, playFabId, eachKey, temp);
                Button(temp != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }
            eachValue = newValue.ToString();
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref eachValue);
            canParse = int.TryParse(eachValue, out temp);
            if (characterId != null)
                Button(canParse, rowIndex, 2, "Add", null, updateAction, playFabId, characterId, newKey, temp);
            else
                Button(canParse, rowIndex, 2, "Add", null, updateAction, playFabId, newKey, temp);
            if (canParse)
                newValue = temp;
            rowIndex++;
        }

        protected void DisplayReadOnlyDataHelper<VT>(ref int rowIndex, string dataDescription, Dictionary<string, VT> data, Action refreshAction)
        {
            Button(true, rowIndex, 0, dataDescription, refreshAction);
            rowIndex++;
            // Display each of the existing keys
            foreach (var userPair in data)
            {
                TextField(true, rowIndex, 0, userPair.Key);
                TextField(true, rowIndex, 1, userPair.Value.ToString());
                rowIndex++;
            }
        }
    }
}
