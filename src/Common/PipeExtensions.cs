﻿// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace SleepingBear.Functional.Common;

/// <summary>
/// Extensions methods for piping.
/// </summary>
public static class PipeExtensions
{
    /// <summary>
    /// Pipes a value.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="func"></param>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <returns></returns>
    public static TOut Pipe<TIn, TOut>(this TIn value, Func<TIn, TOut> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return func(value);
    }

    /// <summary>
    /// Pipes a value asynchronously.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="func"></param>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <returns></returns>
    public static async Task<TOut> PipeAsync<TIn, TOut>(this Task<TIn> task, Func<TIn, TOut> func)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(func);

        var value = await task.ConfigureAwait(false);
        return func(value);
    }

    /// <summary>
    /// Pipes a value asynchronously.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="func"></param>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <returns></returns>
    public static async Task<TOut> PipeAsync<TIn, TOut>(this Task<TIn> task, Func<TIn, Task<TOut>> func)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(func);

        var value = await task.ConfigureAwait(false);
        return await func(value).ConfigureAwait(false);
    }

    /// <summary>
    /// Taps a value.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="action"></param>
    /// <typeparam name="TIn"></typeparam>
    /// <returns></returns>
    public static TIn Tap<TIn>(this TIn value, Action<TIn> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        action(value);
        return value;
    }

    /// <summary>
    /// Taps a value asynchronously.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="action"></param>
    /// <typeparam name="TIn"></typeparam>
    /// <returns></returns>
    public static async Task<TIn> TapAsync<TIn>(this Task<TIn> task, Action<TIn> action)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(action);

        var value = await task.ConfigureAwait(false);
        action(value);
        return value;
    }

    /// <summary>
    /// Taps a value asynchronously.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="func"></param>
    /// <typeparam name="TIn"></typeparam>
    /// <returns></returns>
    public static async Task<TIn> TapAsync<TIn>(this Task<TIn> task, Func<TIn, Task> func)
    {
        ArgumentNullException.ThrowIfNull(task);
        ArgumentNullException.ThrowIfNull(func);

        var value = await task.ConfigureAwait(false);
        await func(value).ConfigureAwait(false);
        return value;
    }
}