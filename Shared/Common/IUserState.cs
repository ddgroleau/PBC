﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBC.Shared.Common
{
    public interface IUserState
    {
        public Task<string> CurrentUsernameAsync();

        public Task<string> CurrentUserIdAsync();
    }
}
