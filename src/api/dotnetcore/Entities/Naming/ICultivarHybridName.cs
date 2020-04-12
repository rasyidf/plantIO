namespace PlantIO.Entities.Naming
{
    public interface ICultivarHybridName
    {
        public string Name { get; set; }

        public ICultivarName Name1 { get; set; } // #td: rename
        public ICultivarName Name2 { get; set; } // #td: rename
    }
}