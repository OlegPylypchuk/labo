using AnalaizerClassLibrary;
using NUnit.Framework;

[TestFixture]
public class CheckCurrencyTests
{
    [Test]
    public void CheckCurrency_ValidExpression_ReturnsTrue()
    {
        // Вираз з правильними дужками
        AnalaizerClass.expression = "(a + b) * c";
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що вираз коректний
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithExcessiveBracketDepth_ReturnsFalse()
    {
        // Вираз з надмірною глибиною вкладених дужок
        AnalaizerClass.expression = "(((())))"; // глибше, ніж MAX_DEPTH_BRACKET
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що вираз не пройшов через перевищення глибини
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithClosingBracketWithoutOpening_ReturnsFalse()
    {
        // Вираз з закриваючою дужкою без відкриваючої
        AnalaizerClass.expression = "(a + b)";
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що вираз не пройшов через неправильне використання закриваючої дужки
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithOpeningBracketWithoutClosing_ReturnsFalse()
    {
        // Вираз з відкриваючою дужкою без закриваючої
        AnalaizerClass.expression = "(a + b";
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що вираз не пройшов через неправильне використання відкриваючої дужки
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithValidNestedBrackets_ReturnsTrue()
    {
        // Вираз з вкладеними дужками
        AnalaizerClass.expression = "(a + (b - c))";
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що вираз з правильно вкладеними дужками проходить перевірку
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_EmptyExpression_ReturnsTrue()
    {
        // Порожній вираз
        AnalaizerClass.expression = "";
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що порожній вираз вважається коректним
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithValidBracketsAndOperators_ReturnsTrue()
    {
        // Вираз з операторами і правильними дужками
        AnalaizerClass.expression = "(a + b) * c";
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що вираз з операторами і правильними дужками проходить перевірку
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithInvalidCharacter_ReturnsFalse()
    {
        // Вираз з недійсним символом, наприклад, %) в середині виразу
        AnalaizerClass.expression = "(a + b) %)";
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що вираз з некоректним символом не проходить
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithEmptyParentheses_ReturnsTrue()
    {
        // Вираз з порожніми дужками
        AnalaizerClass.expression = "(a + b) * ()";
        var result = AnalaizerClass.CheckCurrency();

        // Перевірка, що порожні дужки будуть проігноровані і вираз буде коректним
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithMismatchedParentheses_ReturnsFalse()
    {
        // Вираз з невідповідними дужками
        AnalaizerClass.expression = "(a + b";

        // Перевірка, що метод повертає false через неправильну кількість дужок
        var result = AnalaizerClass.CheckCurrency();

        // Очікуємо, що метод поверне false, оскільки кількість дужок неправильна
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithValidParentheses_ReturnsTrue()
    {
        // Вираз з коректною кількістю дужок
        AnalaizerClass.expression = "(a + b)";

        // Перевірка, що метод повертає true, оскільки кількість дужок правильна
        var result = AnalaizerClass.CheckCurrency();

        // Очікуємо, що метод поверне true
        Assert.IsTrue(result);
    }

}
