namespace Example_07.Homework
{
    public class CopyMachine
    {
        public CopyMachineState State;
        public int FreeMoney;

        public CopyMachine()
        {
            State = new EntryCopyMachineState();
        }

        public void PutMoney(int value)
        {
            State.PutMoney(this, value);
        }

        public void SetDevice(IDevice device)
        {
            State.SetDevice(this, device);
        }

        public void ChooseDocument(IDocument document)
        {
            State.ChooseDocument(this, document);
        }

        public void PrintDocument()
        {
            State.PrintDocument(this);
        }

        public int GetBackChange()
        {
            return State.GetBackChange(this);
        }
    }
}