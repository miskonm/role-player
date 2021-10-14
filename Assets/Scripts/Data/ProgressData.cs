using System;

namespace RolePlayer.Data
{
    [Serializable]
    public class ProgressData
    {
        public ExampleData ExampleData;

        public ProgressData()
        {
            ExampleData = new ExampleData();
        }
    }
}
