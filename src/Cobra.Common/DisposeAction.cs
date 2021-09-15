using System;
using System.Threading;

namespace Cobra.Common;

/// <summary>
/// This class can be used to provide an action when
/// Dipose method is called.
/// </summary>
public class DisposeAction : IDisposable
{
    public readonly static DisposeAction Empty;

    private Action _action;

    static DisposeAction()
    {
        DisposeAction.Empty = new DisposeAction(null);
    }

    /// <summary>
    /// Creates a new <see cref="T:Abp.DisposeAction" /> object.
    /// </summary>
    /// <param name="action">Action to be executed when this object is disposed.</param>
    public DisposeAction(Action action)
    {
        this._action = action;
    }

    public void Dispose()
    {
        Action action = Interlocked.Exchange<Action>(ref this._action, null);
        if (action == null)
        {
            return;
        }
        action();
    }
}