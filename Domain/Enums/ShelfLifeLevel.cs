namespace Domain.Enums
{
    public abstract class ShelfLifeLevel : Enumeration<ShelfLifeLevel>
    {
        public static readonly ShelfLifeLevel None = new NoneShelfLifeLevel();
        public static readonly ShelfLifeLevel TwoThirds = new TwoThirdsShelfLifeLevel();
        public static readonly ShelfLifeLevel Fifty = new FiftyShelfLifeLevel();
        public static readonly ShelfLifeLevel Sixty = new SixtyShelfLifeLevel();
        public static readonly ShelfLifeLevel Seventy = new SeventyShelfLifeLevel();
        public static readonly ShelfLifeLevel Eighty = new EightyShelfLifeLevel();
        public static readonly ShelfLifeLevel Ninety = new NinetyShelfLifeLevel();

        protected ShelfLifeLevel(int value, string name) 
            : base(value, name)
        {
        }

        private sealed class NoneShelfLifeLevel : ShelfLifeLevel
        {
            public NoneShelfLifeLevel()
                : base(1, "None")
            {
            }
        }

        private sealed class TwoThirdsShelfLifeLevel : ShelfLifeLevel
        {
            public TwoThirdsShelfLifeLevel()
                : base(2, "2/3")
            {
            }
        }

        private sealed class FiftyShelfLifeLevel : ShelfLifeLevel
        {
            public FiftyShelfLifeLevel()
                : base(3, "50%")
            {
            }
        }

        private sealed class SixtyShelfLifeLevel : ShelfLifeLevel
        {
            public SixtyShelfLifeLevel()
                : base(4, "60%")
            {
            }
        }

        private sealed class SeventyShelfLifeLevel : ShelfLifeLevel
        {
            public SeventyShelfLifeLevel()
                : base(5, "70%")
            {
            }
        }

        private sealed class EightyShelfLifeLevel : ShelfLifeLevel
        {
            public EightyShelfLifeLevel()
                : base(6, "80%")
            {
            }
        }

        private sealed class NinetyShelfLifeLevel : ShelfLifeLevel
        {
            public NinetyShelfLifeLevel()
                : base(7, "90%")
            {
            }
        }
    }
}
