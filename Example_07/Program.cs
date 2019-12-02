using System;
using Example_07.Homework;
using Example_07.Mediators;
using Example_07.Observers;
using Example_07.States;

namespace Example_07
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //ObserverExample();
            //MediatorExample1();
            //MediatorExample2();
            //StateExample();

            StateHomework();
            Console.WriteLine();
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static void StateHomework()
        {
            var machine = new CopyMachine();
            machine.PutMoney(6);
            machine.SetDevice(new UsbFlashDrive());
            machine.ChooseDocument(new WordDocument());
            machine.PrintDocument();
            machine.ChooseDocument(new PdfDocument());
            machine.PrintDocument();
            var c = machine.GetBackChange();
            Console.WriteLine(c);
        }

        private static void ObserverExample()
        {
            var observer = new LessonObserver();

            var student1 = new Student("Adam");
            var student2 = new Student("Peter");
            var student3 = new Student("Max");

            var lector = new Lector("Prof. Smith");

            observer.Attach(student1);
            observer.Attach(student2);
            observer.Attach(student3);
            observer.Attach(lector);

            student1.Say("something");
            Console.WriteLine();

            student2.Say("some noize!");
            Console.WriteLine();

            observer.Detach(student1);
            student3.Say("question?");
            Console.WriteLine();

            Console.WriteLine("Ring");
            observer.Ring();
            Console.WriteLine();
        }

        private static void MediatorExample1()
        {
            var badDataGenerator = new BadDataGenerator();
            badDataGenerator.Run();
            Console.WriteLine();

            var goodDataGenerator1 = new GoodDataGenerator();
            var mediator1 = new DefaultConsoleWriterMediator(goodDataGenerator1, new ConsoleWriter());
            goodDataGenerator1.Run();
            Console.WriteLine();

            var goodDataGenerator2 = new GoodDataGenerator();
            var mediator2 = new RedConsoleWriterMediator(goodDataGenerator2, new RedConsoleWriter());
            goodDataGenerator2.Run();
            Console.WriteLine();
        }

        private static void MediatorExample2()
        {
            var nameControl = new TextControl();
            var ageControl = new DateControl();
            var okButton = new ButtonControl { Name = "Ok", IsActive = false };
            var closeButton = new ButtonControl { Name = "Close" };

            var mediator = new AgeConfirmDialogMediator(ageControl, okButton);
            ageControl.Mediator = mediator;
            okButton.Mediator = mediator;

            var dialog = new Dialog()
            {
                Controls = new Control[]
                {
                    nameControl, //0
                    ageControl,  //1
                    okButton,    //2
                    closeButton  //3
                }
            };

            (dialog.Controls[2] as ButtonControl).Click();

            (dialog.Controls[1] as DateControl).Value = new DateTime(2010, 01, 01);
            (dialog.Controls[2] as ButtonControl).Click();

            (dialog.Controls[1] as DateControl).Value = new DateTime(1990, 01, 01);
            (dialog.Controls[2] as ButtonControl).Click();
        }


        private static void StateExample()
        {
            var context1 = new ConnectionContext("Url_1");
            context1.Connect();
            context1.Read();
            context1.Close();
            Console.WriteLine();

            try
            {
                var context2 = new ConnectionContext("Url_2");
                context2.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"context2: {ex.Message}");
            }
            Console.WriteLine();

            try
            {
                var context3 = new ConnectionContext("Url_3");
                context3.Connect();
                context3.Read();
                context3.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"context3: {ex.Message}");
            }
            Console.WriteLine();
        }
    }
}
