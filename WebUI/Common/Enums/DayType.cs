namespace WebUI.Common.Enums
{
    public abstract class DayType : Enumeration<DayType>
    {
        public static readonly DayType Null = new NullDayType();
        public static readonly DayType Business = new BusinessDayType();
        public static readonly DayType Calendar = new CalendarDayType();

        protected DayType(int value, string name)
            : base(value, name)
        {
        }

        private sealed class NullDayType : DayType
        {
            public NullDayType()
                : base(1, "Null")
            {
            }
        }

        private sealed class BusinessDayType : DayType
        {
            public BusinessDayType()
                : base(2, "Business")
            {
            }
        }

        private sealed class CalendarDayType : DayType
        {
            public CalendarDayType()
                : base(3, "Calendar")
            {
            }
        }
    }
}
