using System;

// Product
abstract class Document
{
    public abstract void Open();
}

// Concrete Products
class WordDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening Word Document");
    }
}

class PdfDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening PDF Document");
    }
}

// Creator
abstract class DocumentFactory
{
    public abstract Document CreateDocument();
}

// Concrete Creators
class WordFactory : DocumentFactory
{
    public override Document CreateDocument()
    {
        return new WordDocument();
    }
}

class PdfFactory : DocumentFactory
{
    public override Document CreateDocument()
    {
        return new PdfDocument();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        DocumentFactory factory;

        factory = new WordFactory();
        Document doc1 = factory.CreateDocument();
        doc1.Open();

        factory = new PdfFactory();
        Document doc2 = factory.CreateDocument();
        doc2.Open();
    }
}