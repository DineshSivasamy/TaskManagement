using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public enum UserRole
    {
        User,
        Admin,
        SuperAdmin
    }

    public enum JiraStatus
    {
        ToDo,
        InProgress,
        Review,
        Done
    }
}
