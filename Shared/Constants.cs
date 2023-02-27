using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Constants
    {
        public enum UserRoles
        {
            Public,
            Editor,
            Writer
        }

        public enum StatusPosts
        {
            Pending,
            Rejected,
            Published
        }
    }
}
