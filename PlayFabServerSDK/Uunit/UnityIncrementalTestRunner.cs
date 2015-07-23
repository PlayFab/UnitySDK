using UnityEngine;

public class UnityIncrementalTestRunner : MonoBehaviour
{
    UUnitTestSuite suite = new UUnitTestSuite();

    public void Start()
    {
        suite.FindAndAddAllTestCases(typeof(UUnitTestCase));
    }

    public void Update()
    {
        if (suite.RunOneTest())
        {
            UUnitTestResult result = suite.GetResults();
            Debug.Log(result.Summary());
            GameObject.Destroy(gameObject);
        }
    }
}
