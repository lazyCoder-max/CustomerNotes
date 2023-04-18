namespace WebUI.Common.Enums
{
    public abstract class MicroChemistryType : Enumeration<MicroChemistryType>
    {
        public static readonly MicroChemistryType Null = new NullMicroChemistryType();
        public static readonly MicroChemistryType RoutineMicro = new RoutineMicroMicroChemistryType();

        public static readonly MicroChemistryType OtherMicro = new OtherMicroMicroChemistryType();
        public static readonly MicroChemistryType OtherAllergens = new OtherAllergensType();
        public static bool IsSelected { get; set; } = false;

        protected MicroChemistryType(int value, string name)
            : base(value, name)
        {
        }

        private sealed class NullMicroChemistryType : MicroChemistryType
        {
            public NullMicroChemistryType()
                : base(1, "Null")
            {
            }
        }

        private sealed class RoutineMicroMicroChemistryType : MicroChemistryType
        {
            public RoutineMicroMicroChemistryType()
                : base(2, "Routine - Chem")
            {
            }
        }
        private sealed class OtherAllergensType : MicroChemistryType
        {
            public OtherAllergensType()
                : base(3, "Routine - Allergens")
            {
            }
        }
        private sealed class OtherMicroMicroChemistryType : MicroChemistryType
        {
            public OtherMicroMicroChemistryType()
                : base(7, "Other - Chem")
            {
            }
        }
    }
}
