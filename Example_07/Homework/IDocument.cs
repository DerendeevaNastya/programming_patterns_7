namespace Example_07.Homework
{
    public interface IDocument
    {
        DocumentType GetType();
        string GetContent();
    }

    public class PdfDocument : IDocument
    {
        public new DocumentType GetType() => DocumentType.PDF;
        public string GetContent() => "kek lol arbidol";
    }

    public class WordDocument : IDocument
    {
        public new DocumentType GetType() => DocumentType.Word;
        public string GetContent() => "lol kek cheburek";
    }

    public enum DocumentType
    {
        Word = 1,
        PDF = 2,
        Image = 3
    }
}