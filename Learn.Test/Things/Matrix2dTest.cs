namespace Learn.Test;
using Learn;
using Xunit;

public class Matrix2dTest
{
    [Fact]
    public void Constructor_NoArguments_Works()
    {
        var empty = new List<List<string>>();
        var matrix2d = new Matrix2d<string>(empty, string.Empty);
        Assert.Equal(0, matrix2d.Height);
        Assert.Equal(0, matrix2d.Width);
    }

    [Fact]
    public void Empty_CreatesEmptyMatrix()
    {
        var defaultValue = "Default";
        var empty = Matrix2d<string>.Empty(defaultValue);
        Assert.Equal(0, empty.Height);
        Assert.Equal(0, empty.Width);
        Assert.False(empty.Contains(0, 0));
        Assert.Equal(defaultValue, empty[0, 0]);
    }

    [Fact]
    public void Constructor_SmallMatrix_Works() 
    {
        var data = Get2x2Data();
        var matrix = new Matrix2d<int>(data, 0);
        Assert.Equal(2, matrix.Height);
        Assert.Equal(2, matrix.Width);
    }

    [Fact]
    public void Get_OutsideBounds_ReturnsDefault()
    {
        var expected = "default value";
        var empty = new List<List<string>>();
        var matrix2d = new Matrix2d<string>(empty, expected);
        var actual = matrix2d[256, 736];
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_InsideMatrix_Works() 
    {
        var matrix = new Matrix2d<int>(Get2x2Data(), 0);
        Assert.Equal(3, matrix.Get(0,1));
        Assert.Equal(1, matrix.Get(1,1));
    }

    [Fact]
    public void Print_SmallMatrix_HasValuesAndLineBreaks()
    {
        var matrix = new Matrix2d<int>(Get2x2Data(), 0);
        var matrixString = matrix.ToString();
        Assert.Equal("13\n31", matrixString);
    }

    [Fact]
    public void Contains_InsideBounds_True()
    {
        var matrix = new Matrix2d<int>(Get2x2Data(), 0);
        matrix[1, 1] = 0;
        Assert.True(matrix.Contains(1, 1));
    }

    [Fact]
    public void Contains_OutsideBounds_False()
    {
        var matrix = new Matrix2d<int>(Get2x2Data(), 0);
        Assert.False(matrix.Contains(2, 2));
    }

    private List<List<int>> Get2x2Data()
    {
        var row = new List<int>() { 1, 3 };
        return new List<List<int>>() { row, Enumerable.Reverse(row).ToList() };
    }

}
