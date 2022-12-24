using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TheConstructorOfTheHeroShouldInitializeTheHeroCorrectly()
    {
        Hero hero = new Hero("Namew", 40);

        string expectedName = "Namew";
        string actualName = hero.Name;

        int expectedLevel = 40;
        int actualLevel = hero.Level;

        Assert.AreEqual(expectedName, actualName, "TheConstructorOfTheHeroShouldInitializeTheHeroCorrectly");
        Assert.AreEqual(expectedLevel, actualLevel, "TheConstructorOfTheHeroShouldInitializeTheHeroCorrectly");
    }

    [Test]
    public void TheConstructorShouldInitializeTheHerorepositoryCorrectly()
    {
        HeroRepository heroRepository = new HeroRepository();

        CollectionAssert.AreEqual(heroRepository.Heroes, new List<Hero>(), "TheConstructorShouldInitializeTheHerorepositoryCorrectly");
    }

    [Test]
    public void TheCreateMethodShouldThrowAnExceptionIfTheGivenHeroIsNull()
    {
        Hero hero = null;
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero);
        }, nameof(hero), "Hero is null");
    }

    [Test]
    public void TheCreateMethodShouldThrowAnExceptionIfTheRepositoryContainsAnotherHeroWithThisName()
    {
        Hero hero = new Hero("Name", 90);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        }, $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void TheCreateMethodShouldAddtheHeroToTheRepositoryAndReturnTheCorrectMessage()
    {
        Hero hero = new Hero("OOP", 12);
        HeroRepository heroRepository = new HeroRepository();

        string expectedMessage = $"Successfully added hero {hero.Name} with level {hero.Level}";
        string actualMessage = heroRepository.Create(hero);

        Assert.AreEqual(expectedMessage, actualMessage, "TheCreateMethodShouldAddtheHeroToTheRepositoryAndReturnTheCorrectMessage");
    }

    [Test]
    public void TheRemoveMethodShouldThrowAnExceptionIfTheGivenNameIsNullOrWhiteSpace()
    {
        HeroRepository heroREpository = new HeroRepository();
        string name = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroREpository.Remove(name);
        }, nameof(name), "Name cannot be null");
    }

    [Test]
    public void TheRemoveMethodShouldReturnTrueIfItRemoveSomethingFromTheRepository()
    {
        Hero hero = new Hero("OOP", 12);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);

        bool expectedValue = true;
        bool actualValue = heroRepository.Remove(hero.Name);

        Assert.AreEqual(expectedValue, actualValue, "TheRemoveMethodShouldReturnTrueIfItRemoveSomethingFromTheRepository");
    }

    [Test]
    public void TheGetHeroWithHighestLevelMethodShouldReturnCorrectHero()
    {
        Hero hero = new Hero("OOp", 12);
        Hero hero1 = new Hero("OOO", 122);
        Hero hero2 = new Hero("III", 999);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        Hero expectedHero = hero2;
        Hero actualHero = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedHero.Name, actualHero.Name, "TheGetHeroWithHighestLevelMethodShouldReturnCorrectHero");
        Assert.AreEqual(expectedHero.Level, actualHero.Level, "TheGetHeroWithHighestLevelMethodShouldReturnCorrectHero");
    }

    [Test]
    public void TheGetHeroMethodShouldReturnTheFirstOccuranceOfTheGivenName()
    {
        Hero hero = new Hero("OOP", 9);
        Hero hero1 = new Hero("LLK", 1);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);
        heroRepository.Create(hero1);

        Hero expectedHero = hero1;
        Hero actualHero = heroRepository.GetHero(hero1.Name);

        Assert.AreEqual(expectedHero.Name, actualHero.Name, "TheGetHeroMethodShouldReturnTheFirstOccuranceOfTheGivenName");
        Assert.AreEqual(expectedHero.Level, actualHero.Level, "TheGetHeroMethodShouldReturnTheFirstOccuranceOfTheGivenName");
    }
}