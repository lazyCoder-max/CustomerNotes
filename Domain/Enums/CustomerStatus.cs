namespace Domain.Enums
{
    public abstract class CustomerStatus : Enumeration<CustomerStatus>
    {
        public static readonly CustomerStatus Null = new NullCustomerStatus();
        public static readonly CustomerStatus Complete = new CompleteCustomerStatus();
        public static readonly CustomerStatus InProgress = new InProgressCustomerStatus();

        protected CustomerStatus(int value, string name) 
            : base(value, name)
        {
        }

        private sealed class NullCustomerStatus : CustomerStatus
        {
            public NullCustomerStatus()
                : base(1, "Null")
            {
            }
        }

        private sealed class CompleteCustomerStatus : CustomerStatus
        {
            public CompleteCustomerStatus()
                : base(2, "Complete")
            {
            }
        }

        private sealed class InProgressCustomerStatus : CustomerStatus
        {
            public InProgressCustomerStatus()
                : base(3, "WIP")
            {
            }
        }
    }
}
