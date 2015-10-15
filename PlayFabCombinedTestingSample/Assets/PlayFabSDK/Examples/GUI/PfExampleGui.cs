using System;
using UnityEngine;

namespace PlayFab.Examples
{
    /// <summary>
    /// A light wrapper around UnityEngine.Gui to pre-size and arrange a grid of buttons
    /// </summary>
    [RequireComponent(typeof(PfExampleRenderer))]
    public class PfExampleGui : MonoBehaviour
    {
        private int buffer = 22;
        private int rowHeight = 22;
        private int rowWidth = 110;
        private int ctrWidth = 12;

        /// <summary>
        /// This is automatically called every tick from ExampleRenderer.
        /// It is not intended to be called from anywhere else.
        /// </summary>
        internal void SetDimensions(int buffer, int rowWidth, int rowHeight, int ctrWidth)
        {
            this.buffer = buffer;
            this.rowHeight = rowHeight;
            this.rowWidth = rowWidth;
            this.ctrWidth = ctrWidth;
        }

        public virtual void OnExampleGUI(ref int rowIndex)
        {
            // This should be implemented in each example
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
    }
}
