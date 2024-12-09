using AnalaizerClassLibrary;
using NUnit.Framework;

[TestFixture]
public class CheckCurrencyTests
{
    [Test]
    public void CheckCurrency_ValidExpression_ReturnsTrue()
    {
        // ����� � ����������� �������
        AnalaizerClass.expression = "(a + b) * c";
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ����� ���������
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithExcessiveBracketDepth_ReturnsFalse()
    {
        // ����� � �������� �������� ��������� �����
        AnalaizerClass.expression = "(((())))"; // ������, �� MAX_DEPTH_BRACKET
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ����� �� ������� ����� ����������� �������
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithClosingBracketWithoutOpening_ReturnsFalse()
    {
        // ����� � ����������� ������ ��� ����������
        AnalaizerClass.expression = "(a + b)";
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ����� �� ������� ����� ����������� ������������ ���������� �����
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithOpeningBracketWithoutClosing_ReturnsFalse()
    {
        // ����� � ����������� ������ ��� ����������
        AnalaizerClass.expression = "(a + b";
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ����� �� ������� ����� ����������� ������������ ���������� �����
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithValidNestedBrackets_ReturnsTrue()
    {
        // ����� � ���������� �������
        AnalaizerClass.expression = "(a + (b - c))";
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ����� � ��������� ���������� ������� ��������� ��������
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_EmptyExpression_ReturnsTrue()
    {
        // ������� �����
        AnalaizerClass.expression = "";
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ������� ����� ��������� ���������
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithValidBracketsAndOperators_ReturnsTrue()
    {
        // ����� � ����������� � ����������� �������
        AnalaizerClass.expression = "(a + b) * c";
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ����� � ����������� � ����������� ������� ��������� ��������
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithInvalidCharacter_ReturnsFalse()
    {
        // ����� � �������� ��������, ���������, %) � ������� ������
        AnalaizerClass.expression = "(a + b) %)";
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ����� � ����������� �������� �� ���������
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithEmptyParentheses_ReturnsTrue()
    {
        // ����� � �������� �������
        AnalaizerClass.expression = "(a + b) * ()";
        var result = AnalaizerClass.CheckCurrency();

        // ��������, �� ������ ����� ������ ����������� � ����� ���� ���������
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithMismatchedParentheses_ReturnsFalse()
    {
        // ����� � ������������ �������
        AnalaizerClass.expression = "(a + b";

        // ��������, �� ����� ������� false ����� ����������� ������� �����
        var result = AnalaizerClass.CheckCurrency();

        // �������, �� ����� ������� false, ������� ������� ����� �����������
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckCurrency_ExpressionWithValidParentheses_ReturnsTrue()
    {
        // ����� � ��������� ������� �����
        AnalaizerClass.expression = "(a + b)";

        // ��������, �� ����� ������� true, ������� ������� ����� ���������
        var result = AnalaizerClass.CheckCurrency();

        // �������, �� ����� ������� true
        Assert.IsTrue(result);
    }

}
