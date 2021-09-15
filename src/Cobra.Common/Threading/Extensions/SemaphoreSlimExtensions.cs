using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Cobra.Common.Threading.Extensions;

public static class SemaphoreSlimExtensions
{
    private static IDisposable GetDispose(this SemaphoreSlim semaphoreSlim)
    {
        return new DisposeAction(() => semaphoreSlim.Release());
    }

    public static IDisposable Lock(this SemaphoreSlim semaphoreSlim)
    {
        semaphoreSlim.Wait();
        return semaphoreSlim.GetDispose();
    }

    public static IDisposable Lock(this SemaphoreSlim semaphoreSlim, CancellationToken cancellationToken)
    {
        semaphoreSlim.Wait(cancellationToken);
        return semaphoreSlim.GetDispose();
    }

    public static IDisposable Lock(this SemaphoreSlim semaphoreSlim, int millisecondsTimeout)
    {
        semaphoreSlim.Wait(millisecondsTimeout);
        return semaphoreSlim.GetDispose();
    }

    public static IDisposable Lock(this SemaphoreSlim semaphoreSlim, int millisecondsTimeout, CancellationToken cancellationToken)
    {
        semaphoreSlim.Wait(millisecondsTimeout, cancellationToken);
        return semaphoreSlim.GetDispose();
    }

    public static IDisposable Lock(this SemaphoreSlim semaphoreSlim, TimeSpan timeout)
    {
        semaphoreSlim.Wait(timeout);
        return semaphoreSlim.GetDispose();
    }

    public static IDisposable Lock(this SemaphoreSlim semaphoreSlim, TimeSpan timeout, CancellationToken cancellationToken)
    {
        semaphoreSlim.Wait(timeout, cancellationToken);
        return semaphoreSlim.GetDispose();
    }

    public static async Task<IDisposable> LockAsync(SemaphoreSlim semaphoreSlim)
    {
        await semaphoreSlim.WaitAsync().ConfigureAwait(false);
        return semaphoreSlim.GetDispose();
    }

    public static async Task<IDisposable> LockAsync(SemaphoreSlim semaphoreSlim, CancellationToken cancellationToken)
    {
        await semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
        return semaphoreSlim.GetDispose();
    }

    public static async Task<IDisposable> LockAsync(SemaphoreSlim semaphoreSlim, int millisecondsTimeout)
    {
        ConfiguredTaskAwaitable<bool> configuredTaskAwaitable = semaphoreSlim.WaitAsync(millisecondsTimeout).ConfigureAwait(false);
        await configuredTaskAwaitable;
        return semaphoreSlim.GetDispose();
    }

    public static async Task<IDisposable> LockAsync(SemaphoreSlim semaphoreSlim, int millisecondsTimeout, CancellationToken cancellationToken)
    {
        ConfiguredTaskAwaitable<bool> configuredTaskAwaitable = semaphoreSlim.WaitAsync(millisecondsTimeout, cancellationToken).ConfigureAwait(false);
        await configuredTaskAwaitable;
        return semaphoreSlim.GetDispose();
    }

    public static async Task<IDisposable> LockAsync(SemaphoreSlim semaphoreSlim, TimeSpan timeout)
    {
        ConfiguredTaskAwaitable<bool> configuredTaskAwaitable = semaphoreSlim.WaitAsync(timeout).ConfigureAwait(false);
        await configuredTaskAwaitable;
        return semaphoreSlim.GetDispose();
    }

    public static async Task<IDisposable> LockAsync(SemaphoreSlim semaphoreSlim, TimeSpan timeout, CancellationToken cancellationToken)
    {
        ConfiguredTaskAwaitable<bool> configuredTaskAwaitable = semaphoreSlim.WaitAsync(timeout, cancellationToken).ConfigureAwait(false);
        await configuredTaskAwaitable;
        return semaphoreSlim.GetDispose();
    }
}