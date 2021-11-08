using System;

namespace Course.Managers.LocalizationManager
{
    [Serializable]
    public struct LocalizedString
    {
        public string LocalizationID;

        public LocalizedString(string id)
        {
            LocalizationID = id;
        }
    }
}
