using NUnit.Framework;
using System;
using Zad5;

[TestFixture]
public class AnagramCheckerTests
{
    private IAnagramChecker _anagramChecker;

    [SetUp]
    public void Setup()
    {
        _anagramChecker = new AnagramChecker(); // Replace with your actual implementation
    }

    [Test]
    public void AreAnagrams_WhenWordsAreAnagrams_ShouldReturnTrue()
    {
        // Arrange
        string word1 = "listen";
        string word2 = "silent";

        // Act
        bool result = _anagramChecker.IsAnagram(word1, word2);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreAnagrams_WhenWordsHaveDifferentCases_ShouldReturnTrue()
    {
        // Arrange
        string word1 = "Tea";
        string word2 = "Eat";

        // Act
        bool result = _anagramChecker.IsAnagram(word1, word2);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreAnagrams_WhenWordsContainNonAlphanumericCharacters_ShouldReturnTrue()
    {
        // Arrange
        string word1 = "Astronomer";
        string word2 = "Moon starer";

        // Act
        bool result = _anagramChecker.IsAnagram(word1, word2);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreAnagrams_WhenWordsAreNotAnagrams_ShouldReturnFalse()
    {
        // Arrange
        string word1 = "hello";
        string word2 = "world";

        // Act
        bool result = _anagramChecker.IsAnagram(word1, word2);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void AreAnagrams_WhenWordsHaveDifferentLengths_ShouldReturnFalse()
    {
        // Arrange
        string word1 = "listen";
        string word2 = "silentt"; // Different length

        // Act
        bool result = _anagramChecker.IsAnagram(word1, word2);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void AreAnagrams_WhenWordsAreNullOrEmpty_ShouldReturnFalse()
    {
        // Arrange
        string word1 = null;
        string word2 = "test";

        // Act
        bool result = _anagramChecker.IsAnagram(word1, word2);

        // Assert
        Assert.That(result, Is.False);
    }
}
