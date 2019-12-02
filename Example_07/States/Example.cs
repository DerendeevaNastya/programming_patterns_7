using System;

namespace Example_07.States
{
    public class ConnectionContext
    {
        public string Url { get; }
        public IState State { get; set; }

        public ConnectionContext(string url)
        {
            Url = url;
            State = new InitState();
        }

        public void Connect()
        {
            State.Connect(this);
        }

        public byte[] Read()
        {
            return State.Read(this);
        }

        public void Close()
        {
            State.Close(this);
        }
    }

    public interface IState
    {
        void Connect(ConnectionContext context);
        byte[] Read(ConnectionContext context);
        void Close(ConnectionContext context);
    }

    public abstract class StateBase : IState
    {
        public virtual void Close(ConnectionContext context)
        {
            context.State = new CloseState();
        }

        public abstract void Connect(ConnectionContext context);
        public abstract byte[] Read(ConnectionContext context);
    }

    public class InitState : StateBase
    {
        public override void Connect(ConnectionContext context)
        {
            Console.WriteLine($"Connecting to {context.Url}");
            context.State = new ReadState();
        }

        public override byte[] Read(ConnectionContext context)
        {
            throw new Exception("Connection is not opened");
        }
    }

    public class ReadState : StateBase
    {
        public override void Connect(ConnectionContext context) { }

        public override byte[] Read(ConnectionContext context)
        {
            return new byte[0];
        }
    }

    public class CloseState : StateBase
    {
        public override void Connect(ConnectionContext context)
        {
            throw new Exception("Connection is closed");
        }

        public override byte[] Read(ConnectionContext context)
        {
            throw new Exception("Connection is closed");
        }

        public override void Close(ConnectionContext context)
        {
            throw new Exception("Connection is closed");
        }
    }

    public class ErrorState : StateBase
    {
        public override void Connect(ConnectionContext context)
        {
            throw new Exception("Some error");
        }

        public override byte[] Read(ConnectionContext context)
        {
            throw new Exception("Some error");
        }

        public override void Close(ConnectionContext context)
        {
            throw new Exception("Some error");
        }
    }
}
