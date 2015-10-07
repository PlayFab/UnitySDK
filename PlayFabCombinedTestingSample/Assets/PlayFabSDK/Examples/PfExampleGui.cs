using System;
using UnityEngine;

namespace PlayFab.Examples
{
    /// <summary>
    /// A light wrapper around UnityEngine.Gui to pre-size and arrange a grid of buttons
    /// </summary>
    public class PfExampleGui : MonoBehaviour
    {
        #region Example inter-relationships
        // Automatically fetch components relevant to this example (when appropriate)
        protected static PfExampleGui activeWindow;
        protected static PfLoginExample loginExample;
        protected static PfInventoryExample invExample;
        protected static PfVcExample vcExample;
        protected static PfTradeExample tradeExample;
        #endregion Example inter-relationships

        public int buffer = 22;
        public int rowHeight = 22;
        public int rowWidth = 110;
        public int ctrWidth = 12;

        public virtual void OnExampleGUI(ref int rowIndex)
        {
        }

        protected void Button(bool condition, int row, int column, string text, Action action)
        {
            if (condition && GUI.Button(new Rect(buffer + rowWidth * column, buffer + rowHeight * row, rowWidth, rowHeight), text))
                action();
        }

        protected void TextField(bool condition, int row, int column, ref string text)
        {
            if (condition)
                text = GUI.TextField(new Rect(buffer + rowWidth * column, buffer + rowHeight * row, rowWidth, rowHeight), text);
        }

        protected string TextField(bool condition, int row, int column, string text)
        {
            if (condition)
                text = GUI.TextField(new Rect(buffer + rowWidth * column, buffer + rowHeight * row, rowWidth, rowHeight), text);
            return text;
        }

        protected void CounterField(bool condition, int row, int column, string text, Action Increment, Action Decrement)
        {
            int textWidth = rowWidth - ctrWidth;
            if (condition)
            {
                GUI.TextField(new Rect(buffer + rowWidth * column, buffer + rowHeight * row, textWidth, rowHeight), text);
                if (GUI.Button(new Rect(buffer + rowWidth * column + textWidth, buffer + rowHeight * row, ctrWidth, rowHeight / 2), text))
                    Increment();
                if (GUI.Button(new Rect(buffer + rowWidth * column + textWidth, buffer + rowHeight * row + rowHeight / 2 + rowHeight % 2, ctrWidth, rowHeight / 2), text))
                    Decrement();
            }
        }

        internal static ErrorCallback SharedFailCallback(string caller)
        {
            ErrorCallback output = (PlayFabError error) =>
            {
                Debug.LogError(caller + " failure: " + error.ErrorMessage);
            };
            return output;
        }
    }
}
