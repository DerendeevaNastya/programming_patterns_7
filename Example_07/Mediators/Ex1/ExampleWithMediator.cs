using System.Collections.Generic;

namespace Example_07.Mediators
{
    public class GoodDataGenerator
    {
        public IWriterMediator WriterMediator { get; set; }

        public void Run()
        {
            foreach (var str in Data)
            {
                WriterMediator.UpdateData(str);
            }
        }

        private static IEnumerable<string> Data
        {
            get
            {
                yield return "str_1";
                yield return "str_2";
                yield return "str_3";
                yield return "str_4";
                yield return "str_5";
            }
        }
    }

    public interface IWriterMediator
    {
        void UpdateData(string data);
    }

    public class DefaultConsoleWriterMediator : IWriterMediator
    {
        private readonly ConsoleWriter _consoleWriter;

        public DefaultConsoleWriterMediator(GoodDataGenerator dataGenerator, ConsoleWriter consoleWriter)
        {
            dataGenerator.WriterMediator = this;
            _consoleWriter = consoleWriter;
        }

        public void UpdateData(string data)
        {
            _consoleWriter.Write(data);
        }
    }

    public class RedConsoleWriterMediator : IWriterMediator
    {
        private readonly RedConsoleWriter _consoleWriter;

        public RedConsoleWriterMediator(GoodDataGenerator dataGenerator, RedConsoleWriter consoleWriter)
        {
            dataGenerator.WriterMediator = this;
            _consoleWriter = consoleWriter;
        }

        public void UpdateData(string data)
        {
            _consoleWriter.Write(data);
        }
    }
}