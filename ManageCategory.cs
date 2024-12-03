using System;

namespace SNACK_MAN
{
    internal class ManageCategory
    {
        private string authorityLevel;
        private object employeeId;

        public ManageCategory(string authorityLevel, object employeeId)
        {
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}