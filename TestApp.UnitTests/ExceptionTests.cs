using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "Apple";
        string expected = "elppA";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        string expectedMessage = "String cannot be null. (Parameter 's')";

        // Act & Assert
        Assert.That(() => _exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);

        try
        {
            _exceptions.ArgumentNullReverse(input);
        }
        catch (Exception ex)
        {
            Assert.AreEqual(expectedMessage, ex.Message);
        }
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        //Arrange
        decimal totalPrice = 200;
        decimal discount = 10;
        decimal expectedPrice = 180;

        //Act
        decimal result = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        //Assert
        Assert.That(result, Is.EqualTo(expectedPrice));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = -10;
        string expectedMessage = "Discount must be between 0 and 100. (Parameter 'discount')";

        // Act & Assert
        //Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
         ArgumentException ex = Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;
        string expectedMessage = "Discount must be between 0 and 100. (Parameter 'discount')";

        // Act & Assert
        ArgumentException ex = Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        //Arrange
        int[] input = new int[] { 2, 8, 7, -12 };
        int index = 1;
        int expected = 8;

        //Act 
        int result = _exceptions.IndexOutOfRangeGetElement(input, index);

        Assert.AreEqual(expected, result);
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = new int[] { 2, 8, 7, -12 };
        int index = -1;
        string expectedMessage = "Index is out of range.";

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(input, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length + 1;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        //Arrange
        bool input = true;
        string expectedMessage = "User logged in.";

        //Act
        string result = _exceptions.InvalidOperationPerformSecureOperation(input);

        //Assert
        Assert.That(result, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        //Arrange
        bool input = false;
        string expectedMessage = "User must be logged in to perform this operation.";

        //Act & Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _exceptions.InvalidOperationPerformSecureOperation(input));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        //Arrange
        string input = "13";
        int expected = 13;

        //Act
        int result = _exceptions.FormatExceptionParseInt(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        //Arrange
        string input = "12b";
        string expectedMessage = "Input is not in the correct format for an integer.";

        //Act & Assert
        FormatException ex = Assert.Throws<FormatException>(() => _exceptions.FormatExceptionParseInt(input));
        Assert.That(ex.Message, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        //Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
        };
        string key = "two";
        int expected = 2;

        //Act
        int result = _exceptions.KeyNotFoundFindValueByKey(input, key);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
        };
        string invalidKey = "four";
        string expectedMessage = "The specified key was not found in the dictionary.";

        //Act & Assert
        KeyNotFoundException ex = Assert.Throws<KeyNotFoundException>(() => _exceptions.KeyNotFoundFindValueByKey(input, invalidKey));
        Assert.That(ex.Message, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        //Arrange
        int a = 12;
        int b = 13;
        int expected = 25;

        //Act
        int result = _exceptions.OverflowAddNumbers(a, b);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = 2147483647;
        int b = 2;
        string expectedMessage = "Arithmetic overflow occurred during addition.";

        //Act & Assert
        OverflowException ex = Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(a, b));
        Assert.AreEqual(ex.Message, expectedMessage);
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {//Arrange
        int a = -2147483648;
        int b = -10;
        string expectedMessage = "Arithmetic overflow occurred during addition.";

        //Act & Assert
        OverflowException ex = Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(a, b));
        Assert.AreEqual(ex.Message, expectedMessage);
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        //Arrange
        int a = 25;
        int b = 5;
        int expected = 5;

        //Act
        int result = _exceptions.DivideByZeroDivideNumbers(a, b);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        //Arrange
        int a = 25;
        int b = 0;
        string expectedMessage = "Division by zero is not allowed.";

        //Act & Assert
        DivideByZeroException ex = Assert.Throws<DivideByZeroException>(() => _exceptions.DivideByZeroDivideNumbers(a, b));
        Assert.AreEqual(ex.Message, expectedMessage);
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        //Arrange
        int[] numbers = new int[] { 1, 2, 3, 4, 5 };
        int index = 3;
        int expected = 15;

        //Act
        int result = _exceptions.SumCollectionElements(numbers, index);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        //Arrange
        int[] numbers = null;
        int index = 0;
        string expectedMessage = "Collection cannot be null. (Parameter 'collection')";

        //Act & Assert
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _exceptions.SumCollectionElements(numbers, index));
        Assert.AreEqual(ex.Message, expectedMessage);
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        //Arrange
        int[] numbers = new int[] { 1, 2, 3, 4, 5 };
        int index = 5;
        string expectedMessage = "Index has to be within bounds.";

        //Act & Assert
        IndexOutOfRangeException ex = Assert.Throws<IndexOutOfRangeException>(() => _exceptions.SumCollectionElements(numbers, index));
        Assert.AreEqual(ex.Message, expectedMessage);
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        //Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3"
        };
        string key = "one";
        int expected = 1;

        //Act
        int result = _exceptions.GetElementAsNumber(input, key);

        //Assert
        Assert.AreEqual(expected, result);  
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3"
        };
        string key = "four";
        string expectedMessage = "Key not found in the dictionary.";

        //Act & Assert
        KeyNotFoundException ex = Assert.Throws<KeyNotFoundException>(() => _exceptions.GetElementAsNumber(input, key));
        Assert.AreEqual(ex.Message, expectedMessage);
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        //Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1a",
            ["two"] = "2b",
            ["three"] = "3c"
        };
        string key = "one";
        string expectedMessage = "Can't parse string.";

        //Act & Assert
        FormatException ex = Assert.Throws<FormatException>(() => _exceptions.GetElementAsNumber(input, key));
        Assert.AreEqual(ex.Message, expectedMessage);
    }
}
