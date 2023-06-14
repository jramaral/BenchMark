// See https://aka.ms/new-console-template for more information

using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<MemoryBenchMarkerDemo>();


[RankColumn]
[MemoryDiagnoser]
public class MemoryBenchMarkerDemo
{
    private string title = "Sr.", name = "Jose", middleName = "Roberto", lastName = "Amaral";
    private readonly int NumberOfItems = 2;

    [Benchmark]
    public string ConcatStringsUsingStringBuilder()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < NumberOfItems; i++) sb.Append($"Hello World! {i}");

        return sb.ToString();
    }

    [Benchmark]
    public string? ConcatStringsUsingGenericList()
    {
        var list = new List<string>(NumberOfItems);
        for (var i = 0; i < NumberOfItems; i++) list.Add($"Hello World! {i}");

        return list.ToString();
    }

    [Benchmark]
    public string StringBuilder()
    {
        var stringBuilder = new StringBuilder();
        return stringBuilder
            .Append(title).Append(' ')
            .Append(name).Append(' ')
            .Append(middleName).Append(' ')
            .Append(lastName).Append(' ').ToString();
    }

    [Benchmark]
    public string StringBuilderExact24()
    {
        var stringBuilder = new StringBuilder(24);
        return stringBuilder
            .Append(title).Append(' ')
            .Append(name).Append(' ')
            .Append(middleName).Append(' ')
            .Append(lastName).Append(' ').ToString();
    }

    [Benchmark]
    public string StringBuilderEstimate100()
    {
        var stringBuilder = new StringBuilder(100);
        return stringBuilder
            .Append(title).Append(' ')
            .Append(name).Append(' ')
            .Append(middleName).Append(' ')
            .Append(lastName).Append(' ').ToString();
    }

    [Benchmark]
    public string StringPlus()
    {
        return title + ' ' + name + ' ' + middleName + ' ' + lastName;
    }

    [Benchmark]
    public string StringFormat()
    {
        return string.Format("{0} {1} {2} {3}", title, name, middleName, lastName);
    }

    [Benchmark]
    public string StringInterpolation()
    {
        return $"{title} {name} {middleName} {lastName}";
    }

    [Benchmark]
    public string StringJoin()
    {
        return string.Join(' ', title, name, middleName, lastName);
    }

    [Benchmark]
    public string StringConcat()
    {
        return string.Concat(new string[] { title, " ", name, " ", middleName, " ", lastName });
    }
}