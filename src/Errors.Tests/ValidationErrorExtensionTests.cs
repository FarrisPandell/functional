﻿namespace SleepingBear.Functional.Errors.Tests;

/// <summary>
/// Tests for <see cref="ValidationErrorExtensions"/>.
/// </summary>
internal static class ValidationErrorExtensionTests
{
    [Test]
    public static void ToValidationError_NoTag_ReturnsValidationError()
    {
        var result = "message".ToValidationError();
        Assert.Multiple(() =>
        {
            Assert.That(result.Message, Is.EqualTo("message"));
            Assert.That(result.Tag, Is.Empty);
        });
    }

    [Test]
    public static void ToValidationError_NullTag_ReturnEmptyTag()
    {
        var result = "message".ToValidationError(null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Message, Is.EqualTo("message"));
            Assert.That(result.Tag, Is.Empty);
        });
    }

    [Test]
    public static void ToValidationError_ValidatesBehavior()
    {
        var result = "message".ToValidationError("tag");
        Assert.Multiple(() =>
        {
            Assert.That(result.Message, Is.EqualTo("message"));
            Assert.That(result.Tag, Is.EqualTo("tag"));
        });
    }
}
