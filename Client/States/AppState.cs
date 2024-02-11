﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.States;

public class AppState
{
    private bool _loggedIn;
    public event Action OnChange;
    public bool LoggedIn
    {
        get { return _loggedIn; }
        set
        {
            _loggedIn = value;
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}