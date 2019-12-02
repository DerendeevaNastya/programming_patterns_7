using System;
using System.Collections.Generic;

namespace Example_07.Homework
{
    public abstract class CopyMachineState
    {
        public virtual void PutMoney(CopyMachine machine, int value)
        {
            throw new System.NotImplementedException();
        }

        public virtual void SetDevice(CopyMachine machine, IDevice device)
        {
            throw new System.NotImplementedException();
        }

        public virtual void ChooseDocument(CopyMachine machine, IDocument document)
        {
            throw new System.NotImplementedException();
        }

        public virtual void PrintDocument(CopyMachine machine)
        {
            throw new System.NotImplementedException();
        }

        public virtual int GetBackChange(CopyMachine machine)
        {
            throw new System.NotImplementedException();
        }
    }

    public class EntryCopyMachineState : CopyMachineState
    {
        public override void PutMoney(CopyMachine machine, int value)
        {
            Console.WriteLine($"You put {value}");
            machine.FreeMoney = value;
            machine.State = new ChooseDeviceCopyMachineState();
        }
    }
    
    public class ChooseDeviceCopyMachineState : CopyMachineState
    {
        public override void SetDevice(CopyMachine machine, IDevice device)
        {
            Console.WriteLine($"You set {device.GetDeviceName()} device");
            machine.State = new ChooseDocumentCopyMachineState();
        }
    }
    
    public class ChooseDocumentCopyMachineState : CopyMachineState
    {
        private Dictionary<DocumentType, int> Prices = new Dictionary<DocumentType, int>
        {
            {DocumentType.Word, 2},
            {DocumentType.PDF, 3},
            {DocumentType.Image, 4}
        };
        
        public override void ChooseDocument(CopyMachine machine, IDocument document)
        {
            Console.WriteLine($"You want to print {document.GetType()} document");
            var money = Prices[document.GetType()];
            if (machine.FreeMoney >= money)
            {
                machine.FreeMoney -= money;
                machine.State = new PrintCopyMachineState(document.GetContent());
            }
            else
            {
                machine.State = new ChooseDeviceCopyMachineState();
            }
        }
        
        public override int GetBackChange(CopyMachine machine)
        {
            return machine.FreeMoney;
        }
    }
    
    public class PrintCopyMachineState : CopyMachineState
    {
        private readonly string _documentContent;
        public PrintCopyMachineState(string content)
        {
            _documentContent = content;
        }
        public override void PrintDocument(CopyMachine machine)
        {
            Console.WriteLine($"Machine printed: {_documentContent}");
            machine.State = new ChooseDocumentCopyMachineState();
        }
    }
}