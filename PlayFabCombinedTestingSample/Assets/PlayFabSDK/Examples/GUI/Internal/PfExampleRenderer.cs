using UnityEngine;
using System.Collections;

namespace PlayFab.Examples
{
    /// <summary>
    /// Cooperatively displays all other PfExampleGuis on this gameObject 
    /// </summary>
    public class PfExampleRenderer : PfExampleGui
    {
        public int buffer = 22;
        public int rowHeight = 22;
        public int rowWidth = 110;
        public int ctrWidth = 12;

        private string activeComponent = null;

        public void OnGUI()
        {
            var allExampleComponents = GetComponents<PfExampleGui>();
            PfExampleGui displayedComponent = null;

            int rowIndex = 0, colIndex = 0;
            string eachExampleName, nextActiveComponent = activeComponent;
            foreach (var eachComponent in allExampleComponents)
            {
                if (object.ReferenceEquals(this, eachComponent))
                    continue; // Don't display ourself, we're already doing that

                eachExampleName = eachComponent.GetType().Name.Replace("ExampleGui","");
                if (activeComponent == eachExampleName || (activeComponent == null && eachExampleName.Contains("Login")))
                    displayedComponent = eachComponent;

                Button(true, rowIndex, colIndex++, eachExampleName, () => { nextActiveComponent = eachExampleName; });
            }
            rowIndex += 2;

            if (displayedComponent != null)
            {
                displayedComponent.SetDimensions(buffer, rowWidth, rowHeight, ctrWidth);
                displayedComponent.OnExampleGUI(ref rowIndex);
            }

            activeComponent = nextActiveComponent;
        }
    }
}
