using Forum.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.MVP.Helpers
{
    public static class Validator
    {
        public static bool IsContentValid(string content)
        {
            if (content.Length > GlobalConstants.ContentMinLength &&
                content.Length < GlobalConstants.ContentMaxLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsTitleValid(string title)
        {
            if (title.Length > GlobalConstants.TitleMinLength &&
                title.Length < GlobalConstants.TitleMaxLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
